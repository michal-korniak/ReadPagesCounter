using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadPagesCounter.Extensions
{
    public static  class StringExtensions
    {
        public static string SubstringBetween(this string str, string from, string to)
        {
            int indexFrom = str.IndexOf(from) + from.Length;
            int indexTo = str.LastIndexOf(to);

            return str.Substring(indexFrom, indexTo - indexFrom);
        }
    }
}
