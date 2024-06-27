using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //One Fireball item
    public class Fireball : IEntity, IDesign
    {
        private Bitmap ball;
        private DrawingOptions ballopt;
        double x;
        double y;
        double speed;
        Vector2D _velocity;

        
        Random rand = new Random();   
        
        
        public Fireball() {
          SoundEffect fireSound = SplashKit.LoadSoundEffect("PauseSound", "Resources/Fireball.mp3");
          SplashKit.PlaySoundEffect(fireSound);
            //Fireballs are thrown up slightly and falls down from the same location
            _velocity.Y = -0.1;
          ball = SplashKit.LoadBitmap("Ball", "Resources/fireball.png");
          ballopt = SplashKit.OptionScaleBmp(0.2, 0.2);
          x = 200;
          y = 50;  
          speed = (0.06);
        }
        public void Update()
        {
            _velocity = SplashKit.VectorAdd(_velocity, SplashKit.VectorTo(0,0.00005));
            y += _velocity.Y;
            x -= speed;
        }
        public bool Collision(double x1, double y2)
        {
            // When the fireball collides with the player game ends
            if ((((x1 > x-30) && x1 < ( x + 30) )) && y2 > y-100 && y2 < (y+ -50))
            {
               return false;
            } else {
               return true;
            }
        }

        public double X
        {
            get { return x; }
        }
        public double Y
        {
            get { return y; }
        }
        public void Draw()
        {
            SplashKit.DrawBitmap(ball, x, y, ballopt);
        }

    }
}
