using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes
{
    public class Constantes
    {
        public static readonly string MENSAGEM_ERRO_SESSAO_ATIVA = "O usuário autenticado possui mais de uma sessão ativa";
        public static readonly string MENSAGEM_SUCESSO_DOACAO = "Documento fiscal doado com sucesso!";
        public static readonly string  MENSAGEM_NENHUMA_ENTIDADE_ENCONTRADA = "Nenhuma entidade encontrada.";
        public static readonly string MENSAGEM_CNPJ_ENTIDADE_INCORRETO = "O CNPJ da instituição está incorreto. Por favor corrija o CNPJ com a instituição correta.";
        public static readonly string MENSAGEM_CAMPOS_CONFIG_NULOS = "É necessário preencher os campos de usuário, senha e CNPJ da entidade corretamente. Acesse as configurações para configurar corretamente.";
        public static readonly string MENSAGEM_USUARIO_SENHA_INCORRETOS = "O usuário/senha estão inválidos por favor entre novamente com os dados no menu \"Configurações\".";
        internal static readonly string MENSAGEM_SENHA_EXPIRADA = "A senha está expirada, por favor acesse o portal da Nota Paraná no seu browser.";
        internal static readonly string MENSAGEM_ERRO_DESCONHECIDO_PORTAL = "Houve um erro no acesso ao portal da Nota Paraná.";
        internal static readonly string MENSAGEM_ERRO_COMUNICACAO = "Houve um erro na comunicação com o servidor. Tente novamente mais tarde.";
        internal static readonly string MENSAGEM_IMPOSSIVEL_ACESSO_PORTAL = "Não foi possível acessar o portal da Nota Paraná. Acesse o portal pelo browser para verificar se existe algum problema.";
        internal static readonly string MENSAGEM_ERRO_INESPERADO = "Erro inesperado.";
        internal static readonly string TOOLTIP_BOTAO_EXPORTAR = "Exporte as informações filtradas para um arquivo csv (Planilha).";
        internal static readonly string MENSAGEM_ERRO_BANCO_DE_DADOS = "Erro ao gravar as informações no banco de dados.";
        internal static readonly string TOOLTIP_BOTAO_FECHAR_GRID = "Fechar o histórico das doações.";
        internal static readonly string MENSAGEM_NOTA_CADASTRADA = "Nota já cadastrada.";
        internal static readonly string MENSAGEM_NOTA_EXPIRADA_VALIDACAO = "Prazo para envio expirado.";
        internal static readonly string MENSAGEM_ERRO_LEITURA_QRCODE = "Erro na leitura.";
        internal static readonly string MENSAGEM_ERRO_CONSUMIDOR_INFORMADO = "Nota com consumidor informado.";
        internal static readonly string TOOLTIP_BOTAO_ATUALIZAR_CAMERAS_DISPONIVEIS = "Atualize a lista de cameras disponíveis";
        internal static readonly string TOOLTIP_BOTAO_ADICIONAR_MANUAL = "Adicionar nota manualmente.";
        internal static readonly string TOOLTIP_BOTAO_BUSCA_ENTIDADE= "Clique aqui para efetuar a busca.";
        internal static readonly string TOOLTIP_BOTAO_SALVAR_CONFIGURACAO = "Clique aqui para salvar as configurações.";
        internal static readonly string TOOLTIP_TB_BUSCA_ENTIDADE = "Digite aqui o nome da entidade para qual voce deseja doar. Depois clique na lupa para efetuar a busca.";
        internal static readonly string TOOLTIP_LB_LISTA_ENTIDADES = "Selecione aqui a entidade a qual deseja doar. Ao clicar na entidade automáticamente irá alterar no menu abaixo a entidade escolhida.";
    }
}
