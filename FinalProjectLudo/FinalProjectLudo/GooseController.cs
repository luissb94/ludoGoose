//Luis Selles
//V0.10 -  Created the last static content.

using System;
using System.Collections.Generic;
namespace FinalProjectLudo
{
    class GooseController
    {
        protected Image imgGoose, imgDice;
        protected Hardware hardware;
        protected IntPtr textSpace;
        protected PlayerSelect playSelect;
        protected Dice dice;
        protected Box boxes;
        protected Chip chip;
        protected BoxProperties[] arrayBox = new BoxProperties[100];
        protected List<Chip> chipslist = new List<Chip>();

        public GooseController(Hardware hardware)
        {
            imgGoose = new Image("img/gooseBoard.jpg", 650, 650);
            imgGoose.MoveTo(0, 0);
            this.playSelect = new PlayerSelect(hardware);
            this.hardware = hardware;
            this.dice = new Dice(hardware);
            this.boxes = new Box();
            this.chip = new Chip();
            this.chipslist = chip.Load("goose");
        }

        public void Play(string lang)
        {
            int key;

            playSelect.Show(lang);

            hardware.ClearScreen();
            hardware.DrawImage(imgGoose);
            hardware.UpdateScreen();

            
            do
            {
                key = hardware.KeyPressed();
            } while (key != Hardware.KEY_ESC);
            
        }
    }
}
