using System;
using OpenCvSharp;

namespace BitwiseOperationsOnImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // BitwiseAND
            // BitwiseOR
            // BitwiseXOR
            // BitwiseNOT

            Mat image1 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);
            Mat image2 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);

            Cv2.Rectangle(image1, new Rect(new Point(0, 0), new Size(image1.Cols / 2, image1.Rows)), new Scalar(255, 255, 255), -1);
            Cv2.ImShow("image1", image1);

            Cv2.Rectangle(image2, new Rect(new Point(150, 100), new Size(200,50)), new Scalar(255, 255, 255), -1);
            Cv2.ImShow("image2", image2);

            Mat andImage = new Mat();
            Cv2.BitwiseAnd(image1, image2, andImage);
            Cv2.ImShow("andImage", andImage);

            Mat orImage = new Mat();
            Cv2.BitwiseOr(image1, image2, orImage);
            Cv2.ImShow("orImage", orImage);

            Mat xorImage = new Mat();
            Cv2.BitwiseXor(image1, image2, xorImage);
            Cv2.ImShow("xorImage", xorImage);
            
            Mat notImage1 = new Mat();
            Cv2.BitwiseNot(image1, notImage1);
            Cv2.ImShow("notImage1", notImage1);

            Mat notImage2 = new Mat();
            Cv2.BitwiseNot(image2, notImage2);
            Cv2.ImShow("notImage2", notImage2);


            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
