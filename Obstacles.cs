using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Game
{
    //Used to have a collection of Pipes ( Aggregation )
    public class Obstacles : IDesign
    {

        private List<Pipe> pipes;
        int num = 0;
        int randnum;
        Random rand = new Random();

        public Obstacles()
        {
            pipes = new List<Pipe>();
            pipes.Add(new Pipe());
            randnum = rand.Next(3);
        }
        public Pipe AddPipe()
        {
            Pipe pipe = new Pipe();
            pipes.Add(pipe);
            
            return pipe;
        }
        public void RemovePipe(Pipe p)
        {
            pipes.Remove(p);
           
        }
        public void Update()
        {
            num++;
            if (num%5000 == 0) {
                int x = 0;
                //Generates 0-3 pipes nearby every regular interval
                randnum = rand.Next(3);
                for (int i = 0; i < randnum; i++)
                {
                    Pipe pipe = AddPipe();
                    pipe.X = pipe.X + x;
                    x += 200; 
                }
                
            }

            foreach (Pipe pipe in pipes)
            {
                pipe.Update();
            }
        }
        public List<Pipe> Pipes
        {
            get { return pipes; }
        }


        public void Draw()
        { 
          foreach(Pipe pipe in pipes)
            {
                pipe.Draw();
            }
        }

        public void Dispose()
        {
            //REMOVING OLD PIPES
            foreach (Pipe p in pipes.ToList())
            {

                if (p.X < -500)
                {
                    pipes.Remove(p);
                }

            }

        }

    }
}
