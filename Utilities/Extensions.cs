using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Extensions
    {
        public static string ToUrl(this string text)
        {
            string result = text.ToLower().Trim();
            result = result.Replace("ş", "s")
                           .Replace("ı", "i")
                           .Replace("ğ", "g")
                           .Replace("ç", "c")
                           .Replace("ö", "o")
                           .Replace("ü", "u");
            result = Regex.Replace(result, @"[^\w\s]", "");
            result = Regex.Replace(result, @"\s+", " ").Trim();
            return result.Replace(" ", "-");
        }
    }
}
