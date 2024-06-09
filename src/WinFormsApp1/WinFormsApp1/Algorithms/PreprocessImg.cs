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

        // this is a image cropper so we can only obtain the main focus of the image
        public static Image<Bgr, byte> CropTheImage(Image<Bgr, byte> image)
        {
            // Konversi ke greyscale, siapatahu blm bnw
            Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

            // Pasang threshold
            Image<Gray, byte> binaryImage = new Image<Gray, byte>(grayImage.Size);
            CvInvoke.Threshold(grayImage, binaryImage, 127, 255, ThresholdType.Binary);

            // Find contours buat cropping white area yang tidak relevan
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(binaryImage, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            // Cari contour yang terbesar alias area fingerprint
            double maxArea = 0;
            int maxAreaContourIndex = -1;
            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                    maxAreaContourIndex = i;
                }
            }

            // Cari petak bounds yang ngewakilin area contour
            
            // No contours found
            if (maxAreaContourIndex == -1) return image; 
            Rectangle boundingRect = CvInvoke.BoundingRectangle(contours[maxAreaContourIndex]);

            // Crop the image
            Image<Bgr, byte> croppedImage = image.Copy(boundingRect);
            return croppedImage;
        }

        // minimal disini menunjukkan apakah kita ingin mengambil size 1x30px dari sebuah image (jadi pattern)
        public static string ConvertImageToAscii(bool minimal, Image<Bgr, byte> image){
            Image<Bgr,byte> grayImage = CropTheImage(image);
            // Convert each pixel to ASCII
            if (!minimal){
                System.Diagnostics.Debug.WriteLine("You have chosen to NOT crop the ascii to 30px as a PATTERN");
                StringBuilder asciiString = new StringBuilder();
                for (int y = 0; y < grayImage.Rows; y++)
                {
                    for (int x = 0; x < grayImage.Cols; x++)
                    {
                        byte intensity = grayImage.Data[y, x, 0]; // Get the intensity value
                        char asciiChar = ConvertIntensityToAsciiChar(intensity); // Convert intensity to ASCII character
                        asciiString.Append(asciiChar);

                    }
                    asciiString.AppendLine();
                }
                // Output the ASCII string
                // System.Diagnostics.Debug.Write(asciiString.ToString());
                return asciiString.ToString();
            }
            // Ini ngecrop 30 px doang buat si pattern inputnya
            else{
                System.Diagnostics.Debug.WriteLine("You have chosen to crop the ascii to 30px as a PATTERN");
                StringBuilder asciioptimal = new StringBuilder();
                int middleRow = grayImage.Rows / 2;
                // Center the 30 characters if the image is wider than 30 columns
                int startCol = Math.Max(0, (grayImage.Cols - 30) / 2); 
                
                for (int x = startCol; x < startCol + 30 && x < grayImage.Cols; x++)
                {
                    byte intensity = grayImage.Data[middleRow, x, 0]; // Get the intensity value
                    char asciiChar = ConvertIntensityToAsciiChar(intensity); // Convert intensity to ASCII character
                    asciioptimal.Append(asciiChar);
                }
                // Output the ASCII string
                // System.Diagnostics.Debug.Write(asciioptimal.ToString());
                return asciioptimal.ToString();
            }
        }

    }
}

