using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Game
{
    class Player : Entity , IDesign
    {
        Bitmap character;
        DrawingOptions playeropt;
        double x;
        bool dead;
        bool forward = true;
        bool standing;
        bool play = true;
        double g;
        int activate = 0;
        private int walkingCurrentFrame=12;
        double height;
        private Stopwatch frameTimer;
        Vector2D _velocity;

     


        public Player()
        {
            frameTimer = new Stopwatch();
            frameTimer.Start();

            character = SplashKit.LoadBitmap("Character", "Resources/character.png");
            character.SetCellDetails(400, 600, 4, 4, 16);
            playeropt = SplashKit.OptionScaleBmp(0.1, 0.1);
            playeropt = SplashKit.OptionWithBitmapCell(15, playeropt);
            x = -100;
            g = 10.81;
            dead = false;
            _velocity.Y = +4.0;
            height = 100;
            standing = false;
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        
        public bool Standing
        {
            get
            {
                return standing;
            }
            set
            {
                standing = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                x = value;
            }
        }
        public void Jump()
        {
            if (activate <= 1)
            {
                playeropt = SplashKit.OptionWithBitmapCell(14, playeropt);
                _velocity.Y = -0.6;
                standing = false;
                activate++;
            }
        }

        public void MoveXBack()
        {
            if (activate == 0)
            {
                if (x > -150)
                {
                    x -= 0.3;
                }
            }
        }
        public void MoveXForward()
        {
            if (activate == 0)
            {

                if (frameTimer.ElapsedMilliseconds >= 100) // Check if 500ms have passed
                {
                    // Set the current option
                    playeropt = SplashKit.OptionWithBitmapCell(walkingCurrentFrame, playeropt);

                    // Increment the frame and cycle back to 12 if it goes beyond 15
                    walkingCurrentFrame--;
                    if (walkingCurrentFrame < 8 )
                    {
                        walkingCurrentFrame = 11;
                    }

                    frameTimer.Restart(); // Restart the timer
                }
                x += 0.3;
            }
        }
        public void Ymove()
        {
            _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0, 0.001));
            height += _velocity.Y;

        }
        public void Died()
        {

            playeropt = SplashKit.OptionWithBitmapCell(2, playeropt);
            _velocity.Y = -0.4;


        }
        public void DiedAnimation()
        {

            Ymove();


        }

        public bool Forward
        {
            get { return forward; }
            set { forward = value; }
        }
        public void Update()
        {
            if (play)
            {
                if (x>-150)
                {
                    x -= 0.1;
                }
 


                if (!standing)
                {
                    Ymove();
                }

                ManageFloor();
            }
        }
        public void ManageFloor()
        {
            if (height >= 180)
            {
                activate = 0;

                standing = true;
                height = 180;

                if (frameTimer.ElapsedMilliseconds >= 100) // Check if 500ms have passed
                {
                    // Set the current option
                    playeropt = SplashKit.OptionWithBitmapCell(walkingCurrentFrame, playeropt);

                    // Increment the frame and cycle back to 12 if it goes beyond 15
                    walkingCurrentFrame++;
                    if (walkingCurrentFrame > 15)
                    {
                        walkingCurrentFrame = 12;
                    }

                    frameTimer.Restart(); // Restart the timer
                }
            }
        }
        public  bool Collision (double x1, double y2)
        {
           
            if (x+100>x1 && x < x1+100)
            {
                if ((height > y2 + 100))
                {
                 
                    forward = false;
                    return false;
                     
                    
                }
                else
                {
                    forward = true;
                    standing = false;

                    if (height > y2+98)
                    {
                        height = y2+98;
                    }

                    return true;
                }
            }
            else
            {
                forward = true;
                standing = false;
                return true;
            }
        }
     
        public void Draw()
        {
            SplashKit.DrawBitmap(character,x, height, playeropt);

        }
    }
}
