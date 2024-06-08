// // using Emgu.CV;
// // using Emgu.CV.CvEnum;
// // using Emgu.CV.Structure;
// // using System;
// // using System.Drawing;
// // using System.Text;

// // namespace WinFormsApp1.Algorithm
// // {
// //     public static class Preprocessing
// //     {
// //         public static string ConvertBinaryImageToString(Image<Gray, byte> binaryImage)
// //         {
// //             StringBuilder sb = new StringBuilder();

// //             for (int y = 0; y < binaryImage.Height; y++)
// //             {
// //                 StringBuilder line = new StringBuilder();
// //                 for (int x = 0; x < binaryImage.Width; x++)
// //                 {
// //                     byte pixelValue = binaryImage.Data[y, x, 0];
// //                     line.Append(pixelValue == 255 ? "1" : "0");
// //                 }

// //                 // Pad line to make its length a multiple of 8
// //                 while (line.Length % 8 != 0)
// //                 {
// //                     line.Append("0");
// //                 }

// //                 sb.AppendLine(line.ToString());
// //             }

// //             return sb.ToString();
// //         }

// //         public static Image<Gray, byte> PreprocessFingerprint(Image<Bgr, byte> image)
// //         {
// //             // Convert to grayscale
// //             Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

// //             // Enhance the image contrast using histogram equalization
// //             Image<Gray, byte> enhancedImage = grayImage.Clone();
// //             CvInvoke.EqualizeHist(grayImage, enhancedImage);

// //             // Apply Gaussian Blur to reduce noise
// //             Image<Gray, byte> blurredImage = new Image<Gray, byte>(enhancedImage.Size);
// //             CvInvoke.GaussianBlur(enhancedImage, blurredImage, new Size(5, 5), 0);

// //             // Apply adaptive thresholding to create a binary image
// //             Image<Gray, byte> binaryImage = new Image<Gray, byte>(blurredImage.Size);
// //             CvInvoke.AdaptiveThreshold(blurredImage, binaryImage, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 11, 2);

// //             return binaryImage;
// //         }

// //         public static string ConvertBinaryToAscii(string binaryString)
// //         {
// //             StringBuilder asciiString = new StringBuilder();
// //             string[] lines = binaryString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

// //             foreach (string line in lines)
// //             {
// //                 for (int i = 0; i < line.Length; i += 8)
// //                 {
// //                     string byteString = line.Substring(i, Math.Min(8, line.Length - i));
// //                     if (byteString.Length == 8)
// //                     {
// //                         byte asciiValue = Convert.ToByte(byteString, 2);
// //                         asciiString.Append((char)asciiValue);
// //                     }
// //                 }
// //                 asciiString.AppendLine();
// //             }

// //             return asciiString.ToString();
// //         }
// //     }
// // }
// using System;
// using System.Drawing;
// using System.Text;
// using System.Windows.Forms;
// using Emgu.CV;
// using Emgu.CV.CvEnum;
// using Emgu.CV.Features2D;
// using Emgu.CV.Structure;
// using Emgu.CV.Util;


// namespace WinFormsApp1
// {
//     public static class Preprocessing
//     {
//         public static string ConvertBinaryImageToString(Image<Gray, byte> binaryImage)
//         {
//             // Extract the most optimal 30x30 block
//             Image<Gray, byte> optimalBlock = ExtractOptimalBlock(binaryImage);
            
//             // Convert the block to binary string and then to ASCII string
//             StringBuilder binaryBlock = new StringBuilder();
//             for (int y = 0; y < optimalBlock.Height; y++)
//             {
//                 for (int x = 0; x < optimalBlock.Width; x++)
//                 {
//                     byte pixelValue = optimalBlock.Data[y, x, 0];
//                     binaryBlock.Append(pixelValue == 255 ? "1" : "0");
//                 }
//                 binaryBlock.AppendLine();
//             }

//             string binaryString = binaryBlock.ToString();
//             System.Diagnostics.Debug.WriteLine($"DEBUG: Binary String:\n{binaryString}");
//             string asciiString = ConvertBinaryToAscii(binaryString);
//             System.Diagnostics.Debug.WriteLine($"DEBUG: ASCII String:\n{asciiString}");
//             return asciiString;
//         }

//         public static string ConvertBinaryToAscii(string binaryString)
//         {
//             StringBuilder asciiString = new StringBuilder();
//             string[] lines = binaryString.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

//             foreach (string line in lines)
//             {
//                 for (int i = 0; i < line.Length; i += 8)
//                 {
//                     string byteString = line.Substring(i, Math.Min(8, line.Length - i));
//                     if (byteString.Length == 8)
//                     {
//                         byte asciiValue = Convert.ToByte(byteString, 2);
//                         asciiString.Append((char)asciiValue);
//                     }
//                 }
//                 asciiString.AppendLine();
//             }

//             return asciiString.ToString();
//         }

//         public static Image<Gray, byte> PreprocessFingerprint(Image<Bgr, byte> image)
//         {
//             // Convert to grayscale
//             Image<Gray, byte> grayImage = image.Convert<Gray, byte>();

//             // Enhance the image contrast using histogram equalization
//             Image<Gray, byte> enhancedImage = grayImage.Clone();
//             CvInvoke.EqualizeHist(grayImage, enhancedImage);

//             // Apply Gaussian Blur to reduce noise
//             Image<Gray, byte> blurredImage = new Image<Gray, byte>(enhancedImage.Size);
//             CvInvoke.GaussianBlur(enhancedImage, blurredImage, new Size(5, 5), 0);

//             // Apply adaptive thresholding to create a binary image
//             Image<Gray, byte> binaryImage = new Image<Gray, byte>(blurredImage.Size);
//             CvInvoke.AdaptiveThreshold(blurredImage, binaryImage, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 11, 2);

//             return binaryImage;
//         }

//         public static Image<Gray, byte> ExtractOptimalBlock(Image<Gray, byte> binaryImage)
//         {
//             // Detect key points using ORB detector
//             ORB orbDetector = new ORB();
//             VectorOfKeyPoint keyPoints = new VectorOfKeyPoint();
//             Mat descriptors = new Mat();
//             orbDetector.DetectAndCompute(binaryImage, null, keyPoints, descriptors, false);

//             // Find the most dense area of key points
//             Rectangle optimalRect = new Rectangle();
//             int maxKeyPointCount = 0;

//             for (int y = 0; y < binaryImage.Height - 100; y += 10)
//             {
//                 for (int x = 0; x < binaryImage.Width - 100; x += 10)
//                 {
//                     Rectangle rect = new Rectangle(x, y, 100, 100);
//                     int keyPointCount = 0;

//                     foreach (var keyPoint in keyPoints.ToArray())
//                     {
//                         if (rect.Contains((int)keyPoint.Point.X, (int)keyPoint.Point.Y))
//                         {
//                             keyPointCount++;
//                         }
//                     }

//                     if (keyPointCount > maxKeyPointCount)
//                     {
//                         maxKeyPointCount = keyPointCount;
//                         optimalRect = rect;
//                     }
//                 }
//             }

//             return binaryImage.GetSubRect(optimalRect);
//         }
//     }
// }
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
        public static string ConvertBinaryImageToString(Image<Gray, byte> binaryImage)
        {
            // Extract the optimal block around minutiae points
            Image<Gray, byte> optimalBlock = ExtractOptimalBlock(binaryImage);

            // Convert the block to binary string and then to ASCII string
            StringBuilder binaryBlock = new StringBuilder();
            for (int y = 0; y < optimalBlock.Height; y++)
            {
                for (int x = 0; x < optimalBlock.Width; x++)
                {
                    byte pixelValue = optimalBlock.Data[y, x, 0];
                    binaryBlock.Append(pixelValue == 255 ? "1" : "0");
                }
                binaryBlock.AppendLine();
            }

            string binaryString = binaryBlock.ToString();
            System.Diagnostics.Debug.WriteLine($"DEBUG: Binary String:\n{binaryString}");
            string asciiString = ConvertBinaryToAscii(binaryString);
            System.Diagnostics.Debug.WriteLine($"DEBUG: ASCII String:\n{asciiString}");
            return asciiString;
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

        public static Image<Gray, byte> ExtractOptimalBlock(Image<Gray, byte> binaryImage)
        {
            var minutiaePoints = GetMinutiaePoints(binaryImage);

            // Determine the optimal block around the minutiae points
            if (minutiaePoints.Count == 0)
                return binaryImage;

            Rectangle optimalRect = GetBoundingBox(minutiaePoints, binaryImage.Size);

            return binaryImage.GetSubRect(optimalRect);
        }

        private static List<Point> GetMinutiaePoints(Image<Gray, byte> binaryImage)
        {
            List<Point> minutiaePoints = new List<Point>();
            int[,] crossingNumberMask = {
                { 0, 1, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 }
            };

            for (int y = 1; y < binaryImage.Height - 1; y++)
            {
                for (int x = 1; x < binaryImage.Width - 1; x++)
                {
                    if (binaryImage.Data[y, x, 0] == 255) // White pixel
                    {
                        int count = 0;
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (crossingNumberMask[i + 1, j + 1] == 1 && binaryImage.Data[y + i, x + j, 0] == 0)
                                    count++;
                            }
                        }

                        if (count == 1 || count == 3)
                        {
                            minutiaePoints.Add(new Point(x, y));
                        }
                    }
                }
            }

            return minutiaePoints;
        }

        private static Rectangle GetBoundingBox(List<Point> points, Size imageSize)
        {
            int minX = points.Min(p => p.X);
            int maxX = points.Max(p => p.X);
            int minY = points.Min(p => p.Y);
            int maxY = points.Max(p => p.Y);

            int width = Math.Min(30, maxX - minX);
            int height = Math.Min(30, maxY - minY);

            return new Rectangle(minX, minY, width, height);
        }
    }
}

