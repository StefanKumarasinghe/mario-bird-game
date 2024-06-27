using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   //This class is responsible for creating a single PIPE object
    public class Pipe : IDesign
    {
        private Bitmap pipe;
        private DrawingOptions pipeopt;
        double x;
        double y;
        public Pipe()
        {
            pipe = SplashKit.LoadBitmap("Pipe", "Resources/pipe.png");
            pipeopt = SplashKit.OptionScaleBmp(0.5, 0.5);
            x = 400;
            Random z  = new Random();
            //Randomly adjusts the height
            y = z.Next(-100,30);
        }
        
        public double X
        {
            get { return x; }
            set { x = value; }  
        }

        public double Y
        {
            get { return y; }
            set { y = value; }

        }
        public void Update()
        {
            //Moves back with the frame
            x -= 0.2;  
        }
     
        public void Draw()
        {
            SplashKit.DrawBitmap(pipe, x, y+150, pipeopt);
        }
        

      

    }
}
