﻿//Luis Selles
//V0.03 - Class to make the players enter their name so it can be shown
//          on the next image of the game.
//V0.05 - Made a for to let the users enters his name
//V0.08 - Added the switch to get the names of the 4 players.
//          and it's methods to get the data.

using System;
using Tao.Sdl;
using System.Collections.Generic;


namespace FinalProjectLudo
{
    class PlayerSelect
    {
        protected IntPtr textPlayer1, textPlayer2, textPlayer3, textPlayer4,choosePlayer, 
            txtName, txtExit;
        protected Font font;
        protected Hardware hardware;
        protected Image imgPlayerSelect;
        protected List<Player> players = new List<Player>();
        protected int num_players;
        protected MenuScreen menu;
        public PlayerSelect(Hardware hardware)
        {
            bool exitPlayerSelect = false;
            imgPlayerSelect = new Image("img/playerSelect.jpg", 1152, 652);
            imgPlayerSelect.MoveTo(0, 0);
            this.hardware = hardware;
            menu = new MenuScreen(hardware);
        }

        //Method to get the number of players that are going to play.
        public void ShownNumPlayerSelect()
        {
            char n;
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);
            IntPtr txtNumPlayers, txtNum;
            txtNumPlayers = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Enter number of players between 2 and 4:  ", black);

            hardware.WriteText(txtNumPlayers, 150, 200);
            hardware.UpdateScreen();
            do
            {
                n = hardware.ReadNumber();

                if (n != '!' && n != '?')
                {
                    if(n >= '2' && n <= '4')
                    {
                        num_players = Convert.ToInt32(Convert.ToString(n));

                        txtNum = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                            Convert.ToString(num_players), black);
                        hardware.WriteText(txtNum, 770, 200);

                        txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                            "Press enter to skip", black);
                        hardware.WriteText(txtExit, 640, 430);

                        hardware.UpdateScreen();

                        n = '!';
                    }
                }

               
            } while (n != '!');

            do
            {

            } while (hardware.KeyPressed() != Hardware.KEY_ENTER);
        }

        public int GetNumPlayers()
        {
            return num_players;
        }

        //This method will show 4 "insert player name" and, coming soon, it will let
        //the users enter their name.
        public void Show()
        {
            bool exit = false;
            string name = "";
            short yNames = 200;
            char addLetter;

            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);
            Sdl.SDL_Color green = new Sdl.SDL_Color(0, 255, 0);
            Sdl.SDL_Color yellow = new Sdl.SDL_Color(255, 255, 0);

            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textPlayer1 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player one: ", red);

            textPlayer2 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player two:", blue);

            textPlayer3 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player three:", green);

            textPlayer4 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player four:", yellow);

            choosePlayer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "ENTER YOUR NAMES:", black);

            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            ShownNumPlayerSelect();
            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            /*hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(textPlayer2, 200, 300);
            hardware.WriteText(textPlayer3, 200, 400);
            hardware.WriteText(textPlayer4, 200, 500);*/
            hardware.WriteText(choosePlayer, 370, 50);
            
            //This for will let the users enter his name and will show it 
            //letter by letter
            for(int i = 0; i < GetNumPlayers(); i++)
            {
                exit = false;
                name = "";
                switch(i)
                {
                    case 0:
                        hardware.WriteText(textPlayer1, 200, 200);
                        hardware.UpdateScreen();
                        break;
                    case 1:
                        hardware.WriteText(textPlayer2, 200, 300);
                        hardware.UpdateScreen();
                        break;
                    case 2:
                        hardware.WriteText(textPlayer3, 200, 400);
                        hardware.UpdateScreen();
                        break;
                    case 3:
                        hardware.WriteText(textPlayer4, 200, 500);
                        hardware.UpdateScreen();
                        break;
                }

                do
                {
                    addLetter = hardware.ReadLetter();
                    
                    if (addLetter != '!')
                        name += addLetter;

                    txtName = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    name, black);
                    hardware.WriteText(txtName, 700, yNames);
                    hardware.UpdateScreen();
                    

                } while (addLetter != '!');
                
                //Added switch to get the names of the 4 players.
                switch(i)
                {
                    case 0:
                        players.Add(new Player(name, "red"));
                        break;
                    case 1:
                        players.Add(new Player(name, "blue"));
                        break;
                    case 2:
                        players.Add(new Player(name, "green"));
                        break;
                    case 3:
                        players.Add(new Player(name, "yellow"));
                        break;
                }

                yNames += 100;
            }

            exit = false;

            txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press Enter to play!", black);

            hardware.WriteText(txtExit, 350, 600);
            hardware.UpdateScreen();

            do
            {
                if (hardware.KeyPressed() == Hardware.KEY_ENTER)
                {
                    exit = true;
                }
            } while (!exit);
        }

        //This method is only to set player name against IA.
        public void ShowPSAgainstIA()
        {
            bool exit = false;
            string name = "";
            char addLetter = ' ';
            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textPlayer1 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player one: ", red);

            choosePlayer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "ENTER YOUR NAME:", black);

            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(choosePlayer, 370, 50);

            hardware.UpdateScreen();

            
            name = "";
            do
            {
                addLetter = hardware.ReadLetter();

                if (addLetter != '!')
                    name += addLetter;

                txtName = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                name, black);
                hardware.WriteText(txtName, 700, 200);
                hardware.UpdateScreen();


            } while (addLetter != '!');
            
            

            txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press Enter to play!", black);

            hardware.WriteText(txtExit, 350, 600);
            hardware.UpdateScreen();

            do
            {
                if (hardware.KeyPressed() == Hardware.KEY_ENTER)
                {
                    exit = true;
                }
            } while (!exit);
        }
        
        public List<Player> GetPlayerList()
        {
            return this.players;
        }

        public void ShowPSOnline()
        {
            bool exit = false;

            font = new Font("font/fuenteproy.ttf", 20);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textPlayer1 = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Name player one: ", red);

            choosePlayer = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "ENTER YOUR NAMES:", black);

            hardware.ClearScreen();
            hardware.DrawImage(imgPlayerSelect);
            hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(choosePlayer, 370, 50);

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
