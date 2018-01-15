using DoaNotaPR.Classes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes.Memory
{
    public static class DoaNotaManagement
    {
        public static Queue<NotaFiscal> FilaPendente { get; set; }
        public static Placar Placar { get; set; }
        public static Settings Settings { get; set; }
        public static Error Error { get; set; } = new Error();
        public static string LastErrorMessage {get;set;}

        public static void IncrementarPendente()
        {
            Placar.Pendentes++;
            Placar.QtdTotal++;
        }

        public static void IncrementarEnviado(bool sucesso = true)
        {
            Placar.Pendentes--;
            if(sucesso)
            Placar.Enviadas++;
        }
    }
}
