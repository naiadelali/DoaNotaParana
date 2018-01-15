
using DoaNotaPR.Classes;
using DoaNotaPR.Classes.Data;
using DoaNotaPR.Classes.Memory;
using DoaNotaPR.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoaNotaPR
{
    public partial class MainForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        BackgroundWorker WorkerAtualizaPlacar = new BackgroundWorker();
        EnviaNotas sendInvoice1 = new EnviaNotas();
        
      
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public MainForm()
        {
            try
            {
                InitializeComponent();

#if PORTABLE
                //Task t = Task.Run(() =>
                //{
                //    new UpdateHelper().Update();
                //});
#endif
                DoaNotaManagement.Placar = new Classes.Placar();
                DoaNotaManagement.FilaPendente = new Queue<Classes.Data.NotaFiscal>();
                DoaNotaManagement.Settings = new SettingsManager().RetrieveConfiguration();

                WorkerAtualizaPlacar.DoWork += WorkerAtualizaPlacar_DoWork;
                WorkerAtualizaPlacar.WorkerSupportsCancellation = true;
               
            }
            catch(Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                //File.WriteAllText("excp.dat", ex.ToString());
            }
            
        }

        private void WorkerAtualizaPlacar_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!WorkerAtualizaPlacar.CancellationPending)
            {

                try
                {
                    lblNotasEnviadas.Invoke((MethodInvoker)delegate { lblNotasEnviadas.Text = DoaNotaManagement.Placar.Enviadas.ToString("#,0"); });
                    lblNotasPendentes.Invoke((MethodInvoker)delegate { lblNotasPendentes.Text = DoaNotaManagement.Placar.Pendentes.ToString("#,0"); });
                    lblTotalNotas.Invoke((MethodInvoker)delegate { lblTotalNotas.Text = DoaNotaManagement.Placar.QtdTotal.ToString("#,0"); });

                    UpdateButtonSendInvoice();
                    cameraScreen1.Invoke((MethodInvoker)delegate { cameraScreen1.AtualizarEntidade(); });


                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                }
        }
           
        }

        private void UpdateButtonSendInvoice()
        {
            if (DoaNotaManagement.Error.IsThereAnError)
            {
                btnLigarDesligarEnvio.Invoke((MethodInvoker)delegate { btnLigarDesligarEnvio.BackgroundImage = Resources.icon_alert_4x; });
            }
            else
            {
                btnLigarDesligarEnvio.BackgroundImage = DoaNotaManagement.Settings.SendInvoices ? Resources.icon_cloud_upload_4x : Resources.icon_cloud_disconnect_4x;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateButtonSendInvoice();
                using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
                {
                    BD.CriarTabelaSeNaoExistir();
                    BD.Remover(60);
                    var pendentes = BD.RecuperarNotasFiscais(null, DateTime.MinValue, DateTime.MaxValue, SituacaoEnvioDoacao.Pendente);

                    if (pendentes != null)
                        foreach (var nf in pendentes)
                        {
                            DoaNotaManagement.FilaPendente.Enqueue(nf);
                        }

                    var infoQuantidades = BD.RecuperarInfoQuantidadeNotaFiscais(null);
                    DoaNotaManagement.Placar.Enviadas = infoQuantidades.QuantidadeEnviadas;
                    DoaNotaManagement.Placar.QtdTotal = infoQuantidades.QuantidadeTotal;
                    DoaNotaManagement.Placar.Pendentes = infoQuantidades.QuantidadePendentes;
                }

                WorkerAtualizaPlacar.RunWorkerAsync();

                toolTip1.AutoPopDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;

                toolTip1.SetToolTip(this.btnMostrarGrid, "Veja aqui o histórico das doações");
                toolTip1.SetToolTip(this.btnLigarDesligarEnvio, "Habilite ou desabilite o envio das notas");
                toolTip1.SetToolTip(this.configbtn, "Configurações");
                toolTip1.SetToolTip(this.btnClose, "Fechar a aplicação");
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
            }
        }

        private void btnLigarDesligarEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                if (DoaNotaManagement.Error.IsThereAnError)
                {
                    DoaNotaManagement.Settings.SendInvoices = false;
                    MessageBox.Show(DoaNotaManagement.Error.LastError, "Mensagem de erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                DoaNotaManagement.Settings.SendInvoices = DoaNotaManagement.Settings.SendInvoices ? false : true;


                if (DoaNotaManagement.Settings.SendInvoices && !string.IsNullOrEmpty(DoaNotaManagement.Settings.Password))
                {

                    DoaNotaManagement.Error = new Error();
                    UpdateButtonSendInvoice();
                    sendInvoice1.Start();
                }
                new SettingsManager().SaveSettings(DoaNotaManagement.Settings);
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (DoaNotaManagement.Placar.Pendentes > 0)
            {
                var result = MessageBox.Show("Algumas notas ficaram pendentes e não serão enviadas se você fechar o programa. Deseja realmente fechar o aplicativo?",
                    "Doa Nota Paraná", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;

            }
            cameraScreen1.ShutDownCamera();
            Application.Exit();
        }

        private void configbtn_Click(object sender, EventArgs e)
        {
            settings1.Visible = settings1.Visible ? false : true;
            cameraScreen1.AtualizarEntidade();
            gridScreen1.Visible = false;
        }

        private void cameraconfigbtn_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarGrid_Click(object sender, EventArgs e)
        {
            gridScreen1.Visible = gridScreen1.Visible ? false : true;
            if (gridScreen1.Visible)
                settings1.Visible = false;
            
        }

        private void gridScreen1_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckErro_Click(object sender, EventArgs e)
        {
        
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void sendInvoice1_Load(object sender, EventArgs e)
        {

        }

        private void gridScreen1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void settings1_VisibleChanged(object sender, EventArgs e)
        {
            cameraScreen1.AtualizarEntidade();
        }
    }
}
