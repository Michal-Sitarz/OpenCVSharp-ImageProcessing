using System;
using OpenCvSharp;

namespace FirstImageProcessingSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../images/paradise.jpg", ImreadModes.Color);
            Cv2.Resize(image, image, new Size(image.Width / 1.5, image.Height / 1.5));
            Mat dest = new Mat();

            // SHIFTING/TRANSLATING
            /*
            // Translation Matrix
            // [1,0,tx]
            // [0,1,ty]
            float[] data = { 1, 0, 100, 0, 1, 100 };
            Mat M = new Mat(2, 3, MatType.CV_32FC1, data);
            
            Cv2.WarpAffine(image, dest, M, new Size(image.Width + 100, image.Height + 100));
            */

            // ROTATING
            /*
            var center = new Point2f(image.Width / 2, image.Height / 2);
            double angle = -45.0;
            Mat RM = Cv2.GetRotationMatrix2D(center, angle, 0.5);
                        
            Cv2.WarpAffine(image, dest, RM, new Size(image.Width, image.Height));
            */

            // RESIZING
            /*
            Cv2.Resize(image, dest, new Size(image.Width / 2, image.Height / 2));

            Mat dest2 = new Mat();
            Cv2.Resize(image, dest2, new Size(0, 0), 0.75, 0.5);
            */

            // FLIPPING
            
            Mat dst1 = new Mat();
            Mat dst2 = new Mat();
            Mat dst3 = new Mat();

            Cv2.Flip(image, dst1, FlipMode.X); // flip around x-axis (horizontal axis) <- called "vertical flipping"
            Cv2.Flip(image, dst2, FlipMode.Y); // flip around y-axis (vertical axis) <- called "horizontal flipping"
            Cv2.Flip(image, dst3, FlipMode.XY); // flip around both axis, first X mode, then Y mode = same as 180 degree rotation

            Cv2.ImShow("dst1", dst1);
            Cv2.ImShow("dst2", dst2);
            Cv2.ImShow("dst3", dst3);
            
                       

            Cv2.ImShow("original", image);
            //Cv2.ImShow("processed", dest);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
