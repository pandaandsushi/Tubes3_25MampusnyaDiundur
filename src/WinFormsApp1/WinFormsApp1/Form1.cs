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
        public Form1()
        {
            InitializeComponent();
            buttonOval2.Click += ButtonOval2_Click;
        }

        // to change toggle button state
        private void toggle2_CheckedChanged(object sender, EventArgs e)
        {
            // Handle the toggle state change
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
                textBox1.Text = binaryString;
                textBox2.Text = asciiString;
                PerformPatternMatching(0,asciiString);

                // string resultPath = "";
                // // Display the output image in pic box
                // pictureBox3.Image = Image.FromFile(resultPath);
                System.Diagnostics.Debug.WriteLine("DEBUG--------------------- PROGRAM SELESAI EKSEKUSI");

            }
        }
        private int PerformPatternMatching(int algoritma, string text)
        {
            System.Diagnostics.Debug.WriteLine("DEBUG--------------------- MULAI PATTERN MATCHING");
            string pattern = "yourPatternHere"; // Replace with the pattern you want to search for

            // Use Boyer-Moore algorithm
            if (!toggledon){
                System.Diagnostics.Debug.WriteLine("DEBUG>>>>>>>>>>>>>>>>>> Menggunakan Algoritma BM");
                // return BoyerMooreAlgorithm.BMSearch(pattern, text);
                return BoyerMooreAlgorithm.BMSearch("BAAB", "AABAACAADAABAABA");
            }
            // Use KMP algorithm
            else{
                System.Diagnostics.Debug.WriteLine("DEBUG>>>>>>>>>>>>>>>>>> Menggunakan Algoritma KMP");
                // return KMPAlgorithm.KMPSearch(pattern, text);
                return KMPAlgorithm.KMPSearch("BAAB", "AABAACAADAABAABA");
            }
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
