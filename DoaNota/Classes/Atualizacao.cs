using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SageDoaNotaPR.Classes
{
    public class Atualizacao
    {
        private const string ENDERECO_BASE = "http://downloads.folhamatic.com.br/folhamatic/folha_sistema/sistemas/voffice/atualizacao_especial/DoaNotaPR/";
        public bool DeveAtualizar()
        {
            try
            {
                WebClient wc = new WebClient();

                var data = JsonConvert.DeserializeObject<Versao>(wc.DownloadString($"{ENDERECO_BASE}version.json"));

                var ultimaVersao = Version.Parse(data.version);
                var versaoAtual = Assembly.GetExecutingAssembly().GetName().Version;
                if (ultimaVersao < versaoAtual  )
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }

    public class Versao
    {
        public string version { get; set; }
    }
}
