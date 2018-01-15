using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;

namespace DoaNotaPR.Classes.Data
{
    /// <summary>
    /// Manipula estrutura do banco de dados.
    /// </summary>
    public class RepositorioNotaFiscal: IDisposable
    {
        #region Campos, propriedades e métodos privados.

        private string _stringConexaoBancodados = string.Empty;
        private SqliteConnection _conexaoBancodados = null;

        private SqliteParameter CriarParametroConsultaBancodados(SqliteCommand comando, string nomeParametro, DbType tipoParametro, object valorParametro)
        {
            var parametro = comando.CreateParameter();
            parametro.ParameterName = nomeParametro;
            parametro.DbType = tipoParametro;
            parametro.Value = valorParametro;

            return parametro;
        }

        private string RecuperarValorSituacaoDoacao(SituacaoEnvioDoacao situacaoEnvioDoacao)
        {
            switch (situacaoEnvioDoacao)
            {
                case SituacaoEnvioDoacao.Doado:
                    return "D";
                case SituacaoEnvioDoacao.Pendente:
                    return "P";
                case SituacaoEnvioDoacao.Erro:
                    return "E";
                default:
                    throw new NotSupportedException();
            }
        }

        private SituacaoEnvioDoacao ConverterStringSituacaoDoacao(string situacaoEnvioDoacao)
        {
            if (situacaoEnvioDoacao == "D")
                return SituacaoEnvioDoacao.Doado;
            else
            if (situacaoEnvioDoacao == "P")
                return SituacaoEnvioDoacao.Pendente;
            else
            if (situacaoEnvioDoacao == "E")
                return SituacaoEnvioDoacao.Erro;

            throw new NotSupportedException();
        }

        private NotaFiscal CriarNotaFiscal(SqliteDataReader leitor)
        {
            return new NotaFiscal
            {
                CNPJInstituicao = leitor.IsDBNull(leitor.GetOrdinal("cnpj_instituicao")) ? null : leitor.GetString(leitor.GetOrdinal("cnpj_instituicao")),
                Chave = leitor.GetString(leitor.GetOrdinal("chave")),
                DataEmissao = leitor.IsDBNull(leitor.GetOrdinal("dt_emissao")) ? DateTime.MinValue : leitor.GetDateTime(leitor.GetOrdinal("dt_emissao")),
                Valor = leitor.IsDBNull(leitor.GetOrdinal("dt_emissao")) ? 0.00 : leitor.GetDouble(leitor.GetOrdinal("valor")),
                DataCadastro = leitor.GetDateTime(leitor.GetOrdinal("dt_cadastro")),
                DataEnvioDoacao = leitor.IsDBNull(leitor.GetOrdinal("dt_envio_doacao")) ? DateTime.MinValue : leitor.GetDateTime(leitor.GetOrdinal("dt_envio_doacao")),
                SituacaoEnvioDoacao = ConverterStringSituacaoDoacao(leitor.GetString(leitor.GetOrdinal("situacao_envio_doacao"))),
                MensagemRetornoEnvioDoacao = leitor.IsDBNull(leitor.GetOrdinal("msg_situacao_envio_doacao")) ? null : leitor.GetString(leitor.GetOrdinal("msg_situacao_envio_doacao")),
            };
        }

        private int RecuperarQuantidadeTotalNotasFiscais(string CNPJInstituicao, string situacaoEnvioDoacao)
        {
            using (var commando = _conexaoBancodados.CreateCommand())
            {
                var comandoTextoSql = "SELECT COUNT(chave) AS TotalNotasFiscais FROM NotaFiscal WHERE 1=1";
                var comandoTextoSqlFiltroCNPJInstituicao = string.Empty;
                var comandoTextoSqlFiltroSituacao = string.Empty;

                if (!string.IsNullOrEmpty(CNPJInstituicao))
                    comandoTextoSqlFiltroCNPJInstituicao = " cnpj_instituicao = @CNPJ_INSTITUICAO";

                if (!string.IsNullOrEmpty(situacaoEnvioDoacao))
                    comandoTextoSqlFiltroSituacao = " AND situacao_envio_doacao = @SITUACAO_ENVIO_DOACAO";

                commando.CommandText = string.Concat(comandoTextoSql, comandoTextoSqlFiltroSituacao);

                if (!string.IsNullOrEmpty(CNPJInstituicao))
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CNPJ_INSTITUICAO", DbType.AnsiString, CNPJInstituicao));

                if (!string.IsNullOrEmpty(situacaoEnvioDoacao))
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@SITUACAO_ENVIO_DOACAO", DbType.AnsiStringFixedLength, situacaoEnvioDoacao));

                using (var leitor = commando.ExecuteReader())
                {
                    if (!leitor.HasRows)
                        return 0;

                    if (leitor.Read())
                        return leitor.GetInt32(leitor.GetOrdinal("TotalNotasFiscais"));
                    else
                        return 0;
                }
            }
        }

        private object ValorBancodados(object valor)
        {
            if (valor == null)
                return DBNull.Value;
            else
            if (valor is string && valor.ToString() == string.Empty)
                return DBNull.Value;
            else
            if (valor is DateTime && Convert.ToDateTime(valor) == DateTime.MinValue)
                return DBNull.Value;

            return valor;
        }

        #endregion

        #region Campos, propriedades e métodos protegidos.

        /// <summary>
        /// Liberar recursos.
        /// </summary>
        /// <param name="disposing">Liberando recursos.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_conexaoBancodados != null)
                {
                    _conexaoBancodados.Dispose();
                    _conexaoBancodados = null;
                }
            }
        }

        #endregion

        #region Campos, propriedades e métodos publicos.

        /// <summary>
        /// Construtor padrão da classe.
        /// </summary>
        /// <param name="stringConexaoBancodados">String de conexão com o banco de dados.</param>
        public RepositorioNotaFiscal(string stringConexaoBancodados)
        {
            if (stringConexaoBancodados == string.Empty)
                throw new ArgumentNullException("String de conexão com o banco de dados está em branco.", nameof(stringConexaoBancodados));

            if (stringConexaoBancodados == null)
                throw new ArgumentNullException(nameof(stringConexaoBancodados), "String de conexão com o banco de dados está nula.");

            _conexaoBancodados = new SqliteConnection(stringConexaoBancodados);
            _conexaoBancodados.Open();
        }

        /// <summary>
        /// Criar a tabela de nota fiscal no banco de dados.
        /// </summary>
        public void CriarTabelaSeNaoExistir()
        {
            using (var command = _conexaoBancodados.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS NotaFiscal(
                    chave CHAR(44) NOT NULL PRIMARY KEY,
                    cnpj_instituicao CHAR(14) NULL,
                    dt_emissao DATETIME NULL,
                    valor DOUBLE NOT NULL,
                    dt_cadastro DATETIME NOT NULL,
                    dt_envio_doacao DATETIME NULL,
                    situacao_envio_doacao CHAR(1) NOT NULL,
                    msg_situacao_envio_doacao VARCHAR(255) NULL)";
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Incluir nota fiscal.
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal.</param>
        /// <returns>Verdadeiro se a inclusão foi feita com sucesso.</returns>
        public bool Incluir(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null)
                throw new ArgumentNullException(nameof(notaFiscal), "Objeto de Nota fiscal está nulo.");

            using (var commando = _conexaoBancodados.CreateCommand())
            {
                commando.CommandText = @"INSERT INTO NotaFiscal(chave, cnpj_instituicao, dt_emissao, valor, dt_cadastro, dt_envio_doacao, situacao_envio_doacao, msg_situacao_envio_doacao)
                    VALUES
                    (@CHAVE, @CNPJ_INSTITUICAO, @DT_EMISSAO, @VALOR, @DT_CADASTRO, @DT_ENVIO_DOACAO, @SITUACAO_ENVIO_DOACAO, @MSG_SITUACAO_ENVIO_DOACAO)";

                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CHAVE", DbType.AnsiString, ValorBancodados(notaFiscal.Chave)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CNPJ_INSTITUICAO", DbType.AnsiString, ValorBancodados(notaFiscal.CNPJInstituicao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_EMISSAO", DbType.DateTime, ValorBancodados(notaFiscal.DataEmissao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@VALOR", DbType.Double, ValorBancodados(notaFiscal.Valor)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_CADASTRO", DbType.DateTime, ValorBancodados(notaFiscal.DataCadastro)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_ENVIO_DOACAO", DbType.DateTime, ValorBancodados(notaFiscal.DataEnvioDoacao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@SITUACAO_ENVIO_DOACAO", DbType.AnsiStringFixedLength, ValorBancodados(RecuperarValorSituacaoDoacao(notaFiscal.SituacaoEnvioDoacao))));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@MSG_SITUACAO_ENVIO_DOACAO", DbType.AnsiString, ValorBancodados(notaFiscal.MensagemRetornoEnvioDoacao)));

                return commando.ExecuteNonQuery() != -1;
            }
        }

        /// <summary>
        /// Atualizar nota fiscal.
        /// </summary>
        /// <param name="notaFiscal">Nota fiscal.</param>
        /// <returns>Verdadeiro se a atualização foi feita com sucesso.</returns>
        public bool Atualizar(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null)
                throw new ArgumentNullException(nameof(notaFiscal), "Objeto de Nota fiscal está nulo.");

            using (var commando = _conexaoBancodados.CreateCommand())
            {
                commando.CommandText = @"UPDATE NotaFiscal SET cnpj_instituicao = @CNPJ_INSTITUICAO, dt_emissao = @DT_EMISSAO, valor = @VALOR, dt_cadastro = @DT_CADASTRO, 
                    dt_envio_doacao = @DT_ENVIO_DOACAO, situacao_envio_doacao = @SITUACAO_ENVIO_DOACAO, msg_situacao_envio_doacao = @MSG_SITUACAO_ENVIO_DOACAO
                    WHERE chave = @CHAVE";

                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CNPJ_INSTITUICAO", DbType.AnsiString, ValorBancodados(notaFiscal.CNPJInstituicao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_EMISSAO", DbType.DateTime, ValorBancodados(notaFiscal.DataEmissao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@VALOR", DbType.Double, ValorBancodados(notaFiscal.Valor)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_CADASTRO", DbType.DateTime, ValorBancodados(notaFiscal.DataCadastro)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_ENVIO_DOACAO", DbType.DateTime, ValorBancodados(notaFiscal.DataEnvioDoacao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@SITUACAO_ENVIO_DOACAO", DbType.AnsiStringFixedLength, ValorBancodados(RecuperarValorSituacaoDoacao(notaFiscal.SituacaoEnvioDoacao))));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@MSG_SITUACAO_ENVIO_DOACAO", DbType.AnsiString, ValorBancodados(notaFiscal.MensagemRetornoEnvioDoacao)));
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CHAVE", DbType.AnsiString, ValorBancodados(notaFiscal.Chave)));

                return commando.ExecuteNonQuery() != -1;
            }
        }

        /// <summary>
        /// Remover os últimos N dias.
        /// </summary>
        /// <param name="ultimosNDias">Últimos N dias.</param>
        public void Remover(int ultimosNDias)
        {
            using (var commando = _conexaoBancodados.CreateCommand())
            {
                var dataRemocao = DateTime.Now.AddDays(-ultimosNDias);

                commando.CommandText = "DELETE FROM NotaFiscal WHERE dt_cadastro <= @DT_REMOCAO";
                commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_REMOCAO", DbType.DateTime, dataRemocao));

                commando.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Recuperar lista de notas fiscais.
        /// </summary>
        /// <param name="CNPJInstituicao">CNPJ da instituição.</param>
        /// <param name="dataInicial">Data inicial para recuperar as notas fiscais.</param>
        /// <param name="dataFinal">Data final para recuperar as notas fiscais.</param>
        /// <returns>Lista de notas fiscais.</returns>
        public List<NotaFiscal> RecuperarNotasFiscais(string CNPJInstituicao, DateTime dataInicial, DateTime dataFinal, SituacaoEnvioDoacao situacaoEnvioDoacao)
        {
            using (var commando = _conexaoBancodados.CreateCommand())
            {
                var comandoTextoSql = "SELECT * FROM NotaFiscal WHERE 1=1";
                var comandoTextoSqlFiltroCNPJ = string.Empty;
                var comandoTextoSqlFiltroDataInicial = string.Empty;
                var comandoTextoSqlFiltroDataFinal = string.Empty;
                var comandoTextoSqlFiltroSituacaoEnvioDoacao = string.Empty;

                if (!string.IsNullOrEmpty(CNPJInstituicao))
                    comandoTextoSqlFiltroCNPJ = " AND cnpj_instituicao = @CNPJ_INSTITUICAO";

                if (dataInicial != DateTime.MinValue)
                    comandoTextoSqlFiltroDataInicial = " AND DATE(dt_cadastro) >= @DT_INICIAL";

                if (dataInicial != DateTime.MinValue)
                    comandoTextoSqlFiltroDataFinal = " AND DATE(dt_cadastro) <= @DT_FINAL";

                if (Enum.IsDefined(typeof(SituacaoEnvioDoacao), situacaoEnvioDoacao) && situacaoEnvioDoacao != SituacaoEnvioDoacao.Todas)
                    comandoTextoSqlFiltroSituacaoEnvioDoacao = " AND situacao_envio_doacao = @SITUACAO_ENVIO_DOACAO";

                commando.CommandText = string.Concat(comandoTextoSql, comandoTextoSqlFiltroCNPJ, comandoTextoSqlFiltroDataInicial, comandoTextoSqlFiltroDataFinal, comandoTextoSqlFiltroSituacaoEnvioDoacao," ORDER BY dt_cadastro DESC");

                if (!string.IsNullOrEmpty(CNPJInstituicao))
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@CNPJ_INSTITUICAO", DbType.AnsiString, CNPJInstituicao));

                if (dataInicial != DateTime.MinValue)
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_INICIAL", DbType.DateTime, dataInicial.ToString("yyyy-MM-dd")));

                if (dataFinal != DateTime.MinValue)
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@DT_FINAL", DbType.DateTime, dataFinal.ToString("yyyy-MM-dd")));

                if (Enum.IsDefined(typeof(SituacaoEnvioDoacao), situacaoEnvioDoacao) && situacaoEnvioDoacao != SituacaoEnvioDoacao.Todas)
                    commando.Parameters.Add(CriarParametroConsultaBancodados(commando, "@SITUACAO_ENVIO_DOACAO", DbType.AnsiStringFixedLength, RecuperarValorSituacaoDoacao(situacaoEnvioDoacao)));

                var listaNotasFiscais = new List<NotaFiscal>();

                using (var leitor = commando.ExecuteReader())
                {
                    if (!leitor.HasRows)
                        return null;

                    while (leitor.Read())
                        listaNotasFiscais.Add(CriarNotaFiscal(leitor));
                }

                return listaNotasFiscais;
            }
        }

        /// <summary>
        /// Recuperar a quantidade de notas fiscais.
        /// </summary>
        /// <param name="CNPJInstituicao">CNPJ da instituição.</param>
        /// <param name="situacaoEnvioDoacao">Situação da doação.</param>
        /// <returns></returns>
        public int RecuperarQuantidadeTotalNotasFiscais(string CNPJInstituicao, SituacaoEnvioDoacao situacaoEnvioDoacao)
        {
            var situacaoEnvioDoacaoInterna = RecuperarValorSituacaoDoacao(situacaoEnvioDoacao);

            return RecuperarQuantidadeTotalNotasFiscais(CNPJInstituicao, situacaoEnvioDoacaoInterna);
        }

        /// <summary>
        /// Recuperar informações com as quantidades das notas fiscais.
        /// </summary>
        /// <param name="CNPJInstituicao">CNPJ da instituição.</param>
        /// <returns>Informações com as quantidades das notas fiscais.</returns>
        public InfoQuantidadesNotasFiscais RecuperarInfoQuantidadeNotaFiscais(string CNPJInstituicao)
        {
            return new InfoQuantidadesNotasFiscais
            {
                QuantidadeTotal = RecuperarQuantidadeTotalNotasFiscais(CNPJInstituicao, string.Empty),
                QuantidadeEnviadas = RecuperarQuantidadeTotalNotasFiscais(CNPJInstituicao, SituacaoEnvioDoacao.Doado),
                QuantidadePendentes = RecuperarQuantidadeTotalNotasFiscais(CNPJInstituicao, SituacaoEnvioDoacao.Pendente),
            };
        }

        /// <summary>
        /// Recuperar os CNPJ's das instituições que possuem notas na tabela.
        /// </summary>
        /// <returns>CNPJ's das instituições que possuem notas na tabela.</returns>
        public List<string> RecuperarCNPJsInstituicoes()
        {
            using (var commando = _conexaoBancodados.CreateCommand())
            {
                commando.CommandText = "SELECT DISTINCT cnpj_instituicao FROM NotaFiscal ORDER BY cnpj_instituicao";

                var listaNotasFiscais = new List<string>();

                using (var leitor = commando.ExecuteReader())
                {
                    if (!leitor.HasRows)
                        return null;

                    while (leitor.Read())
                    {
                        if(!leitor.IsDBNull(leitor.GetOrdinal("cnpj_instituicao")))
                            listaNotasFiscais.Add(leitor.GetString(leitor.GetOrdinal("cnpj_instituicao")));
                    }
                }

                return listaNotasFiscais;
            }
        }

        /// <summary>
        /// Liberar recursos.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}