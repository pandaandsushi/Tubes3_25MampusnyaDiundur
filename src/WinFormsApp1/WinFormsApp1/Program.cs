using System;
using Algorithms;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // --------------------------
            // ApplicationConfiguration.Initialize();
            // Application.Run(new Form1());
            // -------------------------

            string connectionString;
            connectionString = "server=localhost;user=root;database=FingerprintRecords;port=3306;password=password";

            // Initialize database
            Database db = new Database(connectionString);

            // Initialize fingerprints manager
            Fingerprints fingerprints = new Fingerprints(db);

            // Test inserting a fingerprint
            //string berkas_citra = System.IO.Path.Combine("test", "100__M_Left_index_finger.bmp");
            //fingerprints.InsertFingerprint(nama, berkas_citra);
            //Console.WriteLine("Fingerprint inserted successfully.");

            // Test retrieving a fingerprint
            
            string nama = "John Doe";
            string fakenama = "jHn d0e";
            string purified = alayTranslator.translateAlay(fakenama);
            // Test retrieving a fingerprint
            Fingerprint result = fingerprints.GetFingerprintByName(nama);
            if (result != null)
            {
               Console.WriteLine($"Fingerprint path for {nama}: {result.BerkasCitra}");
               Console.WriteLine($"Translate  {fakenama} to {purified}");
               Console.WriteLine($"Levenshtein distance between {nama} and {purified}: {Levenshtein.calculateSimilarity(nama, purified)}");

            }
            else
            {
               Console.WriteLine($"No fingerprint found for {nama}");
            }

           List<Fingerprint> fingerprintList = fingerprints.GetAllFingerprintData();
            if (fingerprintList.Count > 0){
                foreach (var fingerprint in fingerprintList)
                {
                    Console.WriteLine($"Fingerprint path for {fingerprint.Nama}: {fingerprint.BerkasCitra}");
                }
            }
            else{
                Console.WriteLine($"No fingerprint");

            }

        }
    }
}