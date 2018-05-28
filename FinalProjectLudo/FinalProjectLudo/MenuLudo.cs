//V0.05 - Creating the steps that the user must follow.

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class MenuLudo
    {
        protected IntPtr txtMenu, txtChip;
        protected Hardware hardware;
        protected Font font;
        protected string chipToMove = "";

        public MenuLudo(Hardware hardware)
        {
            this.hardware = hardware;
        }

        //Show the first option of the menu. It only tells the user
        //to press one to roll the dices.
        public void ShowFirstStep()
        {
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);

            txtMenu = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press 1 to roll the dice.", red);

            hardware.WriteText(txtMenu, 640, 330);
            hardware.UpdateScreen();

        }

        //Shows the second option of the menu. It tells the user to
        //enter a chip number to move. The player can only move 1 of his
        // 4 chips
        public void ShowSecondStep()
        {
            char addNumber = ' ';
            chipToMove = "";
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            txtMenu = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter chip number to move: ", red);

            hardware.WriteText(txtMenu, 640, 380);
            hardware.UpdateScreen();
            
            do
            {
                addNumber = hardware.ReadNumber();
                if (addNumber != '!' && addNumber != ' ' && addNumber != '?')
                    this.chipToMove += addNumber;

                txtChip = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    chipToMove, yellow);
                hardware.WriteText(txtChip, 1050, 380);
                hardware.UpdateScreen();

            } while (addNumber != '!');
            
        }

        //Gets the number of the chip the player wants to move.
        public string GetSecondStepValue()
        {
            return this.chipToMove;
        }

        public void GetThirdStep()
        {
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            txtMenu = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press escape to skip the turn", red);
            hardware.WriteText(txtMenu, 640, 430);
            hardware.UpdateScreen();
        }

        public void GetRepeatText()
        {
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            IntPtr txtRepeat;
            txtRepeat = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "You have to REPEAT your turn!: ", yellow);

            hardware.WriteText(txtRepeat, 640, 550);
            hardware.UpdateScreen();
        }

        public void GetErrorChip()
        {
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            IntPtr txtError;
            txtError = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Wrong chip number: ", yellow);

            hardware.WriteText(txtError, 640, 550);
            hardware.UpdateScreen();
        }
    }
}
