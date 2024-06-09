using System;
using System.Text.RegularExpressions;
namespace WinFormsApp1.Algorithm
{
	public class AlayTranslator
	{
        // pakai regex untuk translate nama alay sesuai aturan tertentu
        // cases ada pada penggunaan angka untuk huruf vokal, konversi lower dan uppercase
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
                    case "5": return "s";
                    case "0": return "o";
                    default: return m.Value;
                }
            });

            result = result.ToLower();

            result = Regex.Replace(result, @"\b[a-z]", m => m.Value.ToUpper());

            return result;
        }
        
        // ConvertToAlay untuk dummy data name pada tabel biodata
        public static string ConvertToAlay(string input)
        {
            string result = Regex.Replace(input, "[AIEGoag]", m =>
            {
                switch (m.Value)
                {
                    case "A": return "4";
                    case "a": return "4";
                    case "I": return "1";
                    case "E": return "3";
                    case "e": return "E";
                    case "o": return "0";
                    case "g": return "9";
                    default: return m.Value;
                }
            });
            result = result.ToLower();

            string temp = "";
            bool firstVowel = false;
            foreach (char c in result)
            {
                if ("aeiou".IndexOf(c) >= 0)
                {
                    if (!firstVowel)
                    {
                        temp += c;
                        firstVowel = true;
                    }
                }
                else
                {
                    temp += c;
                }
            }
            return temp;
        }
    }
}
