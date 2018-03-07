using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace NotaParanaLib
{
    public class NotaParanaWebClient : IDisposable
    {
        bool disposed = false;
        private List<AreaAtuacao> AreasAtuacaoCached { get; set; }
        private CustomWebClient webClient = new CustomWebClient();
        
        public NotaParanaWebClient()
        {
            //webClient.Encoding = Encoding.UTF8;
            webClient.UserAgent = @"Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36";
           // WebProxy wp = new WebProxy("127.0.0.1", 8888);
            //webClient.Proxy = wp;
        }

        public Entidade PesquisarEntidadesPorCnpj(string cnpj)
        {
            var lista = PesquisarEntidades(string.Empty, cnpj);
            return lista.Count == 0 ? null : lista[0];
        }
        
        public List<Entidade> PesquisarEntidadesPorNome(string nome)
        {
            return PesquisarEntidades(nome, string.Empty);
        }

        protected List<Entidade> PesquisarEntidades(string nome, string cnpj)
        {
            var entidades = new List<Entidade>();
            var areasAtuacao = RecuperarAreasAtuacao();

            cnpj = cnpj.SomenteDigitos();

            foreach (var area in areasAtuacao)
            {
                
                var json = webClient.DownloadString(string.Format(@"https://notaparana.pr.gov.br/nfprweb/publico/ConsultaEntidade?acao=buscarEntidade&idAreaAtuacao={0}&nome={1}&cnpj={2}", Uri.EscapeDataString(area.ID), Uri.EscapeDataString(nome), Uri.EscapeDataString(cnpj)));
                var entidadesArea = JsonConvert.DeserializeObject<List<Entidade>>(json);
                entidades.AddRange(entidadesArea);

                //se a pesquisa for por cnpj, quando encontrar para
                if (cnpj != null && cnpj.Length == 14 && entidades.Count > 0)
                    break;

            }

            entidades.Sort((x, y) => { return x.RazaoSocial.CompareTo(y.RazaoSocial); });
            return entidades;

        }

        public List<AreaAtuacao> RecuperarAreasAtuacao()
        {
            if (AreasAtuacaoCached != null)
                return AreasAtuacaoCached;

            AreasAtuacaoCached = new List<AreaAtuacao>();

            var html = webClient.DownloadString(@"https://notaparana.pr.gov.br/nfprweb/publico/ConsultaEntidade");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var selectArea = doc.GetElementbyId("selectAreaAtuacao");
            if (selectArea == null)
                return AreasAtuacaoCached;

            var options = selectArea.SelectNodes("option");
            if (options == null)
                return AreasAtuacaoCached;

            foreach (var option in options)
            {
                var svalue = option.GetAttributeValue("value", null);
                if (string.IsNullOrEmpty(svalue))
                    continue;
                var desc = option.NextSibling == null ? string.Empty : option.NextSibling.InnerText;

                AreasAtuacaoCached.Add(new AreaAtuacao() { ID = svalue, Descricao = desc });
            }
         
            return AreasAtuacaoCached;
        }

        public bool Login(string CpfCnpj, string senha)
        { 
            //faz a chamada inicial que faz o redirect para autenticacao
            string html = webClient.DownloadString("https://notaparana.pr.gov.br/nfprweb/");

            //no redirect sao criados varios parametros que precisam ser repassados no post
            NameValueCollection qs = System.Web.HttpUtility.ParseQueryString(webClient.ResponseUri.Query);
            StringBuilder postData = new StringBuilder("step=2&tipo=");
            postData.AppendFormat("&attribute={0}&password={1}", HttpUtility.HtmlEncode(CpfCnpj), HttpUtility.HtmlEncode(senha));
            foreach (var k in qs.AllKeys)
                postData.AppendFormat("&{0}={1}", k, HttpUtility.HtmlEncode(qs[k]));

            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            html = webClient.UploadString("https://authz.identidadedigital.pr.gov.br/cidadao_authz/api/v1/authorize", postData.ToString());

            //trata o redirect do POST, pois nao é suportado pelo webclient
            while (webClient.IsRedirect())
                html = webClient.RedirectString();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);


            if(doc.GetElementbyId("user-name") == null)
                return false;

            return true;
        
        }

        public void  EncerrarSessoesAtivas()
        {
            webClient.DownloadString("https://notaparana.pr.gov.br/nfprweb/publico/sair");
        }

        public string DoarNota(string cnpj, string chave)
        {
            var htmlInicial = webClient.DownloadString("https://notaparana.pr.gov.br/nfprweb/DoacaoDocumentoFiscalCadastrar");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlInicial);
            
            var info = doc.GetElementbyId("value");

           
            if (info == null)
            {
                return doc.DocumentNode.SelectSingleNode("//div[@class='alert alert-danger full']").InnerText;                
            }

            var value = info.GetAttributeValue("value", "none");

            var postData = new StringBuilder();
            postData.Append("{'chaveAcesso':");
            postData.AppendFormat("'{0}'", chave);
            postData.Append(",'cnpjEntidade':");
            postData.AppendFormat("'{0}'", cnpj);
            postData.Append(",'documentoComChaveAcesso':'true'");
            postData.Append(",'value':");
            postData.AppendFormat("'{0}'", value);
            postData.Append("}");
            webClient.Headers.Add("X-Requested-With", "XMLHttpRequest");
            webClient.Headers.Add("Content-Type", "application/json");
            
            var html = webClient.UploadString(@"https://notaparana.pr.gov.br/nfprweb/app/v1/documentoFiscalDoadoWeb", postData.ToString());
            var response = JsonConvert.DeserializeObject<Dictionary<string,string>>(html);


            return response.FirstOrDefault().Value;

        }

        protected virtual void Dispose(bool disposing)
        {
            EncerrarSessoesAtivas();

            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                webClient.Dispose();
                webClient = null;
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    
}
