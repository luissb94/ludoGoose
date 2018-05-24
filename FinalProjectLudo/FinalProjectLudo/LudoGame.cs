//Luis Selles Blanes
//V0.03 -  Creating the Main class of the game Ludo
//          Here will be the whole code of the game.
//V0.07 -  Added array of boxes.
//V0.08 -  Added list of players, its chips, shows the actual turn
//          with the name of the player and its chips.
//V0.08 -  Added method to display the chips, methods to clear
//          the screen if users enter wrong roll/chip number.

using System;
using Tao.Sdl;
using System.Collections.Generic;

namespace FinalProjectLudo
{
    class LudoGame
    {
        protected Image imgLudo, imgDice;
        protected Hardware hardware;
        protected Font font;
        protected IntPtr textSpace, txtNames, txtDev, txtChips;
        protected PlayerSelect playSelect;
        protected MenuLudo menu;
        protected Dice dice;
        protected Box boxes;
        protected Chip chip;
        protected BoxProperties[] arrayBox = new BoxProperties[100];
        protected List<Chip> chipslist = new List<Chip>();

        public LudoGame(Hardware hardware)
        {
            imgLudo = new Image("img/ludoBoard.jpg", 600, 600);
            imgLudo.MoveTo(0, 0);
            this.hardware = hardware;
            this.playSelect = new PlayerSelect(hardware);
            this.menu = new MenuLudo(hardware);
            this.dice = new Dice(hardware);
            this.boxes = new Box();
            this.chip = new Chip();
            this.chipslist = chip.Load();
        }

        public void DisplayChips()
        {
            hardware.ClearScreen();
            hardware.DrawImage(imgLudo);

            for (int i = 0; i < 16; i++)
            {
                hardware.DrawSprite(chipslist[i].GetImg(),(short) arrayBox[chipslist[i].GetPosChip() - 1].x,
                   (short) arrayBox[chipslist[i].GetPosChip() - 1].y, 0, 0, 25,25);
            }
        }

        public void MoveChip(string color, int num, int positionsToMove)
        {
            foreach (Chip chip in chipslist)
            {
                //Check that im going to move the selected color
                // and chip number.
                if (chip.GetColor() == color && chip.GetNum() == num)
                {
                    //Each colour starts in differents boxes.
                    switch (color)
                    {
                        case "red":
                            if (chip.GetisHome() && positionsToMove == 5)
                            {
                                chip.SetPosChip(39);
                            }
                            break;
                        case "blue":
                            if (chip.GetisHome() && positionsToMove == 5)
                            {
                                chip.SetPosChip(22);
                            }
                            break;
                        case "green":
                            if (chip.GetisHome() && positionsToMove == 5)
                            {
                                chip.SetPosChip(56);
                            }
                            break;
                        case "yellow":
                            if (chip.GetisHome() && positionsToMove == 5)
                            {
                                chip.SetPosChip(5);
                            }
                            break;
                    }
                }

            }
        }

        public void PlayGame()
        {
            List<Player> player = new List<Player>();
            player = playSelect.GetPlayerList();
            short yInitchip;
            bool exit = false;
            string arrayData = "files/boxArrayData.txt";
            playSelect.Show();

            //Define colors, roll, chips variable values;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);
            txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter the roll: ", red);
            arrayBox = boxes.LoadData(arrayData);
            int chipToMove;

            do
            {

                
                //Main loop of the ludo game. It will show a menu, step by step
                //to show the player hoy to play.
                foreach (Player p in player)
                {
                    exit = false;
                    yInitchip = 40;
                    //1 - Shows img background, writes the turn and the name of the player
                    //      and his chips.
                    txtNames = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "Turn:  " + p.GetName() + "            Color: " + p.GetColor(), red);
                    int numChip, rollValue;

                    //Draw the 16 chips in their houses.
                    DisplayChips();

                    hardware.WriteText(txtNames, 650, 20);

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

                    //Developer roll.
                    do
                    {
                        hardware.Clear("roll");
                        rollValue = dice.GetDevRoll();
                    } while (rollValue < 1  || rollValue > 68);
                    

                    //The user enters the chip he wants to move.
                    menu.ShowSecondStep();

                    do
                    {
                        hardware.Clear("chip");
                        chipToMove = Convert.ToInt32(menu.GetSecondStepValue());
                    } while (chipToMove > 1 && chipToMove < 4);


                    //Here will be the move.
                    MoveChip(p.GetColor(), chipToMove, rollValue);

                    //User must press escape to skip the turn
                    menu.GetThirdStep();

                    do
                    {
                        if (hardware.KeyPressed() == Hardware.KEY_ESC)
                        {
                            exit = true;
                        }
                    } while (!exit && !p.GetWin());
                }

            } while (!exit);
            
        }
    }
}
