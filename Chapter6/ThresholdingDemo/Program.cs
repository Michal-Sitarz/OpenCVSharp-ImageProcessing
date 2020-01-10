using System;
using OpenCvSharp;

namespace ThresholdingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../images/leaf.jpg", ImreadModes.Color);
            Cv2.Resize(image, image, new Size(image.Width / 1.5, image.Height / 1.5));

            /*
            Mat threshold = new Mat(new Size(image.Width, image.Height), MatType.CV_8UC3, new Scalar(0)); // Scalar(0) is the black colour
            Cv2.Threshold(image, threshold, 15, 255, ThresholdTypes.Binary);
            */
            Mat threshold = new Mat();
            Mat grayscaled = new Mat();
            Mat adaptive = new Mat();

            Cv2.CvtColor(image, grayscaled, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(grayscaled, threshold, 55, 255, ThresholdTypes.Binary);
            Cv2.AdaptiveThreshold(grayscaled, adaptive, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 11, 1.0);

            Cv2.ImShow("original", image);
            Cv2.ImShow("grayscaled", grayscaled);
            Cv2.ImShow("threshold", threshold);
            Cv2.ImShow("adaptive", adaptive);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
