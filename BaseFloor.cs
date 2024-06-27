using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This class is responsible for the floor
    public class BaseFloor : IDesign
    {
        private Bitmap floor;
        private DrawingOptions flooropt;
        private double offset;
        public BaseFloor()
        {
            offset = 0;
            floor = SplashKit.LoadBitmap("Floor", "Resources/floor.png");
            floor.SetCellDetails(546, 90, 1, 4, 4);
            flooropt = SplashKit.OptionWithBitmapCell(1);
        }
        public void Update()
        {
            offset -= 0.2;
            //This creates the looping effect
            if (offset < -floor.Width)
            {
                offset = 0;
            }
        }
        public void Draw()
        {
            int x = floor.Width;
            for (int i = 0; i < 3; i++)
            {
                SplashKit.DrawBitmap(floor, offset - x, 500, flooropt);
                x -= floor.Width;
            }
        }
    }
}
