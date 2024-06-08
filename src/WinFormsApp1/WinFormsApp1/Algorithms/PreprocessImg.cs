using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Text;

namespace WinFormsApp1.Algorithm
{
    public static class Preprocessing
    {
        public static string ConvertBinaryImageToString(Image<Gray, byte> binaryImage)
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

        public static Image<Gray, byte> PreprocessFingerprint(Image<Bgr, byte> image)
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

        public static string ConvertBinaryToAscii(string binaryString)
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
    }
}
