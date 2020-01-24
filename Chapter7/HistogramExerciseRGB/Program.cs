using System;
using OpenCvSharp;

namespace HistogramExerciseRGB
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../images/lena.jpg", ImreadModes.Color);
            Cv2.Resize(image, image, new Size(image.Width / 1.5, image.Height / 1.5));
            var colorIntesity = 205;
            Scalar[] colors = new Scalar[] { new Scalar(colorIntesity, 0, 0), new Scalar(0, colorIntesity, 0), new Scalar(0, 0, colorIntesity) };

            Mat[] channels;
            Cv2.Split(image, out channels);

            int plotWidth = 1024, plotHeight = 400;
            Mat canvas = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));

            for (int i = 0; i < channels.Length; i++)
            {
                Mat histogram = ComputeHistogram(channels[i]);
                PlotHistogram(histogram, canvas, colors[i]);
            }

            Cv2.ImShow("Histogram", canvas);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        static Mat ComputeHistogram(Mat image)
        {
            Mat histogram = new Mat();
            Rangef[] ranges = { new Rangef(0, 256) };
            int[] channels = new int[] { 0 };
            int[] histSize = new int[] { 256 };

            Cv2.CalcHist(new Mat[] { image }, channels, null, histogram, 1, histSize, ranges);

            return histogram;
        }

        static void PlotHistogram(Mat histogram, Mat canvas, Scalar color)
        {
            int binWidth = canvas.Width / histogram.Rows;

            Cv2.Normalize(histogram, histogram, 0, canvas.Height, NormTypes.MinMax);

            for (int rows = 1; rows < histogram.Rows; rows++)
            {
                Cv2.Line(
                    canvas,
                    new Point((binWidth * (rows - 1)), (canvas.Height - (float)(histogram.At<float>(rows - 1, 0)))),
                    new Point(binWidth * rows, (canvas.Height - (float)(histogram.At<float>(rows, 0)))),
                    color, 2);
            }
        }
    }
}
