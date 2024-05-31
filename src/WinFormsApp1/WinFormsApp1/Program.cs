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
            string nama = "John Doe";
            //string berkas_citra = System.IO.Path.Combine("test", "100__M_Left_index_finger.bmp");
            //fingerprints.InsertFingerprint(nama, berkas_citra);
            //Console.WriteLine("Fingerprint inserted successfully.");

            // Test retrieving a fingerprint
            string retrievedPath = fingerprints.GetFingerprintByName(nama);
            if (retrievedPath != null)
            {
                Console.WriteLine($"Fingerprint path for {nama}: {retrievedPath}");
            }
            else
            {
                Console.WriteLine($"No fingerprint found for {nama}");
            }

        }
    }
}