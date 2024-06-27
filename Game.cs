using SplashKitSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Game
{
    class Game
    {
        private bool play;
        private bool died;
        private bool paused;
        private double distance;
        private Player player = new Player();
        private Enemy enemy = new Enemy();
        private BaseFloor floor = new BaseFloor();
        private Obstacles pipe = new Obstacles();
        private Fireballs balls;
        private Scene scene = new Scene();
        private List<Pipe> pipes;
        private List<Fireball> fireballs;
        private bool keyPressedForward = false;

        SoundEffect Over = SplashKit.LoadSoundEffect("Over", "Resources/Over.mp3");
        Music backgroundMusic = SplashKit.LoadMusic("GameMusic", "Resources/Game.mp3");



        public Game()
        {
            SplashKit.FadeMusicIn(backgroundMusic,1000, 1000);
            died = false;
            play = true;
            paused = false;
            distance = 0;
            balls = enemy.Fireballs;
            pipes = pipe.Pipes;
            fireballs = balls.Fireball;
        }


        public bool Run()
        {
            
            if (SplashKit.KeyTyped(KeyCode.PKey))
            {
                if (paused)
                {
                    paused = false;
                }else
                {
                    paused = true;
                }
            }

            if (play)
            {
                if (paused)
                {
                    Paused();
                }
                else
                {
                    Play();
                }

            }else
            {
                if (GameOver())
                {
                    return true;
                }
            }

            return false;

        }
        public void Play()
        {
            
        
            distance += 0.1;
  
  
               floor.Update();
               scene.Update();
            



            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
     
                    player.Jump();
              
          
            }
            if (SplashKit.KeyDown(KeyCode.AKey))
            {

       
                player.MoveXBack();


            }
            if (SplashKit.KeyDown(KeyCode.DKey))
            {
                keyPressedForward = true;

                player.MoveXForward();


            }
            if (SplashKit.KeyUp(KeyCode.DKey))
            {
                keyPressedForward = false;

            }


            play = CollisionTest();
            Update();
            Draw();
        }

        public void Update()
        {

            player.Update();
            pipe.Update();
            enemy.Update();
            balls.Update();
            balls.Dispose();
            pipe.Dispose();
        }
        public void Draw()
        {
            scene.Draw();
            if (distance/10>300)
            {
                SplashKit.LoadFont("CustomFont", "text.ttf");
                SplashKit.DrawText("Stefan Ralph Kumarasinghe 2022", SplashKitSDK.Color.Black, "CustomFont", 20, 1100 - (distance / 5), 200);
                SplashKit.DrawText("My Mario Bird", SplashKitSDK.Color.Black, "CustomFont", 30, 1100 - (distance / 5), 230);
                SplashKit.DrawText("OOP Project", SplashKitSDK.Color.Black, "CustomFont", 20, 1100 - (distance / 5), 270);


            }
            pipe.Draw();
            floor.Draw();
            SplashKit.LoadFont("CustomFont", "text.ttf");
            SplashKit.DrawText("Controls" , SplashKitSDK.Color.Black, "CustomFont", 20, 10, 510);
            SplashKit.DrawText("Space - Jump | P - Pause | Double Space - Jump Twice ", SplashKitSDK.Color.Black, "CustomFont", 15, 10, 540);
            SplashKit.DrawText("Don't hit the fireballs and pipe sides but you can walk on it...", SplashKitSDK.Color.Red, "CustomFont", 10, 10, 570);

            player.Draw();
            enemy.Draw();
            balls.Draw();
            SplashKit.LoadFont("CustomFont", "text.ttf");

            SplashKit.DrawText(((int)distance / 10).ToString() + " XP", SplashKitSDK.Color.Black, "CustomFont", 30, 10, 10);
       
        }
        public bool GameOver()
        {
            if (!died)
            {
                SplashKit.StopMusic();
                player.Died();
                
                SplashKit.PlaySoundEffect(Over);
                died = true;
            }
            scene.Draw();
            pipe.Draw();
            floor.Draw();
            player.Draw();
            player.DiedAnimation();
            
            enemy.Draw();
            SplashKit.LoadFont("CustomFont", "text.ttf");
            SplashKit.DrawText("YOUR HIGH SCORE: " + ((int)distance / 10).ToString(), SplashKitSDK.Color.Black, "CustomFont", 20, 10, 10); 
            SplashKit.DrawText("Press space to start again...", SplashKitSDK.Color.Black, "CustomFont", 15, 10, 550);
          
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                SplashKit.FreeSoundEffect(Over);
                return true;
            }
            return false;

        }
        public bool Paused()
        {
            // Ensure the custom font is loaded before using it
            SplashKit.LoadFont("CustomFont", "text.ttf");

            // Draw a semi-transparent background to indicate the paused state
            SplashKit.FillRectangle(SplashKitSDK.Color.Black, 0, 0, SplashKit.ScreenWidth(), SplashKit.ScreenHeight());

            // Draw the "GAME PAUSED" text in a bright, noticeable color with a custom font
            SplashKit.DrawText("GAME PAUSED", SplashKitSDK.Color.Yellow, "CustomFont", 50, 50, 100);

            // Draw the instruction text in a lighter color for contrast with a custom font
            SplashKit.DrawText("To unpause press P again", SplashKitSDK.Color.White, "CustomFont", 30, 50, 200);
            SplashKit.DrawText("This game was created by Stefan Ralph Kumarasinghe", SplashKitSDK.Color.White, "CustomFont", 15, 30, 300);

            return false;
        }


        public bool CollisionTest()
        {
    
            foreach (Fireball ball in fireballs.ToList())
            {
                play = (ball.Collision(player.X, player.Height));
                if (!play)  { return false; }
           
            }

            foreach (Pipe p in pipes.ToList())
            {
                play = player.Collision(p.X, p.Y);
                if (!play) { return false; }
            }

            return true;
        }

    }
}
