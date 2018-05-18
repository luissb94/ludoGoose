//Luis Selles Blanes
//V0.03 -  Creating the Main class of the game Ludo
//          Here will be the whole code of the game.
using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class LudoGame
    {
        protected Image imgLudo;
        protected Hardware hardware;
        protected Font font;
        protected IntPtr textSpace;


        public LudoGame(Hardware hardware)
        {
            imgLudo = new Image("img/ludoBoard.jpg", 600, 600);
            imgLudo.MoveTo(0, 0);
            this.hardware = hardware;
        }

        public void LudoPlayGame()
        {
            bool exit = false;
            hardware.ClearScreen();
            hardware.DrawImage(imgLudo);
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
