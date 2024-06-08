using System;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WinFormsApp1
{
    public static class Preprocessing
    {
        public static char ConvertIntensityToAsciiChar(byte intensity)
        {
            const byte asciiStart = 32;
            const byte asciiEnd = 126;
            const byte asciiRange = asciiEnd - asciiStart + 1;
            return (char)(asciiStart + (intensity * asciiRange / 256));
        }

        // this is a basic image to ascii converter w/o resizing it to be 30px
        public static string ConvertImageToAscii(Image<Bgr, byte> image){
            // Convert to grayscale
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Convert each pixel to ASCII
            StringBuilder asciiString = new StringBuilder();
            StringBuilder binaryString = new StringBuilder();
            for (int y = 0; y < grayImage.Rows; y++)
            {
                for (int x = 0; x < grayImage.Cols; x++)
                {
                    byte intensity = grayImage.Data[y, x, 0]; // Get the intensity value
                    char asciiChar = ConvertIntensityToAsciiChar(intensity); // Convert intensity to ASCII character
                    asciiString.Append(asciiChar);

                }
                asciiString.AppendLine(); // New line after each row
            }

            // Output the ASCII string
            System.Diagnostics.Debug.Write(asciiString.ToString());
            return asciiString.ToString();
        }

    }
}

