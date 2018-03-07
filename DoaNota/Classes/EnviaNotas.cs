using NotaParanaLib;
using DoaNotaPR.Classes.Data;
using DoaNotaPR.Classes.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes
{
 
    public class EnviaNotas
    {
        private System.ComponentModel.BackgroundWorker WorkerEnviaNotas = new System.ComponentModel.BackgroundWorker();

        public void Start()
        {
            if (!WorkerEnviaNotas.IsBusy)
                WorkerEnviaNotas.RunWorkerAsync();
        }

        public void Cancel()
        {
            if (WorkerEnviaNotas.IsBusy)
                WorkerEnviaNotas.CancelAsync();
        }


        public EnviaNotas()
        {
            WorkerEnviaNotas.DoWork += WorkerEnviaNotas_DoWork;
            WorkerEnviaNotas.WorkerSupportsCancellation = true;
            WorkerEnviaNotas.RunWorkerAsync();
        }
        
        private void WorkerEnviaNotas_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                while (!WorkerEnviaNotas.CancellationPending)
                {
                    while (DoaNotaManagement.FilaPendente == null ||
                        DoaNotaManagement.FilaPendente.Count == 0 ||
                        !DoaNotaManagement.Settings.SendInvoices)
                    {
                        Thread.Sleep(100);
                        if (WorkerEnviaNotas.CancellationPending)
                        {
                            return;
                        }
                    }


                    if (string.IsNullOrEmpty(DoaNotaManagement.Settings.CPF) ||
                    string.IsNullOrEmpty(DoaNotaManagement.Settings.Password) ||
                    string.IsNullOrEmpty(DoaNotaManagement.Settings.CNPJInst))
                    {
                        DoaNotaManagement.Settings.SendInvoices = false;
                        DoaNotaManagement.Settings.SendInvoices = false;
                        DoaNotaManagement.Error.IsThereAnError = true;
                        DoaNotaManagement.Error.LastError = Constantes.MENSAGEM_CAMPOS_CONFIG_NULOS;
                        return;
                    }

                    using (NotaParanaWebClient wcpr = new NotaParanaWebClient())
                    {


                        var login = wcpr.Login(DoaNotaManagement.Settings.CPF, DoaNotaManagement.Settings.Password);

                        if (!login)
                        {
                            DoaNotaManagement.Settings.SendInvoices = false;
                            DoaNotaManagement.Settings.SendInvoices = false;
                            DoaNotaManagement.Error.IsThereAnError = true;
                            DoaNotaManagement.Error.LastError = Constantes.MENSAGEM_USUARIO_SENHA_INCORRETOS;
                            return;
                        }

                        while (DoaNotaManagement.FilaPendente.Count > 0)

                        {
                            if (WorkerEnviaNotas.CancellationPending)
                            {
                                return;
                            }

                            var notaEnviar = DoaNotaManagement.FilaPendente.Peek();

                            notaEnviar.CNPJInstituicao = DoaNotaManagement.Settings.CNPJInst;

                            notaEnviar.MensagemRetornoEnvioDoacao = wcpr.DoarNota(new Utils().RemoveFormat(DoaNotaManagement.Settings.CNPJInst, 14), notaEnviar.Chave);
                           
                            if (notaEnviar.MensagemRetornoEnvioDoacao.Contains(Constantes.MENSAGEM_ERRO_SESSAO_ATIVA))
                            {
                                wcpr.EncerrarSessoesAtivas();
                                wcpr.Login(DoaNotaManagement.Settings.CPF, DoaNotaManagement.Settings.Password);
                                notaEnviar.MensagemRetornoEnvioDoacao = wcpr.DoarNota(new Utils().RemoveFormat(DoaNotaManagement.Settings.CNPJInst, 14), notaEnviar.Chave);

                            }


                            if (notaEnviar.MensagemRetornoEnvioDoacao.Contains(Constantes.MENSAGEM_SUCESSO_DOACAO))
                            {
                                DoaNotaManagement.IncrementarEnviado(true);
                                notaEnviar.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Doado;
                                DoaNotaManagement.FilaPendente.Dequeue();
                            }
                            else
                            {
                                DoaNotaManagement.IncrementarEnviado(false);
                                notaEnviar.SituacaoEnvioDoacao = SituacaoEnvioDoacao.Erro;
                                DoaNotaManagement.FilaPendente.Dequeue();
                            }

                            using (RepositorioNotaFiscal BD = new RepositorioNotaFiscal(new ConnectionString().Get()))
                            {
                                notaEnviar.DataEnvioDoacao = DateTime.Now;
                                notaEnviar.CNPJInstituicao = new Utils().RemoveFormat(DoaNotaManagement.Settings.CNPJInst, 14);
                                if (!BD.Atualizar(notaEnviar))
                                {
                                    DoaNotaManagement.Settings.SendInvoices = false;
                                    DoaNotaManagement.Settings.SendInvoices = false;
                                    DoaNotaManagement.Error.IsThereAnError = true;
                                    DoaNotaManagement.Error.LastError = Constantes.MENSAGEM_ERRO_BANCO_DE_DADOS;
                                    return;
                                }
                            }
                        }

                    }

                    Thread.Sleep(0);
                }
            }
            catch (Exception ex)
            {
               new ExceptionFileHandler().CreateCrashFile(ex.ToString());
                DoaNotaManagement.Settings.SendInvoices = false;
                DoaNotaManagement.Settings.SendInvoices = false;
                DoaNotaManagement.Error.IsThereAnError = true;
                DoaNotaManagement.Error.LastError = Constantes.MENSAGEM_ERRO_INESPERADO;
                return;
            }
        }
    }
}
