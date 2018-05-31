//Luis Sellés Blanes
//V0.02 - Creating main menu of the game
//V0.06 - Modified menuScreen and added RulesScreen
//V0.12 - Added heritage
using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class MenuScreen : Screen
    {
        protected Image imgBack, imgArrow, imgLang;
        protected int chosenGame = 1;
        protected IntPtr txtSpace;
        protected Font font;
        protected string lang;

        public MenuScreen(Hardware hardware) : base(hardware)
        {
            imgBack = new Image("img/menuscreen.jpg", 1152, 648);
            imgBack.MoveTo(0, 0);
            imgArrow = new Image("img/arrowcool.jpg", 40, 40);
            imgArrow.MoveTo(400, 270);
            font = new Font("font/fuenteproy.ttf", 20);
            this.hardware = hardware;
        }

        public void SelectLang()
        {
            bool isSpacePressed = false;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            txtSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press 'SPACE' to continue", red);

            imgArrow.MoveTo(400, 270);
            imgLang = new Image("img/SelectLang.jpg", 1152, 648);
            do
            {

                hardware.ClearScreen();
                hardware.DrawImage(imgLang);
                hardware.WriteText(txtSpace, 200, 500);
                hardware.DrawImage(imgArrow);
                hardware.UpdateScreen();


                //Moves the arrow throught the options of the menu
                int keyPress = hardware.KeyPressed();
                if (keyPress == Hardware.KEY_UP && chosenGame > 1)
                {
                    chosenGame--;
                    imgArrow.MoveTo(400, (short)(imgArrow.Y - 115));
                }
                else if (keyPress == Hardware.KEY_DOWN && chosenGame < 2)
                {
                    chosenGame++;
                    imgArrow.MoveTo(400, (short)(imgArrow.Y + 115));
                }
                else if (keyPress == Hardware.KEY_SPACE)
                {
                    isSpacePressed = true;
                }

            } while (!isSpacePressed);

            if (chosenGame == 1)
                lang = "english";
            else
                lang = "spanish";
        }

        public string GetLang()
        {
            return this.lang;
        }


        //Show the multiple options of the menu.
        public void Show()
        {
            bool isSpacePressed = false;
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);

            txtSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press 'SPACE' to continue", red);


            SelectLang();

            imgArrow.MoveTo(270, 180);

            if(GetLang() == "spanish")
            {
                imgBack = new Image("img/menuscreenSpanish.jpg", 1152, 648);
                txtSpace = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Pulsa espacio para continuar", red);
                chosenGame = 1;
            }

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
