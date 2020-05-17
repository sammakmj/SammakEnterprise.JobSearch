using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SammakEnterprise.JobSearch.Api.Util
{
    public class Utilities
    {

        public static string ConcatenateWords(params string[] words)
        {
            var result = "";
            if (words != null && words.Length > 0)
            {
                foreach (var word in words)
                {
                    result += word + " ";
                }
                // drop the last space
                result = result.TrimEnd();
            }
            return result;
        }

        public static string ReplaceDashesWithSpaces(string words)
        {
            if (words.Contains('_'))
            {
                return words.Replace('_', ' ');
            }
            return words.Replace('-', ' ');
        }

    }
}
