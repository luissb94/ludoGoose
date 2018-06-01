//Luis Selles
//V0.10 -  Created the last static content.

using System;
using System.Collections.Generic;
using Tao.Sdl;

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
        protected BoxGoose[] arrayBoxGoose = new BoxGoose[63];
        protected List<Chip> chipslist = new List<Chip>();
        protected List<Player> player = new List<Player>();
        protected int turn = 4;
        protected MenuLudo menu;
        protected Font font;

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
            this.player = playSelect.GetPlayerList();
            this.menu = new MenuLudo(hardware);
        }

        

        public void DisplayChips()
        {
            hardware.ClearScreen();
            hardware.DrawImage(imgGoose);

            foreach(Chip ch in chipslist)
            {
                switch(ch.GetColor())
                {
                    case "red":
                        hardware.DrawSprite(ch.GetImg(),
                            (short)arrayBoxGoose[ch.GetPosChip()].xRed,
                            (short)arrayBoxGoose[ch.GetPosChip()].yRed, 0, 0, 25, 25);
                        break;
                    case "blue":
                        hardware.DrawSprite(ch.GetImg(),
                            (short)arrayBoxGoose[ch.GetPosChip()].xBlue,
                            (short)arrayBoxGoose[ch.GetPosChip()].yBlue, 0, 0, 25, 25);
                        break;
                    case "yellow":
                        hardware.DrawSprite(ch.GetImg(),
                            (short)arrayBoxGoose[ch.GetPosChip()].xYellow,
                            (short)arrayBoxGoose[ch.GetPosChip()].yYellow, 0, 0, 25, 25);
                        break;
                    case "green":
                        hardware.DrawSprite(ch.GetImg(),
                            (short)arrayBoxGoose[ch.GetPosChip()].xGreen,
                            (short)arrayBoxGoose[ch.GetPosChip()].yGreen, 0, 0, 25, 25);
                        break;
                }
            }
        }

        public void JumpToNextGoose(int pos)
        {
            for(int i = pos + 1; i < (pos+7); i++)
            {
                if(arrayBoxGoose[i].isGoose)
                {
                    chip.SetPosChip(i);
                }
            }
        }

        public void MoveChip(string color, int num, int rolledValue, ref int turn,
            string lang)
        {
            IntPtr txtOca;


            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);

            if(lang == "spanis")
            {
                txtOca = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "De oca a oca y tiras porque te toca! ", yellow);
            }
            else
            {
                txtOca = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Goose to goose, repeat your turn!", yellow);
            }
            

            foreach (Chip chip in chipslist)
            {
                //Check that im going to move the selected color
                // and chip number.
                if (chip.GetColor() == color && chip.GetNum() == num)
                {
                    //Switch for every color.
                    switch (color)
                    {
                        case "red":
                            //Switch for every value instead of 'if'.
                            switch (rolledValue)
                            {
                                //Added a new attribute to chip, to check how many
                                //positions have advanced, because the chip wont enter
                                //his finish color boxes until it haven't advanced 64 positions
                                case 1:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    
                                    //Now check gooses.
                                    if(chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    break;
                                case 2:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    if (chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    break;
                                case 3:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    if (chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    break;
                                case 4:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    if (chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    break;
                                case 5:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    if (chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    break;
                                case 6:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    if (chip.GetPosChip() == 5 || chip.GetPosChip() == 9 ||
                                        chip.GetPosChip() == 14 || chip.GetPosChip() == 18 ||
                                        chip.GetPosChip() == 23 || chip.GetPosChip() == 27 ||
                                        chip.GetPosChip() == 32 || chip.GetPosChip() == 36 ||
                                        chip.GetPosChip() == 45 || chip.GetPosChip() == 50 ||
                                        chip.GetPosChip() == 54)
                                    {
                                        JumpToNextGoose(chip.GetPosChip());
                                        player[turn].SetRepeatTurn(true);
                                        hardware.WriteText(txtOca, 670, 500);
                                    }
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }

                            break;
                        case "blue":
                            switch (rolledValue)
                            {
                                case 1:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 2:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 3:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 4:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 5:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 6:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                        case "green":
                            switch (rolledValue)
                            {
                                case 1:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 2:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 3:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 4:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 5:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 6:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                        case "yellow":
                            switch (rolledValue)
                            {
                                case 1:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 2:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 3:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 4:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 5:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    break;
                                case 6:
                                    chip.SetPosChip((chip.GetPosChip() + rolledValue) - 1);
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                    }
                }

            }
        }



        public void Play(string lang)
        {
            bool exit;
            int chipToMove;

            IntPtr txtNames, txtChipsOut, txtDev, txtExit;
            int key;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);
            txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "IS NOT FINISHED, PRESS ESCAPE ", red);

            playSelect.Show(lang);

            arrayBoxGoose = boxes.LoadDataG("files/boxArrayDataGoose.txt");
            DisplayChips();

            hardware.UpdateScreen();

            for (int i = 0; i < turn; i++)
            {
                exit = false;

                if (lang == "spanish")
                {
                    txtNames = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Turno:  " + player[i].GetName() + "            Color: " +
                        player[i].GetColor(), red);
                    txtChipsOut = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Fichas fuera: " + player[i].GetChipsOut(), yellow);
                    txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "TODAVIA EN DESARROLLO", red);
                    txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "ESCAPE PARA SALIR", red);
                }
                else
                {
                    txtNames = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Turn:  " + player[i].GetName() + "            Color: " +
                        player[i].GetColor(), red);
                    txtChipsOut = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Chips out: " + player[i].GetChipsOut(), yellow);
                    txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "STILL DEVELOPING ", red);
                    txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "ESCAPE FOR EXIT", red);
                }

                int rollValue = 0;
                //Draw the 16 chips in their houses.
                DisplayChips();

                hardware.WriteText(txtNames, 670, 20);
                hardware.WriteText(txtChipsOut, 670, 40);
                hardware.WriteText(txtDev, 750, 300);
                hardware.WriteText(txtExit, 750, 400);
                hardware.UpdateScreen();

                //Commented because of the devRoll.
                /*menu.ShowFirstStep(lang);

                do
                {
                    //Repeat until press 1
                } while (hardware.KeyPressed() != Hardware.KEY_1);


                rollValue = dice.GetRollValue();

                //Shows the image of the rollvalue.
                switch (rollValue)
                {
                    case 1:
                        imgDice = new Image("img/roll1.jpg", 156, 154);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 2:
                        imgDice = new Image("img/roll2.jpg", 143, 142);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 3:
                        imgDice = new Image("img/roll3.jpg", 143, 142);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 4:
                        imgDice = new Image("img/roll4.jpg", 143, 142);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 5:
                        imgDice = new Image("img/roll5.jpg", 143, 142);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                    case 6:
                        imgDice = new Image("img/roll6.jpg", 143, 142);
                        imgDice.MoveTo(710, 100);
                        hardware.DrawImage(imgDice);
                        hardware.UpdateScreen();
                        break;
                }

                //hardware.WriteText(txtDev, 640, 330);
                hardware.UpdateScreen();
                

                //Here will be the move. Always be the chip number 1.
                MoveChip(player[i].GetColor(), 1, rollValue, ref i, lang);
                

                //User must press escape to skip the turn
                menu.GetThirdStep(lang);


                if (player[i].GetWin())
                {
                    i = turn;
                }
                else if (player[i].GetRepeatTurn())
                {
                    player[i].SetRepeatTurn(false);
                    i--;
                    menu.GetRepeatText(lang);
                }
                else if (i == playSelect.GetNumPlayers() - 1 && !player[i].GetWin())
                {
                    i = -1;
                }


                boxes.SaveData(arrayBox);*/

                do
                {
                    if (hardware.KeyPressed() == Hardware.KEY_ESC)
                    {
                        exit = true;
                        i = 4;
                    }
                } while (!exit);
            }

        }
    }
}
