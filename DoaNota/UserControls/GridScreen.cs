using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoaNotaPR.Classes.Data;
using DoaNotaPR.Classes;
using System.IO;
//using SageDoaNotaPR.Classes.Data;

namespace DoaNotaPR.UserControls
{
    public partial class GridScreen : UserControl
    {

        public GridScreen()
        {
            InitializeComponent();
            this.Visible = false;
        }
        private SituacaoEnvioDoacao GetSelectedSituacao()
        {
            if (cbFiltroSituacao.Text == "Todas")
                return SituacaoEnvioDoacao.Todas;
            if (cbFiltroSituacao.Text == "Doado")
                return SituacaoEnvioDoacao.Doado;
            if (cbFiltroSituacao.Text == "Pendente")
                return SituacaoEnvioDoacao.Pendente;
            return SituacaoEnvioDoacao.Erro;
        }
        private void GridScreen_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

            dtpFiltroDataInicial.Value = DateTime.Now.AddMonths(-1);
            dtpFiltroDataFinal.Value = DateTime.Now;
            cbFiltroSituacao.SelectedIndex = 0;
            cbCNPJInstituicoes.Items.Clear();
            cbCNPJInstituicoes.Items.Add("Todas");
            
            using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
            {
                var listCNPJ = BD.RecuperarCNPJsInstituicoes();

                if (listCNPJ != null)
                {
                    foreach (var cnpj in listCNPJ)
                    {
                        cbCNPJInstituicoes.Items.Add(cnpj);
                    }
                }
            }

            cbCNPJInstituicoes.SelectedIndex = 0;
            UpdateGrid();


            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.btnExportar, Constantes.TOOLTIP_BOTAO_EXPORTAR );
            toolTip1.SetToolTip(this.btnFechar, Constantes.TOOLTIP_BOTAO_FECHAR_GRID);

        }
        bool Atualizando = false;

        private void UpdateGrid()
        {
            if (DesignMode)
                return;

            lock (this)
            {
                Atualizando = true;
            }
            Task t = Task.Run(() =>
            {
                object dataSource = null;
                try
                {
                    pbCarregando.Invoke((MethodInvoker)delegate { pbCarregando.Visible = true; });
                    dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = null; });
                    
                    using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
                    {
                        string cNPJInst = "Todas";
                        cbCNPJInstituicoes.Invoke((MethodInvoker)delegate { cNPJInst = (string)cbCNPJInstituicoes.SelectedItem; });
                        
                      var cnpj =(cNPJInst == "Todas" ? null : cNPJInst);

                        DateTime dataInicial = DateTime.Now;
                        DateTime dataFinal = DateTime.Now;
                        SituacaoEnvioDoacao situacao = SituacaoEnvioDoacao.Todas;

                        dtpFiltroDataInicial.Invoke((MethodInvoker)delegate { dataInicial = dtpFiltroDataInicial.Value; });
                        dtpFiltroDataFinal.Invoke((MethodInvoker)delegate { dataFinal = dtpFiltroDataFinal.Value; });
                        cbFiltroSituacao.Invoke((MethodInvoker)delegate { situacao = GetSelectedSituacao(); });

                        var pendentes = BD.RecuperarNotasFiscais(cnpj, dataInicial, dataFinal, situacao);

                        dataSource = pendentes;
                    }

                    
                if (dataSource == null)
                    {
                        dataSource = GetResultsTable();

                    }

                    if (Atualizando)
                    {
                        dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = dataSource; });
                    }
                    lock (this)
                    {
                        Atualizando = false;
                    }

                    if (dataGridView1.DataSource != null && dataGridView1.Columns.Count > 1)
                    {
                        dataGridView1.Invoke((MethodInvoker)delegate { this.dataGridView1.Columns["Valor"].DefaultCellStyle.Format = "C"; });

                        dataGridView1.Invoke((MethodInvoker)delegate { this.dataGridView1.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; });
                    }
                    pbCarregando.Invoke((MethodInvoker)delegate { pbCarregando.Visible = false; });

                }
                catch (Exception ex)
                {
                    new ExceptionFileHandler().CreateCrashFile($"{ex.ToString()}");
                }
            });
        }

        public DataTable GetResultsTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Não foi encontrado nenhum registro para os filtros informados!");

            return table;
        }
      

        private void Filter_Changed(object sender, EventArgs e)
        {
        }

        private void ExportData_Click_1(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("sep =,");
            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".csv";
            saveFileDialog1.Filter = "Comma Separated Values File (*.csv)|*.csv";
            
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                //using (var stream = saveFileDialog1.OpenFile())
                try
                {
                    using (var sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                    {
                        sw.WriteLine(sb.ToString());
                    }
                }

                catch(Exception ex)
                {
                    new ExceptionFileHandler().CreateCrashFile($"{ex.ToString()}");
                    MessageBox.Show("Houve um erro ao salvar o arquivo. Verifique se existe outro programa utilizando o arquivo ou se o programa tem permissão para salvar nesta pasta.", "Doa Nota Paraná",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                //using (var writer = new System.IO.StreamWriter(stream, false, Encoding.UTF8))
                //{
                //    writer.WriteLine(sb.ToString());
                //}
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
