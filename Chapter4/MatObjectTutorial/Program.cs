using OpenCvSharp;

namespace MatObjectTutorial
{
    // to run: use PowerShell, copy folder dir with Program.cs and paste it to 'cd' to navigate, to run use: dotnet run
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

            /*
            Mat[] channels;
            Cv2.Split(colorImage, out channels);
            Cv2.ImShow("Blue", channels[0]);
            Cv2.ImShow("Green", channels[1]);
            Cv2.ImShow("Red", channels[2]);
            */

            /*
            Mat roiImage = new Mat(colorImage, new Rect(150, 150, 200, 200));
            Cv2.ImShow("roi", roiImage);
            */

            int numRows = colorImage.Rows;
            int numCols = colorImage.Cols;

            Mat cImage = colorImage.Clone();

            /*
            for (int y = 0; y < numRows; y++)
            {
                for (int x = 0; x < numCols; x++)
                {
                    Vec3b pixel = cImage.Get<Vec3b>(y, x);
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;

                    // swap red/blue
                    byte temp = blue;
                    pixel.Item0 = red;
                    pixel.Item2 = temp;

                    cImage.Set<Vec3b>(y, x, pixel);
                }
            }
            */

            /*
            var indexer = cImage.GetGenericIndexer<Vec3b>();
            for (int y = 0; y < numRows; y++)
            {
                for (int x = 0; x < numCols; x++)
                {
                    Vec3b pixel = indexer[y, x];
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;

                    // swap red/blue
                    byte temp = blue;
                    pixel.Item0 = red;
                    pixel.Item2 = temp;

                    indexer[y, x] = pixel;
                }
            }
            */
            MatOfByte3 mat3 = new MatOfByte3(cImage);
            var indexer = mat3.GetIndexer();

            for (int y = 100; y < numRows-200; y++)
            {
                for (int x = 200; x < numCols-400; x++)
                {
                    Vec3b pixel = indexer[y, x];
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;

                    // swap red/blue
                    byte temp = blue;
                    pixel.Item0 = red;
                    pixel.Item2 = temp;

                    indexer[y, x] = pixel;
                }
            }

            Cv2.ImShow("original", colorImage);
            Cv2.ImShow("swapped", cImage);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
