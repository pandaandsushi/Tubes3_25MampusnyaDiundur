using System;

namespace WinFormsApp1.Algorithm{
    public static class Levenshtein
    {
        public static int calculateSimilarity(string name1, string name2){
            int name1Length = name1.Length;
            int name2Length = name2.Length;
            int[,] distanceMatrix = new int[name1Length + 1, name2Length + 1];

            if (name1Length == 0) { return name2Length; }
            if (name2Length == 0) { return name1Length; }

            // inisialisasi matrix dengan edit cost dari name1[i] ke name2[j]
            for (int i = 0; i <= name1Length; i++) { distanceMatrix[i, 0] = i; }
            for (int j = 1; j <= name2Length; j++) { distanceMatrix[0, j] = j; }

            // mulai hitung edit distance untuk tiap row dan col mulai dari i = 1 dan j = 1
            for (int i = 1; i <= name1Length; i++)
            {
                for (int j = 1; j <= name2Length; j++)
                {
                    int cost = (name1[i - 1] == name2[j - 1] ? 0 : 1);
                    int insert = distanceMatrix[i, j - 1] + 1;
                    int delete = distanceMatrix[i - 1, j] + 1;
                    int replace = distanceMatrix[i - 1, j - 1] + cost;

                    distanceMatrix[i, j] = Math.Min(Math.Min(insert, delete), replace);
                }
            }

            return distanceMatrix[name1Length - 1, name2Length - 1];
        }
    }
}