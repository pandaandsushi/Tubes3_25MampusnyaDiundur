using System;

namespace WinFormsApp1.Algorithm
{
    public static class Levenshtein
    {
        public static int calculateSimilarity(string name1, string name2)
        {
            int len1 = name1.Length;
            int len2 = name2.Length;

            // Ada strings kosong
            if (len1 == 0) return len2;
            if (len2 == 0) return len1;

            // Arrays for the distances
            int[] previousRow = new int[len2 + 1];
            int[] currentRow = new int[len2 + 1];

            for (int j = 0; j <= len2; j++)
            {
                previousRow[j] = j;
            }

            for (int i = 1; i <= len1; i++)
            {
                currentRow[0] = i;

                for (int j = 1; j <= len2; j++)
                {
                    int insert = previousRow[j] + 1;
                    int delete = currentRow[j - 1] + 1;
                    int replace = previousRow[j - 1] + (name1[i - 1] == name2[j - 1] ? 0 : 1);

                    currentRow[j] = Math.Min(Math.Min(insert, delete), replace);
                }

                var temp = previousRow;
                previousRow = currentRow;
                currentRow = temp;
            }

            return previousRow[len2];
        }
    }
}
