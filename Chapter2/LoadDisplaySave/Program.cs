using System;
using OpenCvSharp;

namespace LoadDisplaySave
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("No arguments passed :/");
            }
            else
            {
                string filename = args[0];
                Console.WriteLine(filename);

                Mat image = Cv2.ImRead(filename, ImreadModes.Grayscale);

                Cv2.ImShow("leaf", image);

                Cv2.ImWrite(@"../../images/leafSaved.jpg", image);

                Cv2.WaitKey();
                Cv2.DestroyAllWindows();
            }
        }
    }
}
