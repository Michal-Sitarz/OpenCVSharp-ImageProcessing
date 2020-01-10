using System;
using OpenCvSharp;

namespace OtsusThresholdingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../images/leaf.jpg", ImreadModes.Color);
            Cv2.Resize(image, image, new Size(image.Width / 1.5, image.Height / 1.5));

            Mat grayscaled = new Mat();
            Mat otsuThreshold = new Mat();

            Cv2.CvtColor(image, grayscaled, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(grayscaled, otsuThreshold, 0, 255, ThresholdTypes.Otsu|ThresholdTypes.Binary);
            
            Cv2.ImShow("original", image);
            Cv2.ImShow("grayscaled", grayscaled);
            Cv2.ImShow("otsu's threshold", otsuThreshold);


            Cv2.WaitKey();
            Cv2.DestroyAllWindows();

        }
    }
}
