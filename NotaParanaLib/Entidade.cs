using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotaParanaLib
{
    public class Entidade
    {
        [Newtonsoft.Json.JsonProperty("numCNPJ")]
        public string CNPJ { get; set; }
        [Newtonsoft.Json.JsonProperty("nomeEmpresarial")]
        public string RazaoSocial { get; set; }
        [Newtonsoft.Json.JsonProperty("nomeFantasia")]
        public string NomeFantasia { get; set; }

        public override string ToString()
        {
            return $"{RazaoSocial} - CNPJ:{CNPJ}";
        }
    }
}
