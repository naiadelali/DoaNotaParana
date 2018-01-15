using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoaNotaPR.Classes
{
    public class Utils
    {
        public string RemoveFormat(string text, int maxSize)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            var info = digitsOnly.Replace(text, string.Empty);

            if (info.Length > maxSize)
            {
                info = info.Substring(0, maxSize);
            }

            return info;
        }
    }
}
