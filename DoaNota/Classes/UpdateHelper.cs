using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace DoaNotaPR.Classes
{
    public class UpdateHelper
    {
        private string ENDERECO_BASE = Properties.Resources.urlUpdate;
        //private const string ENDERECO_BASE = @"C:\Users\rodrigo.wang\Desktop\SERVERUPDATE\";
        public bool Update()
        {
            var update = false;
            WebClient webClient = new WebClient();
            string nomeExe = Assembly.GetEntryAssembly().GetName().Name;
            AtualizacaoInfo atualizacaoInfo = null;
            try
            {
                

                if (File.Exists(string.Format("{0}.bak", nomeExe)))
                    File.Delete(string.Format("{0}.bak", nomeExe));

                
                //webClient.Headers.Add("secret-key", Properties.Resources.updatekey);
                atualizacaoInfo = JsonConvert.DeserializeObject<AtualizacaoInfo>(webClient.DownloadString(ENDERECO_BASE));

                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                var version = Version.Parse(fvi.FileVersion);

                if (atualizacaoInfo.version <= version || MessageBox.Show("Existe uma nova versão disponível deste aplicativo. Deseja atualizar agora?", "Doa Nota Paraná", MessageBoxButtons.YesNo) == DialogResult.No)
                    return true;
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile($"{ex.ToString()}");
                return true;
            }
                try { 
                update = true;

                BaixarAtualizacaoESubstitui(nomeExe, webClient, atualizacaoInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Infelizmente não conseguimos atualizar no momento. Tente novamente mais tarde.");
            }
            finally
            {
                string nomeDoExecutavel = Assembly.GetEntryAssembly().GetName().Name;
               
                //Não pode ser usado sem um certificado.
                //var cert = X509Certificate.CreateFromSignedFile(string.Format("{0}.exe", name));
                //var cert2 = new X509Certificate2(cert.Handle);
                //bool valid = cert2.Verify();

                //if (!cert2.SubjectName.Name.ToLowerInvariant().Contains("xxx") || !valid)
                //{
                //    File.Delete(string.Format("{0}.exe", name));
                //    MessageBox.Show("Infelizmente não conseguimos atualizar no momento. Tente novamente mais tarde.");
                //    update = false;
                //}
                    
                if (!File.Exists(string.Format("{0}.exe", nomeDoExecutavel)) && File.Exists(string.Format("{0}.bak", nomeDoExecutavel)))
                    File.Move(string.Format("{0}.bak", nomeDoExecutavel), string.Format("{0}.exe", nomeDoExecutavel));

                if (update)
                {
                    MessageBox.Show("Atualização foi executada com sucesso. O aplicativo Doa Nota Paraná será reiniciado.");
                    IniciaNovoExecutavel(nomeDoExecutavel);
                }

            }
            return false;
        }

        private static void IniciaNovoExecutavel(string name)
        {
            new Process()
            {
                StartInfo =
                    {
                        FileName = string.Format("{0}.exe",  name)
                    }
            }
                            .Start();
        }

        private void BaixarAtualizacaoESubstitui(string name, WebClient webClient, AtualizacaoInfo versionData)
        {
            string path = "DoaNotaUpdate";
            string str = string.Format("{0}\\update.zip", path);

            DeletaSeExiste(str);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            webClient.DownloadFile(versionData.file,str);


            ExtrairArquivos(str, path);

            File.Move(string.Format("{0}.exe", name), string.Format("{0}.bak", name));
            File.Move($"{path}\\Doa Nota Paraná.exe", string.Format("{0}.exe", name));

            DeletaSeExiste(str);

            DeletaSeVazio(path);
        }

        private static void ExtrairArquivos(string str, string targetDirectory)
        {
            FastZip fastZip = new FastZip();
            string fileFilter = (string)null;
            fastZip.ExtractZip(str, targetDirectory, fileFilter);
        }

        private void DeletaSeVazio(string path)
        {
            if (IsDirectoryEmpty(path))
                Directory.Delete(path);
        }

        private static void DeletaSeExiste(string str)
        {
            if (File.Exists(str))
                File.Delete(str);
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any<string>();
        }
  
    }

    public class AtualizacaoInfo
    {
        public Version version { get; set; }
        public string file { get; set; }
        
    }
}
