using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //Creates a list of fireball items ( Aggreagation )
    public class Fireballs : IDesign
    {
        private List<Fireball> fireball;
        public Fireballs()
        {
            fireball = new List<Fireball>();
        }
        public List<Fireball> Fireball
        {
            get { return fireball; }
        }

        public void AddBall()
        {
            fireball.Add(new Fireball());
        }
        public void RemoveBall(Fireball b)
        {
            fireball.Remove(b);
        }
        public void Update()
        {
            foreach (Fireball ball in fireball)
            {
                ball.Update();
            }

        }
        public void Draw()
        {
            foreach (Fireball ball in fireball)
            {
                ball.Draw();
            }

        }

        public void Dispose()
        {
            foreach (Fireball ball in fireball.ToList())
            {
         
                if (ball.Y > 590)
                {
                    RemoveBall(ball);
                }

            }
        }


    }
}
