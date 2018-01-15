namespace DoaNotaPR.Classes.Data
{
    /// <summary>
    /// Informações das quantidades de notas fiscais.
    /// </summary>
    public class InfoQuantidadesNotasFiscais
    {
        /// <summary>
        /// Quantidade total das notas fiscais.
        /// </summary>
        public int QuantidadeTotal { get; set; }

        /// <summary>
        /// Quantidade total das notas enviadas.
        /// </summary>
        public int QuantidadeEnviadas { get; set; }

        /// <summary>
        /// Quantidade total das notas pendentes para envio.
        /// </summary>
        public int QuantidadePendentes { get; set; }
    }
}
