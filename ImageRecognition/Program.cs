using Emgu.CV;
using Emgu.CV.CvEnum;
using System;

namespace ImageRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            long score;
            long matchTime;
            string mImage = "Images\\IK_model1.jpg";
            string oImage = "Images\\IK_model2.jpg";
            Console.WriteLine("Model Image: "+mImage);
            Console.WriteLine("Observed Image: "+oImage);
            using (Mat modelImage = CvInvoke.Imread(mImage, ImreadModes.Grayscale))
            using (Mat observedImage = CvInvoke.Imread(oImage, ImreadModes.Grayscale))
            {
                Console.WriteLine("Start Matching . . .");
                Mat result = DrawMatches.Draw(modelImage, observedImage, out matchTime, out score);
                Console.WriteLine("Matching Process Completed");
                Console.WriteLine("Matching Score: "+score);
                Console.WriteLine("Matching Time: "+matchTime+"ms");
            }
            Console.ReadKey();
        }
    }
}
