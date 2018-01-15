using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes
{
    public class SettingsManager
    {
        public string GetSettingsPath()
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\doanotasettings.dat";
        }
        public void SaveSettings(Settings setting)
        {
            if (setting.SaveCredentials)
            {

                File.WriteAllText(GetSettingsPath(), new CryptoHelper().EncryptString($"{setting.CPF}|{setting.Password}|{setting.CNPJInst}|{setting.InvertCameraX}|{setting.InvertCameraY}|{setting.SaveCredentials}|{setting.SendInvoices}|{setting.RazaoSocialInst}|{setting.ValidarData}|{setting.PrazoValidacao}"));
            }
            else
            {
                File.WriteAllText(GetSettingsPath(), new CryptoHelper().EncryptString($"|||{setting.InvertCameraX}|{setting.InvertCameraY}|{setting.SaveCredentials}|{setting.SendInvoices}|{setting.RazaoSocialInst}|{setting.ValidarData}|{setting.PrazoValidacao}"));
            }
        }

        public Settings RetrieveConfiguration()
        {
            try
            {
                string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var setting = new Settings();
                if (File.Exists(GetSettingsPath()))
                {
                    var info = new CryptoHelper().DecryptString(File.ReadAllText(GetSettingsPath())).Split('|');
                    setting.CPF = info[0];
                    setting.Password = info[1];
                    setting.CNPJInst = info[2];

                    if (info.Count() > 6)
                    {
                        bool config = false;
                        bool.TryParse(info[3], out config);

                        setting.InvertCameraX = config;
                        config = false;
                        bool.TryParse(info[4], out config);

                        setting.InvertCameraY = config;
                        config = false;
                        bool.TryParse(info[5], out config);

                        setting.SaveCredentials = config;

                        bool.TryParse(info[6], out config);

                        setting.SendInvoices = config;

                        setting.RazaoSocialInst = info[7];
                    }

                    if (info.Count() > 8)
                    {
                        bool config = false;
                        bool.TryParse(info[8], out config);

                        setting.ValidarData = config;

                        int prazo = 0;
                        int.TryParse(info[9], out prazo);
                        setting.PrazoValidacao = prazo;
                    }
                }
                return setting;
            }
            catch
            {
                return new Settings();
            }
        }
        
    }

    public class Settings
    {
        
        public string CPF { get; set; }
        public string Password { get; set; }
        
        public string CNPJInst { get; set; }
        public string RazaoSocialInst { get; set; }
        public bool SaveCredentials { get; set; }
        public bool InvertCameraX { get; set; }
        public bool InvertCameraY { get; set; }
        public bool SendInvoices { get; set; }
        public bool ValidarData { get; set; }
        public int PrazoValidacao { get; set; }
    }


}

