//Luis Selles Blanes
//V0.01 - Creating Hardware class
//V0.02 - Adding methods to the hardware class: 
//            Clear screen, writeText and drawLine
//            also adding new KEYS UP and DOWN
//V0.05 - Made a method to return the key pressed by
//            the user, but will return a char.
using System;
using Tao.Sdl;
using System.Threading;


namespace FinalProjectLudo
{
    class Hardware
    {
        public const int KEY_ESC = Sdl.SDLK_ESCAPE;
        public const int KEY_SPACE = Sdl.SDLK_SPACE;
        public const int KEY_UP = Sdl.SDLK_UP;
        public const int KEY_DOWN = Sdl.SDLK_DOWN;
        public const int KEY_ENTER = Sdl.SDLK_RETURN;
        public const int KEY_A = Sdl.SDLK_a;
        public const int KEY_B = Sdl.SDLK_b;
        public const int KEY_C = Sdl.SDLK_c;
        public const int KEY_D = Sdl.SDLK_d;
        public const int KEY_E = Sdl.SDLK_e;
        public const int KEY_F = Sdl.SDLK_f;
        public const int KEY_G = Sdl.SDLK_g;
        public const int KEY_H = Sdl.SDLK_h;
        public const int KEY_I = Sdl.SDLK_i;
        public const int KEY_J = Sdl.SDLK_j;
        public const int KEY_K = Sdl.SDLK_k;
        public const int KEY_L = Sdl.SDLK_l;
        public const int KEY_M = Sdl.SDLK_m;
        public const int KEY_N = Sdl.SDLK_n;
        public const int KEY_O = Sdl.SDLK_o;
        public const int KEY_P = Sdl.SDLK_p;
        public const int KEY_Q = Sdl.SDLK_q;
        public const int KEY_R = Sdl.SDLK_r;
        public const int KEY_S = Sdl.SDLK_s;
        public const int KEY_T = Sdl.SDLK_t;
        public const int KEY_U = Sdl.SDLK_u;
        public const int KEY_V = Sdl.SDLK_v;
        public const int KEY_W = Sdl.SDLK_w;
        public const int KEY_X = Sdl.SDLK_x;
        public const int KEY_Y = Sdl.SDLK_y;
        public const int KEY_Z = Sdl.SDLK_z;
        public const int KEY_DELETE = Sdl.SDLK_DELETE;

        short screenWidth;
        short screenHeight;
        short colorDepth;

        IntPtr screen;


        public Hardware(short width, short height, short depth, bool fullScreen)
        {
            screenWidth = width;
            screenHeight = height;
            colorDepth = depth;

            int flags = Sdl.SDL_HWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT;
            if (fullScreen)
                flags = flags | Sdl.SDL_FULLSCREEN;

            Sdl.SDL_Init(Sdl.SDL_INIT_EVERYTHING);
            screen = Sdl.SDL_SetVideoMode(screenWidth, screenHeight, colorDepth, flags);
            Sdl.SDL_Rect rect = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_SetClipRect(screen, ref rect);

            SdlTtf.TTF_Init();
        }

        ~Hardware()
        {
            Sdl.SDL_Quit();
        }

        //Method to draw image in the current coordinates.
        public void DrawImage(Image img)
        {
            Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, img.ImageWidth,
                img.ImageHeight);
            Sdl.SDL_Rect target = new Sdl.SDL_Rect(img.X, img.Y,
                img.ImageWidth, img.ImageHeight);
            Sdl.SDL_BlitSurface(img.ImagePtr, ref source, screen, ref target);
        }

        public void DrawSprite(Image image, short xScreen, short yScreen, short x, short y, short width, short height)
        {
            Sdl.SDL_Rect src = new Sdl.SDL_Rect(x, y, width, height);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect(xScreen, yScreen, width, height);
            Sdl.SDL_BlitSurface(image.ImagePtr, ref src, screen, ref dest);
        }

        public void UpdateScreen()
        {
            Sdl.SDL_Flip(screen);
        }

        //Method the value of the key pressed
        public int KeyPressed()
        {
            int pressed = -1;

            Sdl.SDL_PumpEvents();
            Sdl.SDL_Event keyEvent;
            if (Sdl.SDL_PollEvent(out keyEvent) == 1)
            {
                if (keyEvent.type == Sdl.SDL_KEYDOWN)
                {
                    pressed = keyEvent.key.keysym.sym;
                }
            }

            return pressed;
        }


        //Method to clear the screen
        public void ClearScreen()
        {
            Sdl.SDL_Rect source = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_FillRect(screen, ref source, 0);
        }


        // Writes a text in the specified coordinates
        public void WriteText(IntPtr textAsImage, short x, short y)
        {
            Sdl.SDL_Rect src = new Sdl.SDL_Rect(0, 0, screenWidth, screenHeight);
            Sdl.SDL_Rect dest = new Sdl.SDL_Rect(x, y, screenWidth, screenHeight);
            Sdl.SDL_BlitSurface(textAsImage, ref src, screen, ref dest);
        }

        // Writes a line in the specified coordinates, with the specified color and alpha
        public void DrawLine(short x, short y, short x2, short y2, byte r, byte g, byte b, byte alpha)
        {
            SdlGfx.lineRGBA(screen, x, y, x2, y2, r, g, b, alpha);
        }

        public void Pause(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }

        //This method will return any letter of the alphabet
        public char ReadLetter()
        {
            char let = ' ';
            bool exit = false;
            int key_int;
            do
            {
                key_int = KeyPressed();
                if (key_int != -1)
                    exit = true;

            } while (!exit);

            switch (key_int)
            {
                case KEY_A:
                    let = 'a';
                    break;
                case KEY_B:
                    let = 'b';
                    break;
                case KEY_C:
                    let = 'c';
                    break;
                case KEY_D:
                    let = 'd';
                    break;
                case KEY_E:
                    let = 'e';
                    break;
                case KEY_F:
                    let = 'f';
                    break;
                case KEY_G:
                    let = 'g';
                    break;
                case KEY_H:
                    let = 'h';
                    break;
                case KEY_I:
                    let = 'i';
                    break;
                case KEY_J:
                    let = 'j';
                    break;
                case KEY_K:
                    let = 'k';
                    break;
                case KEY_L:
                    let = 'l';
                    break;
                case KEY_M:
                    let = 'm';
                    break;
                case KEY_N:
                    let = 'n';
                    break;
                case KEY_O:
                    let = 'o';
                    break;
                case KEY_P:
                    let = 'p';
                    break;
                case KEY_Q:
                    let = 'q';
                    break;
                case KEY_R:
                    let = 'r';
                    break;
                case KEY_S:
                    let = 's';
                    break;
                case KEY_T:
                    let = 't';
                    break;
                case KEY_U:
                    let = 'u';
                    break;
                case KEY_V:
                    let = 'v';
                    break;
                case KEY_W:
                    let = 'w';
                    break;
                case KEY_X:
                    let = 'x';
                    break;
                case KEY_Y:
                    let = 'y';
                    break;
                case KEY_Z:
                    let = 'z';
                    break;
                case KEY_ENTER:
                    let = '!';
                    break;
                case KEY_DELETE:
                    let = ' ';
                    break;
                default:
                    //NOTHING TO DO
                    break;
            }

            return let;
        }
    }
}
