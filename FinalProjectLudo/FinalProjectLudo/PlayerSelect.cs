//Luis Selles
//V0.03 - Class to make the players enter their name so it can be shown
//          on the next image of the game.

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class PlayerSelect
    {
        protected IntPtr textPlayer1, textPlayer2, textPlayer3, textPlayer4,choosePlayer;
        protected Font font;
        protected Hardware hardware;
        protected Image imgPlayerSelect;

        public PlayerSelect(Hardware hardware)
        {
            bool exitPlayerSelect = false;
            imgPlayerSelect = new Image("img/playerSelect.jpg", 1152, 652);
            imgPlayerSelect.MoveTo(0, 0);
            this.hardware = hardware;
        }

        //This method will show 4 "insert player name" and, coming soon, it will let
        //the users enter their name.
        public void ShowPlayerSelect()
        {
            bool exit = false;

            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);

            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textPlayer1 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player one: ", red);

            textPlayer2 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player two:", blue);

            textPlayer3 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player three:", green);

            textPlayer4 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player four:", yellow);

            choosePlayer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "ENTER YOUR NAMES:", black);

            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(textPlayer2, 200, 300);
            hardware.WriteText(textPlayer3, 200, 400);
            hardware.WriteText(textPlayer4, 200, 500);
            hardware.WriteText(choosePlayer, 370, 50);

            hardware.UpdateScreen();


            do
            {
                if (hardware.KeyPressed() == Hardware.KEY_ESC)
                {
                    exit = true;
                }
            } while (!exit);
        }

        //This method is only to set player name against IA.
        public void ShowPlayerSelectAgainstIA()
        {
            bool exit = false;

            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textPlayer1 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player one: ", red);

            choosePlayer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "ENTER YOUR NAMES:", black);

            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(choosePlayer, 370, 50);

            hardware.UpdateScreen();


            do
            {
                if (hardware.KeyPressed() == Hardware.KEY_ESC)
                {
                    exit = true;
                }
            } while (!exit);
        }
    }
}
