using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoaNotaPR
{
    public  class ExceptionFileHandler
    {
        public  void CreateCrashFile(string ex)
        {
            var localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            File.WriteAllText($"{localPath}\\excp.dat", ex);
        }
        

    }
}
