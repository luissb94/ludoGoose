//Luis Selles
//V0.02 - Creating credits Screen to read credits from file.
//          Reading the credits from a file and showing it in the credits.
using System;
using Tao.Sdl;
using System.IO;


namespace FinalProjectLudo
{
    class CreditsScreen
    {
        protected IntPtr textCredits;
        protected Font font;
        protected Hardware hardware;
        protected Image imgCred;

        public CreditsScreen(Hardware hardware)
        {
            imgCred = new Image("img/credits.jpg", 1152, 648);
            imgCred.MoveTo(0, 0);

            this.hardware = hardware;
        }

        //Creating Show method, it will show the credits one line by one.
        //If you click ESCAPE after all the credits are shown it will exit from the screen.
        public void Show()
        {
            short yInit = 200;
            bool finish = false;
            hardware.ClearScreen();
            hardware.DrawImage(imgCred);
            hardware.UpdateScreen();

            while (!finish)
            {
                yInit = 200;

                font = new Font("font/fuenteproy.ttf", 20);
                Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);

                string[] lines = File.ReadAllLines("files/credits.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    textCredits = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        lines[i], blue);
                    hardware.WriteText(textCredits, 300, yInit);
                    hardware.UpdateScreen();
                    hardware.Pause(3000);
                    yInit += 100;

                }

                do
                {
                    if (hardware.KeyPressed() == Hardware.KEY_ESC)
                    {
                        finish = true;
                    }
                } while (!finish);
                
            }
        }
    }
}
