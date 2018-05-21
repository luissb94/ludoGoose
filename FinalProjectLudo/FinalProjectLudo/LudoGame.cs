//Luis Selles Blanes
//V0.03 -  Creating the Main class of the game Ludo
//          Here will be the whole code of the game.
using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class LudoGame
    {
        protected Image imgLudo, imgDice;
        protected Hardware hardware;
        protected Font font;
        protected IntPtr textSpace;
        protected PlayerSelect playSelect;
        protected MenuLudo menu;
        protected Dice dice;

        public LudoGame(Hardware hardware)
        {
            imgLudo = new Image("img/ludoBoard.jpg", 600, 600);
            imgLudo.MoveTo(0, 0);
            this.hardware = hardware;
            this.playSelect = new PlayerSelect(hardware);
            this.menu = new MenuLudo(hardware);
            this.dice = new Dice();
        }

        public void LudoPlayGame()
        {
            bool exit = false;

            playSelect.Show();

            //Main loop of the ludo game. It will show a menu, step by step
            //to show the player hoy to play.
            do
            {
                int numChip;
                exit = false;
                hardware.ClearScreen();
                hardware.DrawImage(imgLudo);
                hardware.UpdateScreen();

                menu.ShowFirstStep();


                do
                {
                    //Repeat until press 1
                } while (hardware.KeyPressed() != Hardware.KEY_1);
                
                //Shows the image of the rollvalue.
                switch(dice.GetRollValue())
                {
                    case 1:
                        imgDice = new Image("img/roll1.jpg", 156, 154);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 2:
                        imgDice = new Image("img/roll2.jpg", 143, 142);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 3:
                        imgDice = new Image("img/roll3.jpg", 143, 142);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 4:
                        imgDice = new Image("img/roll4.jpg", 143, 142);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 5:
                        imgDice = new Image("img/roll5.jpg", 143, 142);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 6:
                        imgDice = new Image("img/roll6.jpg", 143, 142);
                        imgDice.MoveTo(680, 50);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                }

                menu.ShowSecondStep();


                do
                {
                    if (hardware.KeyPressed() == Hardware.KEY_ESC)
                    {
                        exit = true;
                    }
                } while(!exit);
                
            } while (!exit);
        }
    }
}
