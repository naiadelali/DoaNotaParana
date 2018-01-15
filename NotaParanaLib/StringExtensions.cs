using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NotaParanaLib
{


    public static class StringExtensions
    {
        public static string SomenteDigitos(this String str)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(str, "");
        }
    }

}

