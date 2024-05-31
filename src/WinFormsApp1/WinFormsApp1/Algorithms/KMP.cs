using System;
namespace WinFormsApp1.Algorithm {
    public static class KMPAlgorithm
    {
        // Fungsi untuk membangun tabel Longest Prefix Suffix (LPS) yang digunakan oleh algoritma KMP
        private static void BuildLpsArray(string pattern, int[] lps)
        {
            int length = 0;  // Panjang dari prefix yang cocok
            int i = 1;
            lps[0] = 0;  // LPS dari elemen pertama selalu 0

            // Loop untuk menghitung lps[i] untuk i dari 1 ke M-1
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
        }

        // Fungsi untuk mencari pola dalam teks menggunakan algoritma KMP
        public static void KMPSearch(string pattern, string text)
        {
            int M = pattern.Length;
            int N = text.Length;

            // Buat array lps[] yang akan menampung panjang dari prefix suffix terpanjang
            int[] lps = new int[M];
            int j = 0;  // Indeks untuk pattern[]

            // Bangun tabel LPS
            BuildLpsArray(pattern, lps);

            int i = 0;  // Indeks untuk text[]
            while (i < N)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }

                if (j == M)
                {
                    Console.WriteLine("Pattern ditemukan pada indeks " + (i - j));
                    j = lps[j - 1];
                }
                else if (i < N && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        // public static void Main()
        // {
        //     string text = "ABABDABACDABABCABAB";
        //     string pattern = "ABABCABAB";
        //     KMPSearch(pattern, text);
        // }
    }
}