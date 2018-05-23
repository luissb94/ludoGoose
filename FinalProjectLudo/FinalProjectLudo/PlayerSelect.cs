//Luis Selles
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
        protected IntPtr textPlayer1, textPlayer2, textPlayer3, textPlayer4,choosePlayer, txtName;
        protected Font font;
        protected Hardware hardware;
        protected Image imgPlayerSelect;
        protected List<Player> players = new List<Player>();

        public PlayerSelect(Hardware hardware)
        {
            bool exitPlayerSelect = false;
            imgPlayerSelect = new Image("img/playerSelect.jpg", 1152, 652);
            imgPlayerSelect.MoveTo(0, 0);
            this.hardware = hardware;
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
            hardware.WriteText(textPlayer1, 200, 200);
            hardware.WriteText(textPlayer2, 200, 300);
            hardware.WriteText(textPlayer3, 200, 400);
            hardware.WriteText(textPlayer4, 200, 500);
            hardware.WriteText(choosePlayer, 370, 50);

            hardware.UpdateScreen(); 

            //This for will let the users enter his name and will show it 
            //letter by letter
            for(int i = 0; i < 4; i++)
            {
                exit = false;
                name = "";
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
                        players.Add( new Player(name, "red"));
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
        
        public List<Player> GetPlayerList()
        {
            return this.players;
        }
    }
}
