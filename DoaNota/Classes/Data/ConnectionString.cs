using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes.Data
{
    public class ConnectionString
    {

        public string Get()
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return $"Data Source={localPath}\\DoaNota.db";
        }
    }
}
