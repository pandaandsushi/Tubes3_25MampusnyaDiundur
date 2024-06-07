using System;
namespace WinFormsApp1.Algorithm{
    public static class BoyerMooreAlgorithm
    {
        // Fungsi untuk membuat tabel Bad Character Heuristic
        private static void BuildBadCharTable(string pattern, int[] badChar)
        {
            int m = pattern.Length;

            // Inisialisasi semua entri tabel badChar dengan -1
            for (int i = 0; i < 256; i++)
                badChar[i] = -1;

            // Isi nilai terakhir dari karakter yang muncul di pattern
            for (int i = 0; i < m; i++)
                badChar[(int)pattern[i]] = i;
        }

        // Fungsi untuk mencari pola dalam teks menggunakan algoritma Boyer-Moore
        public static bool BMSearch(string pattern, string text)
        {
            int m = pattern.Length;
            int n = text.Length;
            int[] badChar = new int[256];
            // Bangun tabel Bad Character Heuristic
            BuildBadCharTable(pattern, badChar);
            int s = 0;  // s adalah pergeseran dari pattern ke teks
            while (s <= (n - m))
            {
                int j = m - 1;

                // Kurangi indeks j dari belakang pattern ke depan
                while (j >= 0 && pattern[j] == text[s + j])
                    j--;

                // Jika pattern cocok dengan teks pada posisi s
                if (j < 0)
                {
                    System.Diagnostics.Debug.WriteLine("PATTERN"+ pattern);
                    System.Diagnostics.Debug.WriteLine("TEXT"+ text);
                    System.Diagnostics.Debug.WriteLine("Pattern ditemukan pada indeks " + s);
                    return true;
                }
                else
                {
                    // Pergeseran pattern berdasarkan tabel bad character
                    s += Math.Max(1, j - badChar[text[s + j]]);
                }
            }
            System.Diagnostics.Debug.WriteLine("Pattern tidak ditemukan di BM :(");
            return false;
        }

        // public static void Main()
        // {
        //     string text = "ABAAABCD";
        //     string pattern = "ABC";
        //     BMSearch(pattern, text);
        // }
    }
}