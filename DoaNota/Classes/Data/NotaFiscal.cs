using System;

namespace DoaNotaPR.Classes.Data
{
    /// <summary>
    /// Nota fiscal.
    /// </summary>
    public class NotaFiscal
    {
        /// <summary>
        /// Chave da nota fiscal.
        /// </summary>
        [System.ComponentModel.DisplayName("Chave        ")]
        public string Chave { get; set; }

        /// <summary>
        /// Situação de envio para doação.
        /// </summary>
        [System.ComponentModel.DisplayName("Situação")]
        public SituacaoEnvioDoacao SituacaoEnvioDoacao { get; set; }

        /// <summary>
        /// Data emissão.
        /// </summary>
        [System.ComponentModel.DisplayName("Data da emissão")]
        public DateTime DataEmissao { get; set; }

        /// <summary>
        /// Data de cadastro para doação.
        /// </summary>
        [System.ComponentModel.DisplayName("Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Data de envio para doação.
        /// </summary>
        [System.ComponentModel.DisplayName("Data de doação")]
        public DateTime DataEnvioDoacao { get; set; }

        /// <summary>
        /// Valor da nota fiscal.
        /// </summary>
        [System.ComponentModel.DisplayName("Valor da nota")]
        public double Valor { get; set; }

        /// <summary>
        /// CNPJ do emissor.
        /// </summary>
        [System.ComponentModel.DisplayName("CNPJ do Emissor")]
        public string CNPJEmissor
        {
            get
            {
                if (Chave != null && Chave.Length == 44)
                    return Chave.Substring(6, 14);
                return string.Empty;
            }
        }


        /// <summary>
        /// CNPJ da instituição.
        /// </summary>
        [System.ComponentModel.DisplayName("CNPJ Entidade")]
        public string CNPJInstituicao { get; set; }

       

        /// <summary>
        /// Mensagem de retorno do envio para doação.
        /// </summary>
        [System.ComponentModel.DisplayName("Mensagem de retorno")]
        public string MensagemRetornoEnvioDoacao { get; set; }
    }
}
