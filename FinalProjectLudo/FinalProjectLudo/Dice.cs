//Luis Sellés Blanes
//V0.01 - Creating dice class.

using System;
using Tao.Sdl;


namespace FinalProjectLudo
{
    class Dice
    {
        protected Hardware hardware;
        protected Random rand_num;
        protected int number;
        protected IntPtr txtRoll;
        protected Font font = new Font("font/fuenteproy.ttf", 12);

        public Dice()
        {
            rand_num = new Random();
        }

        public Dice(Hardware hardware)
        {
            rand_num = new Random();
            this.hardware = hardware;
        }

        //Method to get a roll between 1 and 6
        public int GetRollValue()
        {
            number = rand_num.Next(1, 7);
            return number;
        }

        //This method lets the developer gets the roll he wants to
        //make tests.
        public int GetDevRoll()
        {
            char addNumber = ' ';
            string rollValue = "";
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);

            do
            {
                addNumber = hardware.ReadNumber();
                if (addNumber != '!' && addNumber != ' ' && addNumber != '?')
                    rollValue += addNumber;

                txtRoll = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    rollValue, yellow);
                hardware.WriteText(txtRoll, 950, 330);
                hardware.UpdateScreen();

            } while (addNumber != '!');

            if(rollValue != "")
                number = Convert.ToInt32(rollValue);

            return number;
        }
    }
}
