// Luis Selles Blanes
// V0.02 - Creating font class to load fonts

using System;
using Tao.Sdl;

namespace FinalProjectLudo
{
    class Font
    {
        IntPtr fontType;

        public Font(string fileName, int fontSize)
        {
            fontType = SdlTtf.TTF_OpenFont(fileName, fontSize);
            if (fontType == IntPtr.Zero)
            {
                Console.WriteLine("Font type not found");
                Environment.Exit(2);
            }
        }

        public IntPtr GetFontType()
        {
            return fontType;
        }
    }
}
