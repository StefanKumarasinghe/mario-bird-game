using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //This is the little cloud enemy
    class Enemy :IEntity , IDesign 
    {
        Bitmap character;
        DrawingOptions enemyopt;
        double x;
        double z = 0.1;
        double y;
        bool fall = false;
        int fireballcount = 0;
        Fireballs balls = new Fireballs();
        Random rand = new Random();
        public Enemy()
        {
            character = SplashKit.LoadBitmap("Enemy", "Resources/enemy.png");
            enemyopt = SplashKit.OptionScaleBmp(0.2, 0.2);
            x = 400;
            y = 50;
        }

        public Fireballs Fireballs
        {
            get
            {
                return balls;
            }
        }
        public bool FallBool
        {
            get { return fall; }
            set { fall = value; }
        }
        public void Update()
        {

            //Used to generate a list of fireball objects
            if (x>150 && x<250 )
            {
                if (fireballcount < 2)
                {
                    balls.AddBall();
                    fireballcount++;
                }
            }else
            {
                fireballcount = 0;
            }
            if (x > rand.Next(300, 401))
            {
               z=-0.1;
            }
            if (x < -rand.Next(500, 10001))
            {
                z = 0.1;
            }
            x += z;
            balls.Update();    
        }
        public bool Collision(double x1, double y2)
        {
            if (x1 > x - 20 && x1 < x + 50)
            {
                if (y2 > y && y2 < y + 50)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void Draw()
        {
           SplashKit.DrawBitmap(character, x, y, enemyopt);
           balls.Draw();
        }
    }
}
