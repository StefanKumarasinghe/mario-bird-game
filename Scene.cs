using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   //This is responsible for the background
    public  class Scene : IDesign
    {
        Bitmap background;
        List<Obstacles> ob;
        double x;

        public Scene()
        {
            ob = new List<Obstacles>();
            x = 0;
            background = SplashKit.LoadBitmap("Back", "Resources/scene.png");
        }
        public void Update()
        {
            x -= 0.1;
            if (x < -background.Width+600)
            {
                x = 0;
            }
        }
        public void Draw()
        {
            SplashKit.DrawBitmap(background, x, 0);
        }
    }
}
