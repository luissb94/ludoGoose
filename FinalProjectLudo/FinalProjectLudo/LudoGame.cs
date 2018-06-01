//Luis Selles Blanes
//V0.03 -  Creating the Main class of the game Ludo
//          Here will be the whole code of the game.
//V0.07 -  Added array of boxes.
//V0.08 -  Added list of players, its chips, shows the actual turn
//          with the name of the player and its chips.
//V0.08 -  Added method to display the chips, methods to clear
//          the screen if users enter wrong roll/chip number.
//V0.12 - Added heritage

using System;
using Tao.Sdl;
using System.Collections.Generic;

namespace FinalProjectLudo
{
    class LudoGame : Screen
    {
        protected Image imgLudo, imgDice, imgLudoLL;
        protected Font font;
        protected IntPtr textSpace, txtNames, txtDev, txtChips, txtChipsOut,
            txtLimit, txtKill;
        protected PlayerSelect playSelect;
        protected MenuLudo menu;
        protected Dice dice;
        protected Box boxes;
        protected Chip chip;
        protected BoxProperties[] arrayBox = new BoxProperties[100];
        protected BoxProperties[] arrayBoxLL = new BoxProperties[85];
        protected List<Chip> chipslist = new List<Chip>();
        protected List<Player> player = new List<Player>();
        protected int turn = 4;

        public LudoGame(Hardware hardware) : base(hardware)
        {
            imgLudo = new Image("img/ludoBoard.jpg", 600, 600);
            imgLudo.MoveTo(0, 0);
            imgLudoLL = new Image("img/ludoLimitless.jpg", 600, 600);
            imgLudoLL.MoveTo(0, 0);
            this.hardware = hardware;
            this.playSelect = new PlayerSelect(hardware);
            this.menu = new MenuLudo(hardware);
            this.dice = new Dice(hardware);
            this.boxes = new Box();
            this.chip = new Chip();
            this.chipslist = chip.Load("ludo");
            this.player = playSelect.GetPlayerList();
        }
        
        //Check deaths
        public void CheckDeath(string color, string lang, int turn)
        {
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);

            
            //First I go over all the chips
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 16; j++)
                {

                    //Now I check if both chips are in the same position.
                    if(chipslist[i].GetPosChip() - 1 == chipslist[j].GetPosChip() - 1 )
                    {
                        //Now I discard the same chip, 2 for so the same chip is
                        //compared.
                        if(i != j )
                        {
                            //Now check if the chip are different colors.
                            if(chipslist[i].GetColor() != chipslist[j].GetColor())
                            {
                                if(chipslist[i].GetColor() == color)
                                {
                                    Console.WriteLine("La ficha " + color + " ha matado a la ficha " +
                                        chipslist[j].GetColor());

                                    player[turn].AddKills();

                                    if (lang == "spanish")
                                    {
                                        txtKill = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                                                "La ficha "+color+" ha matado a la ficha "+
                                                chipslist[j].GetColor(), yellow);
                                        
                                    }
                                    else
                                    {
                                        txtKill = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                                                color + "  chip killed the " +
                                                chipslist[j].GetColor() +" chip", yellow);
                                    }

                                    hardware.WriteText(txtKill, 640, 290);
                                    switch (chipslist[j].GetColor())
                                    {
                                        case "red":
                                            switch (chipslist[j].GetNum())
                                            {
                                                case 1:
                                                    chipslist[j].SetPosChip(99);
                                                    break;
                                                case 2:
                                                    chipslist[j].SetPosChip(100);
                                                    break;
                                                case 3:
                                                    chipslist[j].SetPosChip(101);
                                                    break;
                                                case 4:
                                                    chipslist[j].SetPosChip(102);
                                                    break;
                                            }

                                            break;
                                        case "blue":
                                            switch (chipslist[j].GetNum())
                                            {
                                                case 1:
                                                    chipslist[j].SetPosChip(103);
                                                    break;
                                                case 2:
                                                    chipslist[j].SetPosChip(104);
                                                    break;
                                                case 3:
                                                    chipslist[j].SetPosChip(105);
                                                    break;
                                                case 4:
                                                    chipslist[j].SetPosChip(106);
                                                    break;
                                            }
                                            break;
                                        case "green":
                                            switch (chipslist[j].GetNum())
                                            {
                                                case 1:
                                                    chipslist[j].SetPosChip(107);
                                                    break;
                                                case 2:
                                                    chipslist[j].SetPosChip(108);
                                                    break;
                                                case 3:
                                                    chipslist[j].SetPosChip(109);
                                                    break;
                                                case 4:
                                                    chipslist[j].SetPosChip(110);
                                                    break;
                                            }
                                            break;
                                        case "yellow":
                                            switch (chipslist[j].GetNum())
                                            {
                                                case 1:
                                                    chipslist[j].SetPosChip(111);
                                                    break;
                                                case 2:
                                                    chipslist[j].SetPosChip(112);
                                                    break;
                                                case 3:
                                                    chipslist[j].SetPosChip(113);
                                                    break;
                                                case 4:
                                                    chipslist[j].SetPosChip(114);
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                    
                                else
                                {
                                    if (lang == "spanish")
                                    {
                                        txtKill = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                                                "La ficha " + color + " ha matado a la ficha " +
                                                chipslist[i].GetColor(), yellow);
                                    }
                                    else
                                    {
                                        txtKill = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                                                color + "  chip killed the " +
                                                chipslist[i].GetColor() + " chip", yellow);
                                    }

                                    player[turn].AddKills();

                                    hardware.WriteText(txtKill, 640, 290);

                                    switch (chipslist[i].GetColor())
                                    {
                                        case "red":
                                            switch (chipslist[i].GetNum())
                                            {
                                                case 1:
                                                    chipslist[i].SetPosChip(99);
                                                    break;
                                                case 2:
                                                    chipslist[i].SetPosChip(100);
                                                    break;
                                                case 3:
                                                    chipslist[i].SetPosChip(101);
                                                    break;
                                                case 4:
                                                    chipslist[i].SetPosChip(102);
                                                    break;
                                            }

                                            break;
                                        case "blue":
                                            switch (chipslist[i].GetNum())
                                            {
                                                case 1:
                                                    chipslist[i].SetPosChip(103);
                                                    break;
                                                case 2:
                                                    chipslist[i].SetPosChip(104);
                                                    break;
                                                case 3:
                                                    chipslist[i].SetPosChip(105);
                                                    break;
                                                case 4:
                                                    chipslist[i].SetPosChip(106);
                                                    break;
                                            }
                                            break;
                                        case "green":
                                            switch (chipslist[i].GetNum())
                                            {
                                                case 1:
                                                    chipslist[i].SetPosChip(107);
                                                    break;
                                                case 2:
                                                    chipslist[i].SetPosChip(108);
                                                    break;
                                                case 3:
                                                    chipslist[i].SetPosChip(109);
                                                    break;
                                                case 4:
                                                    chipslist[i].SetPosChip(110);
                                                    break;
                                            }
                                            break;
                                        case "yellow":
                                            switch (chipslist[i].GetNum())
                                            {
                                                case 1:
                                                    chipslist[i].SetPosChip(111);
                                                    break;
                                                case 2:
                                                    chipslist[i].SetPosChip(112);
                                                    break;
                                                case 3:
                                                    chipslist[i].SetPosChip(113);
                                                    break;
                                                case 4:
                                                    chipslist[i].SetPosChip(114);
                                                    break;
                                            }
                                            break;
                                    }
                                }
                                    
                                
                            }
                        }
                        
                    }
                }
            }
        }


        //Method to display the chips.
        public void DisplayChips(string mode)
        {
            if (mode == "ludo")
            {
                hardware.ClearScreen();
                hardware.DrawImage(imgLudo);

                List<int> drawed = new List<int>();

                for (int i = 0; i < 16; i++)
                {
                    if (!drawed.Contains(chipslist[i].GetPosChip() - 1))
                    {
                        hardware.DrawSprite(chipslist[i].GetImg(),
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].x,
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].y, 0, 0, 25, 25);
                        drawed.Add(chipslist[i].GetPosChip() - 1);
                    }
                    else
                    {
                        hardware.DrawSprite(chipslist[i].GetImg(),
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].x2,
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].y2, 0, 0, 25, 25);

                    }

                }
            }
            else if (mode == "limitless")
            {
                hardware.ClearScreen();
                hardware.DrawImage(imgLudoLL);

                List<int> drawed = new List<int>();

                for (int i = 0; i < 16; i++)
                {
                    if (!drawed.Contains(chipslist[i].GetPosChip() - 1))
                    {
                        hardware.DrawSprite(chipslist[i].GetImg(),
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].x,
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].y, 0, 0, 25, 25);
                        drawed.Add(chipslist[i].GetPosChip() - 1);
                    }
                    else
                    {
                        hardware.DrawSprite(chipslist[i].GetImg(),
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].x2,
                            (short)arrayBox[chipslist[i].GetPosChip() - 1].y2, 0, 0, 25, 25);

                    }

                }
            }
        }

        public void MoveChip(string color, int num, int rolledValue, ref int turn)
        {
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
                            switch(rolledValue)
                            {
                                //Added a new attribute to chip, to check how many
                                //positions have advanced, because the chip wont enter
                                //his finish color boxes until it haven't advanced 64 positions
                                case 1:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 == 68) 
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 64)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 64)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                        }

                                    }

                                    break;
                                case 2:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 67 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 63)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 63)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            
                                        }

                                    }
                                    break;
                                case 3:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 66 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 62)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 62)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 4:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 65 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 61)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 61)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 5:
                                    //If the selected chip is at home and rolls 5.
                                    //The chips gets out of home and add 1 to player's number
                                    //of chips out.
                                    if (chip.GetisHome())
                                    {
                                        player[turn].SetChipsOut();
                                        chip.SetPosChip(39);
                                        chip.SetisHome(false);
                                        chip.SetAdvPos(1);

                                    }
                                    else
                                    {
                                        if (chip.GetPosChip() - 1 >= 64 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 60)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 60)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }
                                    }
                                    break;
                                case 6:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 63 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 59)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if(chip.GetAdvPos() >= 59)
                                        {
                                            chip.SetPosChip(68 + (chip.GetAdvPos() + rolledValue - 64));
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }
                                        
                                    }
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }

                            break;
                        case "blue":
                            switch (rolledValue)
                            {
                                case 1:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 == 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 64)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 64)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                        }

                                    }

                                    break;
                                case 2:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 67 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 63)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 63)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 3:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 66 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 62)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 62)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 4:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 65 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 61)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 61)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 5:
                                    //If the selected chip is at home and rolls 5.
                                    //The chips gets out of home and add 1 to player's number
                                    //of chips out.
                                    if (chip.GetisHome())
                                    {
                                        player[turn].SetChipsOut();
                                        chip.SetPosChip(22);
                                        chip.SetisHome(false);
                                        chip.SetAdvPos(1);

                                    }
                                    else
                                    {
                                        if (chip.GetPosChip() - 1 >= 64 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 60)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 60)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }
                                    }
                                    break;
                                case 6:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 63 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 59)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 59)
                                        {
                                            chip.SetPosChip(89 + (chip.GetAdvPos() + rolledValue - 64));
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                        case "green":
                            switch (rolledValue)
                            {
                                case 1:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 == 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() <= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 64)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 64)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                        }

                                    }

                                    break;
                                case 2:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 67 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 63)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 63)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 3:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 66 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 62)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 62)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 4:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 65 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 61)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 61)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 5:
                                    //If the selected chip is at home and rolls 5.
                                    //The chips gets out of home and add 1 to player's number
                                    //of chips out.
                                    if (chip.GetisHome())
                                    {
                                        player[turn].SetChipsOut();
                                        chip.SetPosChip(56);
                                        chip.SetisHome(false);
                                        chip.SetAdvPos(1);

                                    }
                                    else
                                    {
                                        if (chip.GetPosChip() - 1 >= 64 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 60)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 60)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }
                                    }
                                    break;
                                case 6:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 63 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 59)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 59)
                                        {
                                            chip.SetPosChip(82 + (chip.GetAdvPos() + rolledValue - 64));
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                        case "yellow":
                            switch (rolledValue)
                            {
                                case 1:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 == 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 64)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 64)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                        }

                                    }

                                    break;
                                case 2:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 67 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 63)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 63)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 3:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 66 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 62)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 62)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 4:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 65 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 61)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 61)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    break;
                                case 5:
                                    //If the selected chip is at home and rolls 5.
                                    //The chips gets out of home and add 1 to player's number
                                    //of chips out.
                                    if (chip.GetisHome())
                                    {
                                        player[turn].SetChipsOut();
                                        chip.SetPosChip(5);
                                        chip.SetisHome(false);
                                        chip.SetAdvPos(1);

                                    }
                                    else
                                    {
                                        if (chip.GetPosChip() - 1 >= 64 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 60)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 60)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }
                                    }
                                    break;
                                case 6:
                                    if (!chip.GetisHome())
                                    {
                                        if (chip.GetPosChip() - 1 >= 63 && chip.GetPosChip() - 1 <= 68)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue - 68);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 65 && chip.GetAdvPos() >= 71)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            if (chip.GetAdvPos() == 71)
                                            {
                                                player[turn].AddWinChip();
                                            }
                                        }
                                        else if (chip.GetAdvPos() < 59)
                                        {
                                            chip.SetPosChip((chip.GetPosChip() - 1) + rolledValue);
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                        }
                                        else if (chip.GetAdvPos() >= 59)
                                        {
                                            chip.SetPosChip(75 + (chip.GetAdvPos() + rolledValue - 64));
                                            player[turn].AddCount6Rolls();
                                            chip.SetAdvPos(rolledValue);
                                            player[turn].AddCount6Rolls();
                                        }

                                    }
                                    player[turn].SetRepeatTurn(true);
                                    break;
                            }
                            break;
                    }
                }

            }
        }

        public void PlayGame(string lang)
        {
            bool exit = false;
            string arrayData = "files/boxArrayData.txt";
            playSelect.Show(lang);

            //Define colors, roll, chips variable values;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);
            

            arrayBox = boxes.LoadData(arrayData);
            int chipToMove;
            

            //Main loop of the ludo game. It will show a menu, step by step
            //to show the player hoy to play.
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
                        "Mete roll entre 1 y 68: ", red);
                }
                else
                {
                    txtNames = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Turn:  " + player[i].GetName() + "            Color: " +
                        player[i].GetColor(), red);
                    txtChipsOut = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Chips out: " + player[i].GetChipsOut(), yellow);
                    txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "Enter the roll 1 to 68: ", red);
                }

                int rollValue = 0;
                //Draw the 16 chips in their houses.
                DisplayChips("ludo");

                hardware.WriteText(txtNames, 650, 20);
                hardware.WriteText(txtChipsOut, 650, 40);
                hardware.UpdateScreen();

                //Commented because of the devRoll.
                menu.ShowFirstStep(lang);

                do
                {
                    //Repeat until press 1
                } while (hardware.KeyPressed() != Hardware.KEY_1);

                rollValue = dice.GetRollValue();

                //Shows the image of the rollvalue.
                switch(rollValue)
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

                //Developer roll.
                /*do
                {
                    hardware.Clear("roll");
                    rollValue = dice.GetDevRoll();
                } while (rollValue < 1 || rollValue > 68);
                */
                
                do
                {
                    
                    hardware.Clear("chip");

                    //The user enters the number of chip to move
                    // and if is less than 1 and more than 4 it tells
                    // that is wrong chip number.
                    chipToMove = menu.ShowSecondStep(lang);
                    if (chipToMove < 1 || chipToMove > 4)
                    {
                        menu.GetErrorChip(lang);
                    }
                } while (chipToMove < 1 || chipToMove > 4);


                //Here will be the move.
                MoveChip(player[i].GetColor(), chipToMove, rollValue, ref i);

                CheckDeath(player[i].GetColor(), lang, i);

                //User must press escape to skip the turn
                menu.GetThirdStep(lang);


                if (player[i].GetWin())
                {
                    menu.ShowWinner(player[i].GetName(), lang);
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
                

                /*boxes.SaveData(arrayBox);*/

                do
                {
                    if (hardware.KeyPressed() == Hardware.KEY_ESC)
                    {
                        exit = true;
                    }
                } while (!exit);
            }
            
        }

        public void PlayLimitless(string lang)
        {
            short yInitchip;
            bool exit = false;
            string arrayData = "files/boxArrayDataLimitless.txt";
            int turnLimit = 0;


            playSelect.ReadLimit(lang);

            playSelect.Show(lang);
            //Define colors, roll, chips variable values;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);
            txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter the roll 1 to 68: ", red);

            txtLimit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Limit of kills: "+ playSelect.GetNumLimit(), red);

            int chipToMove;
            arrayBox = boxes.LoadData(arrayData);

            
            //Main loop of the ludo game. It will show a menu, step by step
            //to show the player hoy to play.
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
                        "Mete roll entre 1 y 68: ", red);
                }
                else
                {
                    txtNames = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Turn:  " + player[i].GetName() + "            Color: " +
                        player[i].GetColor(), red);
                    txtChipsOut = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Chips out: " + player[i].GetChipsOut(), yellow);
                    txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                        "Enter the roll 1 to 68: ", red);
                }

                int rollValue = 0;
                //Draw the 16 chips in their houses.
                DisplayChips("limitless");

                hardware.WriteText(txtNames, 650, 20);
                hardware.WriteText(txtLimit, 650, 60);
                hardware.WriteText(txtChipsOut, 650, 40);

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
                }*/

                hardware.WriteText(txtDev, 640, 330);
                hardware.UpdateScreen();

                //Developer roll.
                do
                {
                    hardware.Clear("roll");
                    rollValue = dice.GetDevRoll();
                } while (rollValue < 1 || rollValue > 68);

                do
                {

                    hardware.Clear("chip");

                    //The user enters the number of chip to move
                    // and if is less than 1 and more than 4 it tells
                    // that is wrong chip number.
                    chipToMove = menu.ShowSecondStep(lang);
                    if (chipToMove < 1 || chipToMove > 4)
                    {
                        menu.GetErrorChip(lang);
                    }
                } while (chipToMove < 1 || chipToMove > 4);


                //Here will be the move.
                MoveChip(player[i].GetColor(), chipToMove, rollValue, ref i);

                CheckDeath(player[i].GetColor(), lang, i);

                //User must press escape to skip the turn
                menu.GetThirdStep(lang);



                if (player[i].GetKills() == playSelect.GetNumLimit())
                {
                    menu.ShowWinner(player[i].GetName(), lang);
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

                do
                {
                    if (hardware.KeyPressed() == Hardware.KEY_ESC)
                    {
                        exit = true;
                    }
                } while (!exit);
            }
        }

        public void PlayOnline(string lang)
        {
            bool exit = false;
            short yInitchip;
            string arrayData = "files/boxArrayDataLimitless.txt";
            IntPtr txtExit;

            playSelect.Show(lang);

            //Define colors, roll, chips variable values;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);

            if(lang == "spanish")
            {
                txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "En construccion!", red);
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Pulsa escape para volver al menu!", red);

            }
            else
            {
                txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Coming soon!", red);
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press escape to go back to menu!", yellow);

            }
            

            int chipToMove;

            hardware.ClearScreen();
            hardware.DrawImage(imgLudo);

            hardware.UpdateScreen();

            do
            {

                hardware.WriteText(txtDev, 700, 300);
                hardware.WriteText(txtExit, 650, 500);
                hardware.UpdateScreen();
                if (hardware.KeyPressed() == Hardware.KEY_ESC)
                {
                    exit = true;
                }
            } while (!exit);
        }


        public void PlayVsIA(string lang)
        {
            bool exit = false;
            short yInitchip;
            string arrayData = "files/boxArrayDataLimitless.txt";
            IntPtr txtExit;

            playSelect.Show(lang);

            //Define colors, roll, chips variable values;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);
            font = new Font("font/fuenteproy.ttf", 12);

            if (lang == "spanish")
            {
                txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "En construccion!", red);
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Pulsa escape para volver al menu!", red);

            }
            else
            {
                txtDev = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Coming soon!", red);
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press escape to go back to menu!", yellow);

            }


            int chipToMove;

            hardware.ClearScreen();
            hardware.DrawImage(imgLudo);

            hardware.UpdateScreen();

            do
            {

                hardware.WriteText(txtDev, 700, 300);
                hardware.WriteText(txtExit, 650, 500);
                hardware.UpdateScreen();
                if (hardware.KeyPressed() == Hardware.KEY_ESC)
                {
                    exit = true;
                }
            } while (!exit);
        }
    }
}
