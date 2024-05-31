using System;
using System.Text.RegularExpressions;
namespace WinFormsApp1.Algorithm
{
	public class alayTranslator
	{
        public static string translateAlay(string input)
        {
            string numPattern = "[14630]";
            string result = Regex.Replace(input, numPattern, m => {
                switch (m.Value)
                {
                    case "1": return "i";
                    case "4": return "a";
                    case "6": return "g";
                    case "3": return "e";
                    case "0": return "o";
                    default: return m.Value;
                }
            });

            result = result.ToLower();

            result = Regex.Replace(result, @"\b[a-z]", m => m.Value.ToUpper());

            return result;

        }

    }
}

