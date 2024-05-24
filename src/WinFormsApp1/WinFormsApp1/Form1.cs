using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            buttonOval2.Click += ButtonOval2_Click;
        }

        private void ButtonOval2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file name
                string selectedFileName = openFileDialog.FileName;

                // Load the selected image into pictureBox2
                pictureBox2.Image = Image.FromFile(selectedFileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

                // Load and preprocess the image
                Image<Bgr, byte> image = new Image<Bgr, byte>(selectedFileName);
                Image<Gray, byte> binaryImage = PreprocessFingerprint(image);

                // Display the processed binary image in pictureBox2

                // Convert the binary image to a string of 0s and 1s
                string binaryString = ConvertBinaryImageToString(binaryImage);
                string asciiString = ConvertBinaryToAscii(binaryString);
                // Display the binary string in a TextBox
                textBox1.Text = binaryString;
                textBox2.Text = asciiString;
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

            // Find contours
            var contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(binaryImage, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            // Find the largest contour, which should be the fingerprint
            double largestArea = 0;
            int largestContourIndex = -1;
            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area > largestArea)
                {
                    largestArea = area;
                    largestContourIndex = i;
                }
            }

            if (largestContourIndex == -1)
            {
                throw new Exception("No contours found in the image.");
            }

            // Get the bounding box of the largest contour
            Rectangle boundingBox = CvInvoke.BoundingRectangle(contours[largestContourIndex]);

            // Crop the image to the bounding box
            Image<Bgr, byte> croppedImage = image.GetSubRect(boundingBox);

            // Resize the cropped image to a standard size, e.g., 256x256
            Image<Bgr, byte> resizedImage = croppedImage.Resize(256, 256, Inter.Linear);

            // Convert the resized image to grayscale and apply adaptive thresholding again
            Image<Gray, byte> finalGrayImage = resizedImage.Convert<Gray, byte>();
            Image<Gray, byte> finalBinaryImage = new Image<Gray, byte>(finalGrayImage.Size);
            CvInvoke.AdaptiveThreshold(finalGrayImage, finalBinaryImage, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 11, 2);

            return finalBinaryImage;
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
            MessageBox.Show("Hello");
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
    }
}
