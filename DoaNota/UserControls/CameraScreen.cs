using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Imaging;
using ZXing;
using ZXing.Common;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using DoaNotaPR.Classes.Memory;
using DoaNotaPR.Classes.Data;
using DoaNotaPR;
using Microsoft.Data.Sqlite;
using System.Web;
using System.Text.RegularExpressions;
using DoaNotaPR.Classes;
using System.Runtime.InteropServices;
using DoaNotaPR.Properties;
using AForge.Imaging.Filters;
using System.Diagnostics;

namespace DoaNotaPR
{
    public partial class CameraScreen : UserControl
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private string lastmessage = string.Empty;
        private Point point1 = new Point(0, 0);
        private Point point2 = new Point(0, 0);
        private Point point3 = new Point(0, 0);
        private Point point4 = new Point(0, 0);
        private string ultimaChaveLida = string.Empty;
        private bool ultimoStatusSucesso = false;
        private string ultimaMensagem = string.Empty;
        

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private bool muted = true;

        public CameraScreen()
        {
            int NewVolume = ((ushort.MaxValue / 10) *1);
            // Set the same volume for both the left and the right channels
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            // Set the volume
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);

            InitializeComponent();

            if (DesignMode)
                return;

            lblUltimaChave.Text = string.Empty;
            lblUltimaNotaDataEmitida.Text = string.Empty;
            lblUltimaValorNota.Text = string.Empty;
            lblUltimaNotaStatus.Text = string.Empty;
            AtualizarEntidade();

            BuscaCamerasInstaladas();

            Oklabel.Parent = pictureBoxSource;
          
            Oklabel.Visible = false;

        }

        private void BuscaCamerasInstaladas()
        {
            comboBoxCameraSource.Items.Clear();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCameraSource.Items.Add(device.Name);
            }
            if (comboBoxCameraSource.Items.Count < 1)
            {
                //Nenhuma camera conectada
                Start.Enabled = false;

            }
            else
            {
                comboBoxCameraSource.SelectedIndex = comboBoxCameraSource.Items.Count - 1;
                videoSource = new VideoCaptureDevice();
                Start.Enabled = true;
            }
        }

        private async Task ClearFoundQRCode()
        {
            await Task.Delay(800);
            Oklabel.Visible = false;
            lblUltimaNotaStatus.Text = "";
            point1 = new Point(0, 0);
            point2 = new Point(0, 0);
            point3 = new Point(0, 0);
            point4 = new Point(0, 0);

            Oklabel.Update();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            AddInvoiceManally();
        }

        public void ShutDownCamera()
        {
            CloseCamera();
        }

        private void AddInvoiceManally()
        {
            if (tbManualInput.Text.Length < 44)
                return;
            var nf = new NotaFiscal();
            nf.Chave = tbManualInput.Text;
            nf.DataCadastro = DateTime.Now;
            nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Pendente;

            using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
            {
                try
                {
                    var teste = BD.Incluir(nf);

                    lock (DoaNotaManagement.FilaPendente)
                    {
                        DoaNotaManagement.FilaPendente.Enqueue(nf);
                        DoaNotaManagement.IncrementarPendente();
                    }

                    lblUltimaChave.Invoke((MethodInvoker)delegate { lblUltimaChave.Text = nf.Chave; });
                    lblUltimaNotaDataEmitida.Invoke((MethodInvoker)delegate { lblUltimaNotaDataEmitida.Text = nf.DataEmissao.ToString("dd/MM/yyyy"); });
                    lblUltimaValorNota.Invoke((MethodInvoker)delegate { lblUltimaValorNota.Text = nf.Valor.ToString("R$0.00"); });


                    Oklabel.Invoke((Action)ChangeStatusNoMessage);

                }
                catch (SqliteException ex)
                {
                    lblUltimaNotaStatus.Invoke((MethodInvoker)delegate { lblUltimaNotaStatus.Text =Constantes.MENSAGEM_NOTA_CADASTRADA; });
                    if (Oklabel.Visible == false)
                    {
                        Oklabel.Invoke((Action)ChangeStatusNoMessage);
                    }
                }
            }
            tbManualInput.Text = string.Empty;
        }

        private void QRReaderPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartCamera();

        }

        private void StartCamera()
        {
            if (DesignMode)
                return;
            
            if (cbResolutions.SelectedIndex == -1 || comboBoxCameraSource.SelectedIndex == -1)
            {
                CloseCameraMenu();
                return;
            }

            if (videoSource != null && videoSource.IsRunning)
            {
                
                videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Stop();
                videoSource = null;
            }

            videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameraSource.SelectedIndex].MonikerString);
            videoSource.VideoResolution = videoSource.VideoCapabilities[cbResolutions.SelectedIndex];
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();

            Thread.Sleep(200);

            CloseCameraMenu();
        }

        private void CloseCameraMenu()
        {
            EscolhaCameraPanel.Visible = false;
            EscolhaCameraPanel.Update();
            panelMenuCamera.Visible = false;
            panelMenuCamera.Update();
        }

        private void ChangeStatusNoMessage()
        {
            ShowOnCameraMessage(string.Empty, Color.FromArgb(56, 199, 42));
        }
        private void ChangeStatusOk()
        {
            ultimoStatusSucesso = true;
            ShowOnCameraMessage("OK", Color.FromArgb(56, 199, 42));
        }

        private void ShowOnCameraMessage(string message, Color testfontColor)
        {
            Oklabel.ForeColor = testfontColor;
            Oklabel.Text = message;
            Oklabel.Visible = true;
            Oklabel.Update();

            Task ignoredAwaitableResult = this.ClearFoundQRCode();
        }

        private void ChangeStatusError()
        {
            ultimoStatusSucesso = false;
            ShowOnCameraMessage("OK", Color.FromArgb(255, 30, 0));
        }

        private int frameSkipCount = 0;
        
        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                if (frameSkipCount > 30)
                {
                    frameSkipCount = 0;
                    return;
                }
                frameSkipCount++;

                if (videoSource == null)
                    return;
                
                pictureBoxSource.Invoke((MethodInvoker)delegate
                {
                    Bitmap image = new Bitmap(eventArgs.Frame);

                    //image = AdjustContrast(MakeGrayscale3(image), 1.50f);
                    if (DoaNotaManagement.Settings.InvertCameraX && DoaNotaManagement.Settings.InvertCameraY)
                        image.RotateFlip(RotateFlipType.Rotate180FlipXY);
                    else if (DoaNotaManagement.Settings.InvertCameraX)
                        image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    else if (DoaNotaManagement.Settings.InvertCameraY)
                        image.RotateFlip(RotateFlipType.Rotate180FlipY);
                    
                    pictureBoxSource.BackgroundImage = image;
                  
                    pictureBoxSource.BackgroundImageLayout = ImageLayout.Stretch;
                   
                    if (image != null)
                    {
                        var message = ExtractQRCodeMessageFromImage((MakeGrayscale3(image)));// AdjustContrast(MakeGrayscale3(image),3.00f));

                        if (message != null)
                        {
                            if (lastmessage != message)
                            {
                                
                                var status = string.Empty;

                                var nf = GetKey(out status, message);

                                if(nf != null)
                                    if (ultimaChaveLida == nf.Chave)
                                {
                                    if (ultimoStatusSucesso)
                                    {

                                        Oklabel.Invoke((Action)ChangeStatusOk);
                                        PlayBeep(true);
                                    }
                                    else
                                    {
                                        lblUltimaNotaStatus.Invoke((MethodInvoker)delegate { lblUltimaNotaStatus.Text = ultimaMensagem; });
                                        Oklabel.Invoke((Action)ChangeStatusError);
                                        PlayBeep(false);
                                    }

                                    return;
                                }

                                lblUltimaNotaStatus.Invoke((MethodInvoker)delegate { lblUltimaNotaStatus.Text = status; });

                                if (nf == null)
                                {
                                    if (Oklabel.Visible == false)
                                    {
                                        ultimaMensagem = status;
                                        Oklabel.Invoke((Action)ChangeStatusError);
                                        PlayBeep(false);
                                    }
                                }
                                else
                                {
                                    ultimaChaveLida = nf.Chave;

                                    if (status != string.Empty)
                                    {
                                        lblUltimaNotaStatus.Invoke((MethodInvoker)delegate { lblUltimaNotaStatus.Text = status; });

                                    }
                                    using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
                                    {
                                        try
                                        {
                                            var teste = BD.Incluir(nf);
                                            DoaNotaManagement.IncrementarPendente();

                                            if (nf.SituacaoEnvioDoacao == SituacaoEnvioDoacao.Pendente)
                                            {
                                                lock (DoaNotaManagement.FilaPendente)
                                                {
                                                    DoaNotaManagement.FilaPendente.Enqueue(nf);
                                                    
                                                }
                                                ultimaMensagem = string.Empty;
                                                Oklabel.Invoke((Action)ChangeStatusOk);
                                                PlayBeep(true);
                                            }
                                            else
                                            {
                                                ultimaMensagem = status;
                                                DoaNotaManagement.IncrementarEnviado(false);
                                                Oklabel.Invoke((Action)ChangeStatusError);
                                                PlayBeep(false);
                                            }

                                            lblUltimaChave.Invoke((MethodInvoker)delegate { lblUltimaChave.Text = nf.Chave; });
                                            lblUltimaNotaDataEmitida.Invoke((MethodInvoker)delegate { lblUltimaNotaDataEmitida.Text = nf.DataEmissao.ToString("dd/MM/yyyy"); });
                                            lblUltimaValorNota.Invoke((MethodInvoker)delegate { lblUltimaValorNota.Text = nf.Valor.ToString("R$0.00"); });

                                            lastmessage = message;

                                        }
                                        catch (SqliteException ex)
                                        {
                                            lblUltimaNotaStatus.Invoke((MethodInvoker)delegate { lblUltimaNotaStatus.Text = Constantes.MENSAGEM_NOTA_CADASTRADA; });
                                            
                                            if (Oklabel.Visible == false)
                                            {
                                                ultimaMensagem = Constantes.MENSAGEM_NOTA_CADASTRADA;
                                                Oklabel.Invoke((Action)ChangeStatusError);
                                                PlayBeep(false);
                                                //lastmessage = message;
                                            }
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (Oklabel.Visible == false)
                                    Oklabel.Invoke((Action)ChangeStatusOk);
                            }

                        }
                    }
                    // GC.Collect();
                });
            }
            catch (Exception ex)
            {
                ///MessageBox.Show(ex.ToString());
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                ShutDownCamera();
                Application.Exit();
            }
        }

        private void PlayBeep(bool success)
        {
            
            if (!muted)
            {
                System.Media.SoundPlayer player = null;
                if(success)
                    player = new System.Media.SoundPlayer(Properties.Resources.beep);
                else
                    player = new System.Media.SoundPlayer(Properties.Resources.BeepError);

                player.Play();
            }
        }

        private NotaFiscal GetKey(out string Message, string qrInfo)
        {
            try
            {
                NotaFiscal nf = new NotaFiscal();
                nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Pendente;
                Message = string.Empty;

                Uri myUri = new Uri(ConvertLink(qrInfo));
                if (!HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).AllKeys.Contains("chNFe".ToLowerInvariant()))
                {
                    Message = Constantes.MENSAGEM_ERRO_LEITURA_QRCODE;
                    return null;
                }

                if (HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).AllKeys.Contains("cDest".ToLowerInvariant()) && !string.IsNullOrEmpty(HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).Get("cDest".ToLowerInvariant())))
                {
                    Message = Constantes.MENSAGEM_ERRO_CONSUMIDOR_INFORMADO;
                    nf.MensagemRetornoEnvioDoacao = Constantes.MENSAGEM_ERRO_CONSUMIDOR_INFORMADO;
                    nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Erro;
                }

                nf.Chave = HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).Get("chNFe".ToLowerInvariant());

                var data = DateTime.MinValue;

                DateTime.TryParse(HexStringToString(HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).Get("dhEmi".ToLowerInvariant())), out data);
                nf.DataEmissao = data;

                Message = ValidarData(Message, nf);

                double valor = 0.00;

                double.TryParse(HttpUtility.ParseQueryString(myUri.Query.ToLowerInvariant()).Get("vNF".ToLowerInvariant()), System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out valor);

                nf.Valor = valor;

                nf.DataCadastro = DateTime.Now;

                return nf;
            }
            catch (Exception ex)
            {
                try {
                    //CFe35170947508411093065590001533131022977578989|20170916145415|66.80||lAvFHwYq+75NuFumxzMQ04uHmdr1dezQqgs4mrfpuAvTIp3K/zU8q963QAha3JnnXBE2jI/+avL9fCD9B8ii4Ymq9cx2yQD6iuHULiHoldIwLoUDR2FGOgC42m8HUYeuh2YnKRZ5QAnF1ERqEjCc1VoZ0NaJo9AXe6eeCWv+gj0iucsDb9qStljXZNRUT92gR/xTldcISjo1lL0M6/T4Fowp+sch1Volr7GcU3Ck83Yvw9oAIk099Ur06QCW/M+uIGhSgXdfCqA6b531wCB+7+tF0inhAQPCY1kZne2pAe5uEpZZuw0mulYLt5l5WggJr+B2vY+P3hQPWq+kuycPUA==
                    var ExceptionString1 = qrInfo.Split('|');
                    NotaFiscal nf = new NotaFiscal();
                    nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Pendente;
                    Message = string.Empty;
                    nf.Chave = ExceptionString1[0].Replace("CFe", string.Empty);
                    if (nf.Chave.Length != 44)
                        throw new Exception();
                    nf.DataEmissao = DateTime.Parse($"{ExceptionString1[1].Substring(0, 4)}-{ExceptionString1[1].Substring(4, 2)}-{ExceptionString1[1].Substring(6, 2)}");
                    nf.Valor = double.Parse(ExceptionString1[2], System.Globalization.CultureInfo.InvariantCulture);
                    nf.DataCadastro = DateTime.Now;

                    Message = ValidarData(Message, nf);
                    return nf;
                }
                catch
                {
                    new ExceptionFileHandler().CreateCrashFile($"{ex.ToString()} QRCODE: {qrInfo}");
                    Message = "QRCode Inválido";
                    return null;
                }


                
            }

        }

        private static string ValidarData(string Message, NotaFiscal nf)
        {


            if (DoaNotaManagement.Settings.ValidarData && DoaNotaManagement.Settings.PrazoValidacao == 0)
            {
                var validade = nf.DataEmissao.AddMonths(1);
                validade = new DateTime(validade.Year, validade.Month, DateTime.DaysInMonth(validade.Year, validade.Month));

                if (DateTime.Now > validade)
                {
                    Message = Constantes.MENSAGEM_NOTA_EXPIRADA_VALIDACAO;
                    nf.MensagemRetornoEnvioDoacao = Constantes.MENSAGEM_NOTA_EXPIRADA_VALIDACAO;
                    nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Erro;
                }
            }
            else if (DoaNotaManagement.Settings.ValidarData && DateTime.Now.AddDays(-DoaNotaManagement.Settings.PrazoValidacao).Date > nf.DataEmissao)
            {
                Message = Constantes.MENSAGEM_NOTA_EXPIRADA_VALIDACAO;
                nf.MensagemRetornoEnvioDoacao = Constantes.MENSAGEM_NOTA_EXPIRADA_VALIDACAO;
                nf.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Erro;
            }

            return Message;
        }

        public static Bitmap AdjustContrast(Bitmap originalImage, float Value)
        {
            
            Bitmap adjustedImage = new Bitmap(originalImage.Width, originalImage.Height);
            float brightness = 1.0f; // no change in brightness
            float contrast = Value; // twice the contrast
            float gamma = 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
        new float[] {contrast, 0, 0, 0, 0}, // scale red
        new float[] {0, contrast, 0, 0, 0}, // scale green
        new float[] {0, 0, contrast, 0, 0}, // scale blue
        new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
        new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

            Graphics g = Graphics.FromImage(adjustedImage);
            g.DrawImage(originalImage, new Rectangle(0, 0, adjustedImage.Width, adjustedImage.Height)
                , 0, 0, originalImage.Width, originalImage.Height,
                GraphicsUnit.Pixel, imageAttributes);

            return adjustedImage;
        }

        private string ExtractQRCodeMessageFromImage(Bitmap bitmap)
        {
            try
            {

                BarcodeReader reader = new BarcodeReader
                    (null, newbitmap => new BitmapLuminanceSource(bitmap), luminance => new GlobalHistogramBinarizer(luminance));

                reader.TryInverted = false;
                reader.Options = new DecodingOptions { TryHarder = true, PossibleFormats = new List<BarcodeFormat>() { BarcodeFormat.QR_CODE } };
                reader.AutoRotate = false;


                //var result = reader.Decode(bitmap);

                //if(result == null)
                var    result = reader.Decode(bitmap);

                if (result != null)
                {
                    if (result.ResultPoints.Count() > 3)
                    {
                        point1 = new Point(((int)result.ResultPoints[0].X * pictureBoxSource.Width) / bitmap.Width, ((int)result.ResultPoints[0].Y * pictureBoxSource.Height) / bitmap.Height);
                        point2 = new Point(((int)result.ResultPoints[1].X * pictureBoxSource.Width) / bitmap.Width, ((int)result.ResultPoints[1].Y * pictureBoxSource.Height) / bitmap.Height);
                        point3 = new Point(((int)result.ResultPoints[2].X * pictureBoxSource.Width) / bitmap.Width, ((int)result.ResultPoints[2].Y * pictureBoxSource.Height) / bitmap.Height);
                        point4 = new Point(((int)result.ResultPoints[3].X * pictureBoxSource.Width) / bitmap.Width, ((int)result.ResultPoints[3].Y * pictureBoxSource.Height) / bitmap.Height);

                    }

                    return result.Text;
                }
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
            }
            return null;
        }
        public static Bitmap MakeGrayscale3(Bitmap original)
        {

            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(original);

            return grayImage;
            
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            
            Graphics g = Graphics.FromImage(newBitmap);
            
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
            new float[] {.3f, .3f, .3f, 0, 0},
            new float[] {.59f, .59f, .59f, 0, 0},
            new float[] {.11f, .11f, .11f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
               });
            
            ImageAttributes attributes = new ImageAttributes();
            
            attributes.SetColorMatrix(colorMatrix);
            
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
           
            g.Dispose();

            return newBitmap;
        }

        public string HexStringToString(string HexString)
        {
            string stringValue = "";
            for (int i = 0; i < HexString.Length / 2; i++)
            {
                string hexChar = HexString.Substring(i * 2, 2);
                int hexValue = Convert.ToInt32(hexChar, 16);
                stringValue += Char.ConvertFromUtf32(hexValue);
            }
            return stringValue;
        }

        public string ConvertLink(string input)
        {
            if (!input.Contains("http"))
                input = $"http://{input}";
            
            while (input[0] != 'h')
            {
                input = input.TrimStart(input[0]);
            }
            
            //remoção de caracteres incorretos em algumas notas.
            input = RemoveDuplicate(input, "?");
            

            return input;
        }

        private string RemoveDuplicate(string input, string info)
        {
            while (input.Contains($"{info}{info}"))
            {
                input = input.Replace($"{info}{info}", info);
            }
            return input;
        }

        private void cbResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCameraSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbResolutions.Items.Clear();
            videoSource = new VideoCaptureDevice(videoDevices[comboBoxCameraSource.SelectedIndex].MonikerString);
            foreach (var reso in videoSource.VideoCapabilities)
            {
                cbResolutions.Items.Add($"{reso.FrameSize.Width}x{reso.FrameSize.Height} - {reso.FrameRate}fps");
            }
            if (cbResolutions.Items.Count > 0)
                cbResolutions.SelectedIndex = 0;
        }

        private void pictureBoxSource_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Oklabel.ForeColor, 6);


            // Draw line to screen.
            if (point1.X != 0)
            {
                e.Graphics.DrawLine(pen, point1, point2);
                e.Graphics.DrawLine(pen, point2, point3);
                e.Graphics.DrawLine(pen, point3, point4);
                e.Graphics.DrawLine(pen, point4, point1);
                CentralizarLabelOK();
                pictureBoxSource.Update();
            }
        }

        private void CentralizarLabelOK()
        {
            var pointXs = point1.X;
            var pointXg = point1.X;
            if (pointXs > point2.X)
                pointXs = point2.X;
            else if (pointXg < point2.X)
                pointXg = point2.X;

            if (pointXs > point3.X)
                pointXs = point3.X;
            else if (pointXg < point3.X)
                pointXg = point3.X;

            if (pointXs > point4.X)
                pointXs = point4.X;
            else if (pointXg < point4.X)
                pointXg = point4.X;

            var pointYs = point1.Y;
            var pointYg = point1.Y;
            if (pointYs > point2.Y)
                pointYs = point2.Y;
            else if (pointYg < point2.Y)
                pointYg = point2.Y;

            if (pointYs > point3.Y)
                pointYs = point3.Y;
            else if (pointYg < point3.Y)
                pointYg = point3.Y;

            if (pointYs > point4.Y)
                pointYs = point4.Y;
            else if (pointYg < point4.Y)
                pointYg = point4.Y;

            Oklabel.Location = new Point(((pointXs + pointXg) / 2) - (Oklabel.Width / 2), ((pointYs + pointYg) / 2) - (Oklabel.Height / 2));


            Oklabel.Update();
        }

        private void cbInverteCameraY_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnInvertX_Click(object sender, EventArgs e)
        {
            if (DoaNotaManagement.Settings.InvertCameraX)
                DoaNotaManagement.Settings.InvertCameraX = false;
            else
                DoaNotaManagement.Settings.InvertCameraX = true;
            new SettingsManager().SaveSettings(DoaNotaManagement.Settings);
        }

        private void btnInvertY_Click(object sender, EventArgs e)
        {
            if (DoaNotaManagement.Settings.InvertCameraY)
                DoaNotaManagement.Settings.InvertCameraY = false;
            else
                DoaNotaManagement.Settings.InvertCameraY = true;
            new SettingsManager().SaveSettings(DoaNotaManagement.Settings);
        }

        private void tbManualInput_TextChanged(object sender, EventArgs e)
        {
            var start = tbManualInput.SelectionStart;

            var text = tbManualInput.Text;
            tbManualInput.Text = new Utils().RemoveFormat(text, 44);

            if (tbManualInput.Text.Length < start)
                start = tbManualInput.Text.Length;
            tbManualInput.SelectionStart = start;
        }

        private void tbManualInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddInvoiceManally();
            }
        }

        private void cameraconfigbtn_Click(object sender, EventArgs e)
        {
            panelMenuCamera.Visible = panelMenuCamera.Visible ? false : true;

            if (!panelMenuCamera.Visible)
            {
                return;
            }

            BuscaCamerasInstaladas();

            CloseCamera();

            EscolhaCameraPanel.Visible = panelMenuCamera.Visible;
            EscolhaCameraPanel.Update();
            pictureBoxSource.BackgroundImage = null;
        }

        private void CloseCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.SignalToStop();

                videoSource = null;
            }
        }

        private void CameraScreen_Load(object sender, EventArgs e)
        {
            StartCamera();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.btnRefreshCamera, Constantes.TOOLTIP_BOTAO_ATUALIZAR_CAMERAS_DISPONIVEIS );
            toolTip1.SetToolTip(this.btnAdicionarNota, Constantes.TOOLTIP_BOTAO_ADICIONAR_MANUAL);

        }

        public void AtualizarEntidade()
        {
            if (DoaNotaManagement.Settings != null)
                lblEntidadeEscolhida.Text = DoaNotaManagement.Settings.RazaoSocialInst;
        }

        private void btnRefreshCamera_Click(object sender, EventArgs e)
        {
            BuscaCamerasInstaladas();
        }

        private void tbManualInput_MouseEnter(object sender, EventArgs e)
        {

        }

        private static void ShowToolTip(string mensagem, IWin32Window Control)
        {
            int VisibleTime = 1600;
            ToolTip tt = new ToolTip();
            tt.Show(mensagem, Control, 0, -20, VisibleTime);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            muted = muted ? false : true;

            button1.BackgroundImage = muted ? Resources.icon_volume_muted_3x : Resources.icon_volume_3x;
        }
    }
    }
