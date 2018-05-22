//Luis Selles Blanes
//V0.03 -  Creating the Main class of the game Ludo
//          Here will be the whole code of the game.
//V0.07 -  Added array of boxes.

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class LudoGame
    {
        protected Image imgLudo, imgDice;
        protected Hardware hardware;
        protected Font font;
        protected IntPtr textSpace, txtNames, txtDev;
        protected PlayerSelect playSelect;
        protected MenuLudo menu;
        protected Dice dice;
        protected Box boxes;
        protected BoxProperties[] arrayBox = new BoxProperties[100];

        public LudoGame(Hardware hardware)
        {
            imgLudo = new Image("img/ludoBoard.jpg", 600, 600);
            imgLudo.MoveTo(0, 0);
            this.hardware = hardware;
            this.playSelect = new PlayerSelect(hardware);
            this.menu = new MenuLudo(hardware);
            this.dice = new Dice(hardware);
            this.boxes = new Box();
        }

        public void PlayGame()
        {
            bool exit = false;
            string arrayData = "files/boxArrayData.txt";
            playSelect.Show();
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            font = new Font("font/fuenteproy.ttf", 12);
            arrayBox = boxes.LoadData(arrayData);
            txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter the roll: ", red);
            //Main loop of the ludo game. It will show a menu, step by step
            //to show the player hoy to play.
            do
            {

                int numChip, rollValue;
                exit = false;
                hardware.ClearScreen();
                hardware.DrawImage(imgLudo);
                
                //hardware.WriteText(txtNames, 800, 100);

                //I used this here just to make sure they work.
                //boxes.UploadToFtp();
                //boxes.DownloadFromFtp();


                hardware.UpdateScreen();

                //Commented because of the devRoll.
                /*menu.ShowFirstStep();
                

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
                }*/

                hardware.WriteText(txtDev, 640, 330);
                hardware.UpdateScreen();
               

                rollValue = dice.GetDevRoll();
                

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
