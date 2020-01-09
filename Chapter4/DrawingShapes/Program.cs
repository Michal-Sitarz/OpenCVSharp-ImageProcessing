﻿using System;
using OpenCvSharp;

namespace DrawingShapes
{
    class Program
    {
        static void Main(string[] args)
        {

            Mat canvas = new Mat(150, 150, MatType.CV_8UC3, new Scalar(0, 0, 0));

            var red = new Scalar(0, 0, 255);
            var blue = new Scalar(255, 0, 0);
            var green = new Scalar(0, 255, 0);
            var white = new Scalar(255, 255, 255);

            Cv2.Line(canvas, new Point(20,20), new Point(200, 200), blue, 2);
            Cv2.Circle(canvas, new Point(60, 60), 30, red, 3);
            Cv2.Rectangle(canvas, new Rect(10,10,50,50), white, 2);

            Cv2.ImShow("canvas", canvas);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
