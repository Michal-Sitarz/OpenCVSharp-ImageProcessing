using System;
using OpenCvSharp;

namespace FirstImageProcessingSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../images/paradise.jpg", ImreadModes.Color);





            Cv2.ImShow("original", image);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
