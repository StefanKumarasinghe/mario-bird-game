using System;
using SplashKitSDK;

namespace Game
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Mario Bird", 450, 590);
            Game game = new Game();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                //IF RUN SENDS AN RETURN OF TRUE THE GAME RESTARTS
                if (game.Run())
                {
                    game = new Game();
                }
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
    
}
