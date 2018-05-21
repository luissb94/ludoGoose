﻿//V0.05 - Creating the steps that the user must follow.

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class MenuLudo
    {
        protected IntPtr txtMenu, txtChip;
        protected Hardware hardware;
        protected Font font;
        protected string chipToMove;

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
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0)
                ;
            txtMenu = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter chip number to move: ", red);

            hardware.WriteText(txtMenu, 640, 380);
            hardware.UpdateScreen();
            
            do
            {
                addNumber = hardware.ReadNumber();
                if (addNumber != '!' && addNumber != ' ')
                    chipToMove += addNumber;

                txtChip = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    chipToMove, yellow);
                hardware.WriteText(txtChip, 950, 380);
                hardware.UpdateScreen();

            } while (addNumber != '!');
            
        }

        public string GetSecondStepValue()
        {

            return this.chipToMove;
        }

    }
}