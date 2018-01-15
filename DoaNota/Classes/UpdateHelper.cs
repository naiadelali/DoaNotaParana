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
        private const string ENDERECO_BASE = "";
        //private const string ENDERECO_BASE = @"C:\Users\rodrigo.wang\Desktop\SERVERUPDATE\";
        public bool Update()
        {
            var update = false;
            try
            {
                string name = Assembly.GetEntryAssembly().GetName().Name;

                if (File.Exists(string.Format("{0}.bak", name)))
                    File.Delete(string.Format("{0}.bak", name));

                WebClient webClient = new WebClient();
                UpdateData versionData = JsonConvert.DeserializeObject<UpdateData>(webClient.DownloadString(string.Format("{0}version.json", ENDERECO_BASE)));

                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                var version = Version.Parse(fvi.FileVersion);

                if (versionData.version <= version || MessageBox.Show("Existe uma nova versão disponível deste aplicativo. Deseja atualizar agora?", "Doa Nota Paraná", MessageBoxButtons.YesNo) == DialogResult.No)
                    return true;

                update = true;

                DownloadUpdateAndReplace(name, webClient, versionData);

                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Infelizmente não conseguimos atualizar no momento. Tente novamente mais tarde.");
            }
            finally
            {
                string name = Assembly.GetEntryAssembly().GetName().Name;
                var cert = X509Certificate.CreateFromSignedFile(string.Format("{0}.exe", name));
                var cert2 = new X509Certificate2(cert.Handle);
                bool valid = cert2.Verify();

                if (!cert2.SubjectName.Name.ToLowerInvariant().Contains("xxx") || !valid)
                {
                    File.Delete(string.Format("{0}.exe", name));
                    MessageBox.Show("Infelizmente não conseguimos atualizar no momento. Tente novamente mais tarde.");
                    update = false;
                }
                    
                if (!File.Exists(string.Format("{0}.exe", name)) && File.Exists(string.Format("{0}.bak", name)))
                    File.Move(string.Format("{0}.bak", name), string.Format("{0}.exe", name));

                if (update)
                {
                    MessageBox.Show("O aplicativo Doa Nota Paraná será reiniciado.");
                    StartNewApplication(name);
                }

            }
            return false;
        }

        private static void StartNewApplication(string name)
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

        private void DownloadUpdateAndReplace(string name, WebClient webClient, UpdateData versionData)
        {
            string path = "DoaNotaUpdate";
            string str = string.Format("{0}\\update.zip", path);

            DeleteIfExists(str);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            webClient.DownloadFile(string.Format("{0}{1}-Portable.zip", ENDERECO_BASE, versionData.version), str);


            ExtractFiles(str, path);

            File.Move(string.Format("{0}.exe", name), string.Format("{0}.bak", name));
            File.Move($"{path}\\Doa Nota Paraná.exe", string.Format("{0}.exe", name));

            DeleteIfExists(str);

            DeleteIfEmpty(path);
        }

        private static void ExtractFiles(string str, string targetDirectory)
        {
            FastZip fastZip = new FastZip();
            string fileFilter = (string)null;
            fastZip.ExtractZip(str, targetDirectory, fileFilter);
        }

        private void DeleteIfEmpty(string path)
        {
            if (IsDirectoryEmpty(path))
                Directory.Delete(path);
        }

        private static void DeleteIfExists(string str)
        {
            if (File.Exists(str))
                File.Delete(str);
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any<string>();
        }
  
    }

    public class UpdateData
    {
        public Version version { get; set; }
        
    }
}
