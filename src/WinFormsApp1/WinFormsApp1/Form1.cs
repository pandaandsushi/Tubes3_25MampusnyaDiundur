using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
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

            // UpdateDatabaseWithAsciiRepresentation();
        }
        // getting the project dir for diff user
        private string GetProjectDirectory()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName, "..");
            return projectDirectory;
        }


        private void UpdateDatabaseWithAsciiRepresentation()
        {
            string projectDirectory = GetProjectDirectory();
            string imagesDirectory = Path.Combine(projectDirectory, "SOCOFing", "Altered", "Altered-Easy");

            List<Fingerprint> fingerprintData = fingerprints.GetAllFingerprintData();

            foreach (var fingerprint in fingerprintData)
            {
                string relativeImagePath = fingerprint.BerkasCitra;
                string imagePath = Path.Combine(imagesDirectory, relativeImagePath);
                if (File.Exists(imagePath)) // Ensure the file exists before processing
                {
                    string asciiRepresentation = GetAsciiRepresentation(imagePath);
                    UpdateAsciiInDatabase(fingerprint.Nama, asciiRepresentation);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"DEBUG: File {imagePath} does not exist");
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

        private void UpdateAsciiInDatabase(string name, string asciiRepresentation)
        {
            string connectionString = "server=localhost;user id=root;password=password;database=fingerprint";
            string updateQuery = "UPDATE sidik_jari SET ascii_represent = @ascii_represent WHERE nama = @nama";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@ascii_represent", asciiRepresentation);
                cmd.Parameters.AddWithValue("@nama", name);

                cmd.ExecuteNonQuery();
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
