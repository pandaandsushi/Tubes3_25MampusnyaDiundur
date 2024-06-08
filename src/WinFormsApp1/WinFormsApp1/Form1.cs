using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Bogus;
using WinFormsApp1.Algorithm;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool toggledon;
        private String ascii;
        private String resultnama;
        private String resultpath;
        private readonly Fingerprints fingerprints;

        public Form1()
        {
            InitializeComponent();
            buttonOval2.Click += ButtonOval2_Click;
            search1.Click += ButtonSearch1_Click;
            string connectionString = "server=localhost;user id=root;password=password;database=fingerprint";
            Database db = new Database(connectionString);
            System.Diagnostics.Debug.WriteLine($"DEBUGGGGGGGGGGGGG: BERHASIL ON CONNECTION");
            
            // TESTING REGEX
            // string nama = "John Doe";
            // string fakenama = "jHn d0e";
            // string purified = AlayTranslator.translateAlay(fakenama);
            // // Test retrieving a fingerprint
            // System.Diagnostics.Debug.WriteLine($"Translate  {fakenama} to {purified}");
            // System.Diagnostics.Debug.WriteLine($"Levenshtein distance between {nama} and {purified}: {Levenshtein.calculateSimilarity(nama, purified)}");
            

            fingerprints = new Fingerprints(db);

            /// alter table 
            fingerprints.alterTable();
            GenerateDummy(Path.Combine(GetProjectDirectory(), "test"), fingerprints);
            // UpdateDatabaseWithAsciiRepresentation();
        }
        // getting the project dir for diff user
        private string GetProjectDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName, "..", "..", "..");
            return projectDirectory;
        }


        private void UpdateDatabaseWithAsciiRepresentation()
        {
            string projectDirectory = GetProjectDirectory();

            List<Fingerprint> allFingerprints = fingerprints.GetAllFingerprintData();

            foreach (var fingerprint in allFingerprints)
            {
                string imagePath = Path.Combine(projectDirectory, fingerprint.BerkasCitra);
                if (File.Exists(imagePath))
                {
                    string asciiRepresentation = GetAsciiRepresentation(imagePath);
                    fingerprints.insertAscii(fingerprint.Nama, asciiRepresentation);
                }
                else
                {
                    Console.WriteLine($"Image file {imagePath} not found.");
                }
            }
        }

        private string GetAsciiRepresentation(string imagePath)
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
            Image<Gray, byte> binaryImage = Preprocessing.PreprocessFingerprint(image);

            Image<Gray, byte> resizedImage = binaryImage.Resize(240, 320, Inter.Linear);
            string binaryString = Preprocessing.ConvertBinaryImageToString(resizedImage);
            string asciiString = Preprocessing.ConvertBinaryToAscii(binaryString);

            return asciiString;
        }

        private void GenerateDummy(string projectDirectory, Fingerprints fingerprints){
            string[] imageFiles = Directory.GetFiles(projectDirectory, "*.bmp");
            Console.WriteLine($"{projectDirectory}");
            var faker = new Faker();

            foreach (string imagePath in imageFiles)
            {
                string fileName = Path.Combine("test", Path.GetFileName(imagePath));
                Person person = faker.Person;
                string name = person.FullName;
                fingerprints.InsertFingerprint(name, fileName);
                Console.WriteLine($"{name}, {fileName}");
                
                string NIK = faker.Random.Number(100000000, 999999999).ToString();
                string Nama = AlayTranslator.ConvertToAlay(name);
                string TempatLahir = faker.Address.City();
                DateTime TanggalLahir = faker.Date.Past(30, DateTime.Now.AddYears(-20));
                string JenisKelamin = person.Gender.ToString() == "Female" ? "Perempuan" : "Laki-Laki";
                string GolonganDarah = faker.PickRandom(new[] { "A", "B", "AB", "O" });
                string Alamat = faker.Address.FullAddress();
                string Agama = faker.PickRandom(new[] { "Islam", "Kristen", "Katolik", "Hindu", "Buddha", "Konghucu" });
                string StatusPerkawinan = faker.PickRandom(new[] { "Belum Menikah","Menikah","Cerai"});
                string Pekerjaan = faker.Name.JobTitle();
                string Kewarganegaraan = faker.Address.Country();
                fingerprints.InsertBiodata(NIK, Nama, TempatLahir, TanggalLahir, JenisKelamin, GolonganDarah, Alamat, Agama, StatusPerkawinan, Pekerjaan, Kewarganegaraan);
                Console.WriteLine($"{NIK}, {Nama}, {TempatLahir}, {TanggalLahir}, {JenisKelamin}, {GolonganDarah}, {Alamat}, {Agama}, {StatusPerkawinan}, {Pekerjaan}, {Kewarganegaraan}");
            }
        }


        // to change toggle button state
        private void toggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (toggle2.Checked)
            {
                System.Diagnostics.Debug.WriteLine("DEBUG :::::::::: Toggle ON");
                toggledon = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DEBUG :::::::::: Toggle OFF");
                toggledon = false;
            }
        }

        private void ButtonSearch1_Click(object sender, EventArgs e)
        {
            (resultnama, resultpath) = PerformPatternMatching(ascii);
        }

        private void ButtonOval2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fingerprint Imgs (*.BMP)|*.BMP";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Debug.WriteLine("DEBUG--------------------- GAMBAR DITERIMA DAN DI LOAD");
                // Get the selected file name
                string selectedFileName = openFileDialog.FileName;

                // Load the selected image into pictureBox2
                pictureBox2.Image = Image.FromFile(selectedFileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                // Load and preprocess the image
                Image<Bgr, byte> image = new Image<Bgr, byte>(selectedFileName);
                Image<Gray, byte> binaryImage = Preprocessing.PreprocessFingerprint(image);

                // Resize to 240x320 pixels
                Image<Gray, byte> resizedImage = binaryImage.Resize(240, 320, Inter.Linear);
                // Display the processed binary image in pictureBox2 for testinggg
                // Convert the binary image to a string of 0s and 1s
                string binaryString = Preprocessing.ConvertBinaryImageToString(resizedImage);
                string asciiString = Preprocessing.ConvertBinaryToAscii(binaryString);
                ascii = asciiString;

                // DEBUG SHOW ASCII
                textBox1.Text = binaryString;
                textBox2.Text = asciiString;


                // // Display the output image in pic box
                // pictureBox3.Image = Image.FromFile(resultpath);
                System.Diagnostics.Debug.WriteLine("DEBUG--------------------- PROGRAM SELESAI EKSEKUSI");

            }
        }

        // Will Perform patternmatching algo based on the toggle button
        // Will return the nama and image path attribute if found 
        private (string nama, string path) PerformPatternMatching(string pattern)
        {
            System.Diagnostics.Debug.WriteLine("DEBUG--------------------- MULAI PATTERN MATCHING");
            bool found = false;
            List<string> asciiRepresentations = fingerprints.GetAllBerkasCitra();

            foreach (string asciiRepresentation in asciiRepresentations)
            {
                string nama = fingerprints.GetFingerprintByName(asciiRepresentation).Nama;
                string imagePath = fingerprints.GetFingerprintByName(asciiRepresentation).BerkasCitra;

                if (toggledon)
                {
                    found = KMPAlgorithm.KMPSearch(pattern, asciiRepresentation);
                }
                else
                {
                    found = BoyerMooreAlgorithm.BMSearch(pattern, asciiRepresentation);
                }

                if (found)
                {
                    return (nama, imagePath);
                }
            }

            return (null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
