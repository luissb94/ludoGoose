//Luis Selles Blanes
//V0.01 - Creating WelcomeScreen Class.
//V0.02 - Changing things to make the welcomeScreen works. 
//              Added jpeg.dll to make it work

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class WelcomeScreen
    {
        bool escPressed , exitGame;
        protected Image imgWelcome;
        protected Hardware hardware;
        Font font;
        IntPtr textSpace;
        IntPtr myName;

        public WelcomeScreen(Hardware hardware)
        {
            exitGame = false;
            imgWelcome = new Image("img/welcomescreen.jpg", 1152, 648);
            imgWelcome.MoveTo(0, 0);
            this.hardware = hardware;
        }

        //Method to show the welcomeScreen, it will last until player press space.
        public void ShowWelcomeScreen()
        {
            bool spacePressed = false, escPressed = false;
            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            textSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press 'SPACE' to continue", red);

            myName = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Luis Selles", blue);

            hardware.DrawImage(imgWelcome);
            hardware.WriteText(textSpace, 325, 450);

            hardware.WriteText(myName, 480, 350);
            hardware.UpdateScreen();

            do
            {
                int keyPressed = hardware.KeyPressed();
                if (keyPressed == Hardware.KEY_ESC)
                {
                    escPressed = true;
                    exitGame= true;
                }
                else if (keyPressed == Hardware.KEY_SPACE)
                {
                    spacePressed = true;
                    exitGame = false;
                }
            }
            while (!escPressed && !spacePressed);
        }

        public bool Exit()
        {
            return exitGame;
        }
    }
}
