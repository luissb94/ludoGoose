//Luis Selles Blanes
//V0.01 - Creating Hardware class
//V0.02 - Adding methods to the hardware class: 
//            Clear screen, writeText and drawLine
//            also adding new KEYS UP and DOWN
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
    }
}
