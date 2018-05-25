//Luis Sellés Blanes
//V0.02 - Creating main menu of the game
//V0.06 - Modified menuScreen and added RulesScreen

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class MenuScreen
    {
        protected Image imgBack, imgArrow;
        protected int chosenGame = 1;
        protected Hardware hardware;
        protected IntPtr txtSpace;
        protected Font font;

        public MenuScreen(Hardware hardware)
        {
            imgBack = new Image("img/menuscreen.jpg", 1152, 648);
            imgBack.MoveTo(0, 0);
            imgArrow = new Image("img/arrowcool.jpg", 40, 40);
            imgArrow.MoveTo(250, 180);
            font = new Font("font/fuenteproy.ttf", 20);
            this.hardware = hardware;
        }

        //Show the multiple options of the menu.
        public void Show()
        {
            bool isSpacePressed = false;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            txtSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press 'SPACE' to continue", red);

            do
            {

                hardware.ClearScreen();
                hardware.DrawImage(imgBack);
                hardware.WriteText(txtSpace, 200, 150);
                hardware.DrawImage(imgArrow);
                hardware.UpdateScreen();


                //Moves the arrow throught the options of the menu
                int keyPress = hardware.KeyPressed();
                if (keyPress == Hardware.KEY_UP && chosenGame > 1)
                {
                    chosenGame--;
                    imgArrow.MoveTo(250, (short)(imgArrow.Y - 52));
                }
                else if (keyPress == Hardware.KEY_DOWN && chosenGame < 7)
                {
                    chosenGame++;
                    imgArrow.MoveTo(250, (short)(imgArrow.Y + 52));
                }
                else if (keyPress == Hardware.KEY_SPACE)
                {
                    isSpacePressed = true;
                }

            } while (!isSpacePressed);
        }
        
        //Gets the chosen option of the menu. It will be to know which
        //option of the menu i choose.
        public int GetChosenGame()
        {
            return chosenGame;
        }
    }
}
