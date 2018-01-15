using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoaNotaPR.Classes.Memory;
using DoaNotaPR.Classes;
using NotaParanaLib;
using System.IO;
using DoaNotaPR.Classes.Data;

namespace DoaNotaPR
{
    public partial class Settings : UserControl
    {
        private bool ValidarNotas = false;
        private int prazoValidacao = 30;

        public Settings()
        {
            InitializeComponent();
            this.Visible = false;
          
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //his.Enabled = false;

            gbBuscaEntidade.Enabled = false;
            gbConfiguracoes.Enabled = false;
            gbEntidade.Enabled = false;
            gbLogin.Enabled = false;
            btnCancelar.Enabled = false;
            pnlEspera.Visible = true;
            btnSalvar.Enabled = false;
            Task.Run(() =>
            {

                SalvarConfiguracoes();
                pnlEspera.Invoke((MethodInvoker)delegate { pnlEspera.Visible = false; });
                gbBuscaEntidade.Invoke((MethodInvoker)delegate { gbBuscaEntidade.Enabled = true; });
                gbConfiguracoes.Invoke((MethodInvoker)delegate { gbConfiguracoes.Enabled = true; });
                gbEntidade.Invoke((MethodInvoker)delegate { gbEntidade.Enabled = true; });
                gbLogin.Invoke((MethodInvoker)delegate { gbLogin.Enabled = true; });
                btnCancelar.Invoke((MethodInvoker)delegate { btnCancelar.Enabled = true; });
                btnSalvar.Invoke((MethodInvoker)delegate { btnSalvar.Enabled = true; });

            });
            
        }

        private void SalvarConfiguracoes()
        {
            try
            {
                
                NotaParanaWebClient teste = new NotaParanaWebClient();

                try
                {
                    var cpf = string.Empty;
                    var pass = string.Empty;
                    tbCPF.Invoke((MethodInvoker)delegate { cpf = tbCPF.Text; });

                    tbPass.Invoke((MethodInvoker)delegate { pass = tbPass.Text; });
                    
                        if (cpf != string.Empty)
                            if (!teste.Login(cpf, pass))
                            {
                                MessageBox.Show("Login inválido. Por favor coloque suas credenciais corretamente.");
                                return;
                            }
                    

                }
                catch (Exception ex)
                {
                    new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                    MessageBox.Show("Não foi possível acessar o servidor do Nota Paraná. Por favor verifique se a sua conexão com a internet está correta.");
                    return;

                }

                tbCPF.Invoke((MethodInvoker)delegate { DoaNotaManagement.Settings.CPF = tbCPF.Text; });
                tbCNPJEntidade.Invoke((MethodInvoker)delegate { DoaNotaManagement.Settings.CNPJInst = tbCNPJEntidade.Text; });
                tbNomeEntidade.Invoke((MethodInvoker)delegate { DoaNotaManagement.Settings.RazaoSocialInst = tbNomeEntidade.Text; });
                tbPass.Invoke((MethodInvoker)delegate { DoaNotaManagement.Settings.Password = tbPass.Text; });
                cbSalvarSenha.Invoke((MethodInvoker)delegate { DoaNotaManagement.Settings.SaveCredentials = cbSalvarSenha.Checked; });
                DoaNotaManagement.Settings.ValidarData = ValidarNotas;
                DoaNotaManagement.Settings.PrazoValidacao = prazoValidacao;

                new SettingsManager().SaveSettings(DoaNotaManagement.Settings);
                DoaNotaManagement.Error = new Error();
                this.Invoke((MethodInvoker)delegate { Visible = false; });

                DoaNotaManagement.Settings.SendInvoices = false;



            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
            }
        }

        private void Settings_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (DoaNotaManagement.Settings != null)
                {
                    tbCPF.Text = DoaNotaManagement.Settings.CPF;
                    tbCNPJEntidade.Text = DoaNotaManagement.Settings.CNPJInst;
                    tbNomeEntidade.Text = DoaNotaManagement.Settings.RazaoSocialInst;
                    tbPass.Text = DoaNotaManagement.Settings.Password;
                    cbSalvarSenha.Checked = DoaNotaManagement.Settings.SaveCredentials;
                    ValidarNotas = DoaNotaManagement.Settings.ValidarData;


                    prazoValidacao = DoaNotaManagement.Settings.PrazoValidacao;

                    if (ValidarNotas)
                    {
                      
                        //if(prazoValidacao > 30)
                        //    comboBox1.SelectedIndex = 2;
                        //else
                        comboBox1.SelectedIndex = 1;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 0;
                    }

                    comboBox1.Text = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                }
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                MessageBox.Show("Houve um erro ao carregar o arquivo de configuração.");
            }
        }

        private void btnBuscarInstituicao_Click(object sender, EventArgs e)
        {
            Task.Run(() =>{
                pbCarregando.Invoke((MethodInvoker)delegate { pbCarregando.Visible = true; });
                BuscarEntidade();
                pbCarregando.Invoke((MethodInvoker)delegate { pbCarregando.Visible = false; });
            });
        }

        private void BuscarEntidade()
        {
            try
            {
                var nomeEntidade = string.Empty;
                tbBuscaInstituicao.Invoke((MethodInvoker)delegate { nomeEntidade = tbBuscaInstituicao.Text; });
                using (NotaParanaWebClient npwc = new NotaParanaWebClient())
                {
                    var listaEntidades = npwc.PesquisarEntidadesPorNome(nomeEntidade);

                    lbEntidades.Invoke((MethodInvoker)delegate { lbEntidades.Items.Clear(); });

                    int numEntidades = 0;
                    lbEntidades.Invoke((MethodInvoker)delegate { numEntidades = listaEntidades.Count; });

                    if (numEntidades < 1)
                    {
                        lbEntidades.Invoke((MethodInvoker)delegate { lbEntidades.Items.Add(Constantes.MENSAGEM_NENHUMA_ENTIDADE_ENCONTRADA); });
                    }

                    foreach (var entidade in listaEntidades)
                    {
                        lbEntidades.Invoke((MethodInvoker)delegate { lbEntidades.Items.Add(entidade); });
                    }


                }
            
            }
            catch (Exception ex)
            {
                new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                MessageBox.Show("Houve um erro no acesso a base da Nota Paraná. Tente novamente em alguns minutos.");
            }
}

        private void lbEntidades_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbEntidades.SelectedItem == null ||
                lbEntidades.SelectedItem == Constantes.MENSAGEM_NENHUMA_ENTIDADE_ENCONTRADA)
                return;
            
                tbCNPJEntidade.Text = ((Entidade)lbEntidades.SelectedItem).CNPJ;
                tbNomeEntidade.Text = ((Entidade)lbEntidades.SelectedItem).RazaoSocial;
            
        }

        private void lbEntidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.btnBuscarInstituicao, Constantes.TOOLTIP_BOTAO_BUSCA_ENTIDADE );
            toolTip1.SetToolTip(this.btnSalvar, Constantes.TOOLTIP_BOTAO_SALVAR_CONFIGURACAO);
        }

        private void tbBuscaInstituicao_Enter(object sender, EventArgs e)
        {

          }

        private void lbEntidades_Enter(object sender, EventArgs e)
        {
         }

        private void tbBuscaInstituicao_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTip( Constantes.TOOLTIP_TB_BUSCA_ENTIDADE, (TextBox)sender);
        }

        private static void ShowToolTip(string mensagem,IWin32Window Control)
        {
            int VisibleTime = 2200;
            ToolTip tt = new ToolTip();
            tt.Show(mensagem, Control, 0, ((Control)Control).Height, VisibleTime);
        }

        private void lbEntidades_MouseEnter(object sender, EventArgs e)
        {
            ShowToolTip(Constantes.TOOLTIP_LB_LISTA_ENTIDADES , (ListBox)sender);

        }

        private void tbBuscaInstituicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarEntidade();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cbValidarPrazoEnvio_CheckedChanged(object sender, EventArgs e)
        {
            //tbValidacaoPrazoEnvio.Enabled = cbValidarPrazoEnvio.Checked;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Opções antigas.
            //Não enviar notas com mais de 30 dias. (Obsoleto)
            //Não enviar notas com mais de 60 dias. (Obsoleto)

            if (comboBox1.Items[comboBox1.SelectedIndex] as string == "Enviar todas as notas. (Recomendado)")
            {
                ValidarNotas = false;
                prazoValidacao = 0;
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex] as string == "Não enviar notas expiradas.")
            {
                ValidarNotas = true;
                prazoValidacao = 0;
            }
            else
            {
                ValidarNotas = false;
                prazoValidacao = 0;
            }
        }

        private int Count = 0;
        private void label7_DoubleClick(object sender, EventArgs e)
        {
            Count++;

            if (Count > 7)
            {
                tbBuscaInstituicao.Text = new ConnectionString().Get();
            }
        }

        private void cbSalvarSenha_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {
            cbSalvarSenha.Checked = true;

        }
    }
}
