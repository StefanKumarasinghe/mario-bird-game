using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IEntity
    {
        public void Draw();
        public void Update();
        public bool Collision(double x1, double y2);
        
    }
}
