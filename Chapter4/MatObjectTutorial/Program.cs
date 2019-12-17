﻿using OpenCvSharp;

namespace MatObjectTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Mat mat = new Mat(80, 180, MatType.CV_8UC3, new Scalar(0, 0, 255));
            Mat mat1 = new Mat(new Size(120, 120), MatType.CV_8UC3, new Scalar(0, 125, 0));

            Cv2.ImShow("m", mat);
            Cv2.ImShow("m1", mat1);
            */

            string path = @"../../images/paradise.jpg";
            Mat colorImage = Cv2.ImRead(path, ImreadModes.Color);

            /*
            Cv2.ImShow("original", colorImage);
            Mat clonedImage = colorImage.Clone();
            Cv2.ImShow("cloned", clonedImage);
            Mat anotherCloned = new Mat();
            colorImage.CopyTo(anotherCloned);
            Cv2.ImShow("another image", anotherCloned);
            */

            Mat[] channels;
            Cv2.Split(colorImage, out channels);
            Cv2.ImShow("Blue", channels[0]);
            Cv2.ImShow("Green", channels[1]);
            Cv2.ImShow("Red", channels[2]);


            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
