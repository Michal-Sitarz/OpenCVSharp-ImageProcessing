using System;
using OpenCvSharp;

namespace LoadDisplaySave
{
    // to run: use PowerShell, copy folder dir with Program.cs and paste it to 'cd' to navigate, to run use: dotnet run
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
                // also can be loaded as RGB/BGR and converted to grayscale using: Cv2.CvtColor(image, Cv2.COLOR_BGR2GRAY);

                Cv2.ImShow("leaf", image);

                Cv2.ImWrite(@"../../images/leafSaved.jpg", image);

                Cv2.WaitKey();
                Cv2.DestroyAllWindows();

            }
        }
    }
}
