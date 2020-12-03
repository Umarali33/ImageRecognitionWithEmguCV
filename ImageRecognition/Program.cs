using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;

namespace ImageRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            long score;
            long matchTime;
            string mImage = "Images\\IK_model2.jpg";
            string oImage = "Images\\IK_model2.jpg";
            Console.WriteLine("Model Image: " + mImage);
            Console.WriteLine("Observed Image: " + oImage);
            var img = imageConversion(mImage);
            var bmp = new Bitmap(new MemoryStream(img));
            //byte[,,] imageData = new byte[bmp.Height, bmp.Width, colorChannels];
            //Buffer.BlockCopy(bmp., 0, imageData, 0, imageData.Length);
            Image<Bgr, Byte> depthImage = new Image<Bgr, Byte>(bmp.Height, bmp.Width);
            depthImage.Bytes = img;
            using (Mat modelImage = depthImage.Mat)
            using (Mat observedImage = CvInvoke.Imread(oImage, ImreadModes.Grayscale))
            {
                Console.WriteLine("Start Matching . . .");
                Mat result = DrawMatches.Draw(modelImage, observedImage, out matchTime, out score);
                Console.WriteLine("Matching Process Completed");
                Console.WriteLine("Matching Score: " + score);
                Console.WriteLine("Matching Time: " + matchTime + "ms");
            }
            Console.ReadKey();
        }
        public static byte[] imageConversion(string imageName)
        {


            //Initialize a file stream to read the image file
            FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

            //Initialize a byte array with size of stream
            byte[] imgByteArr = new byte[fs.Length];

            //Read data from the file stream and put into the byte array
            fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

            //Close a file stream
            fs.Close();

            return imgByteArr;
        }
    }
}
