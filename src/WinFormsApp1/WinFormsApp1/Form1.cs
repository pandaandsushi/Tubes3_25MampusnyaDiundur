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
        public Form1()
        {
            InitializeComponent();
            buttonOval2.Click += ButtonOval2_Click;
            search1.Click += ButtonSearch1_Click;
            UpdateDatabaseWithAsciiRepresentation();
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

            string connectionString = "server=localhost;user id=root;password=password;database=fingerprint";
            string query = "SELECT berkas_citra, nama FROM sidik_jari";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                System.Diagnostics.Debug.WriteLine($"DEBUGGGGGGGGGGGGG: BERHASIL ON CONNECTION");
                while (reader.Read())
                {
                    string relativeImagePath = reader["berkas_citra"].ToString();
                    string imagePath = Path.Combine(imagesDirectory, relativeImagePath);
                    if (File.Exists(imagePath)) // Ensure the file exists before processing
                    {
                        string name = reader["nama"].ToString();
                        string asciiRepresentation = GetAsciiRepresentation(imagePath);
                        UpdateAsciiInDatabase(name, asciiRepresentation);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"DEBUG: File {imagePath} does not exist");
                    }
                }
            }
        }

        private string GetAsciiRepresentation(string imagePath)
        {
            Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
            Image<Gray, byte> binaryImage = PreprocessFingerprint(image);

            Image<Gray, byte> resizedImage = binaryImage.Resize(240, 320, Inter.Linear);
            string binaryString = ConvertBinaryImageToString(resizedImage);
            string asciiString = ConvertBinaryToAscii(binaryString);

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

        private void ButtonSearch1_Click(object sender, EventArgs e){
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
                Image<Gray, byte> binaryImage = PreprocessFingerprint(image);
            
                // Resize to 240x320 pixels
                Image<Gray, byte> resizedImage = binaryImage.Resize(240, 320, Inter.Linear);
                // Display the processed binary image in pictureBox2 for testinggg
                // Convert the binary image to a string of 0s and 1s
                string binaryString = ConvertBinaryImageToString(resizedImage);
                string asciiString = ConvertBinaryToAscii(binaryString);
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
            string connectionString = "server=localhost;user id=root;password=password;database=fingerprint";
            string query = "SELECT berkas_citra, nama, ascii_represent FROM sidik_jari";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string asciiRepresentation = reader["ascii_represent"].ToString();
                    string nama = reader["nama"].ToString();
                    string imagePath = reader["berkas_citra"].ToString();

                    if (toggledon){
                        found = KMPAlgorithm.KMPSearch(pattern, asciiRepresentation);
                    }
                    else{
                        found = BoyerMooreAlgorithm.BMSearch(pattern, asciiRepresentation);
                    }
                    if (found){
                        return (nama, imagePath);
                    }
                }
            }

            return (null, null);
        }
        private string ConvertBinaryToAscii(string binaryString)
        {
            StringBuilder asciiString = new StringBuilder();
            string[] lines = binaryString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i += 8)
                {
                    string byteString = line.Substring(i, Math.Min(8, line.Length - i));
                    if (byteString.Length == 8)
                    {
                        byte asciiValue = Convert.ToByte(byteString, 2);
                        asciiString.Append((char)asciiValue);
                    }
                }
                asciiString.AppendLine();
            }

            return asciiString.ToString();
        }

        // to convert to grayscale and clean the image
        private Image<Gray, byte> PreprocessFingerprint(Image<Bgr, byte> image)
        {
            // Convert to grayscale
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Enhance the image contrast using histogram equalization
            Image<Gray, byte> enhancedImage = grayImage.Clone();
            CvInvoke.EqualizeHist(grayImage, enhancedImage);

            // Apply Gaussian Blur to reduce noise
            Image<Gray, byte> blurredImage = new Image<Gray, byte>(enhancedImage.Size);
            CvInvoke.GaussianBlur(enhancedImage, blurredImage, new Size(5, 5), 0);

            // Apply adaptive thresholding to create a binary image
            Image<Gray, byte> binaryImage = new Image<Gray, byte>(blurredImage.Size);
            CvInvoke.AdaptiveThreshold(blurredImage, binaryImage, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 11, 2);

            return binaryImage;
        }
        private string ConvertBinaryImageToString(Image<Gray, byte> binaryImage)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < binaryImage.Height; y++)
            {
                StringBuilder line = new StringBuilder();
                for (int x = 0; x < binaryImage.Width; x++)
                {
                    byte pixelValue = binaryImage.Data[y, x, 0];
                    line.Append(pixelValue == 255 ? "1" : "0");
                }

                // Pad line to make its length a multiple of 8
                while (line.Length % 8 != 0)
                {
                    line.Append("0");
                }

                sb.AppendLine(line.ToString());
            }

            return sb.ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
