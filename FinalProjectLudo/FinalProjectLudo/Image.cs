//Luis Selles Blanes
//V0.01 - Creating Image class to load images.
using System;
using Tao.Sdl;


namespace FinalProjectLudo
{
    class Image
    {
        public short X { get; set; }
        public short Y { get; set; }
        public short ImageWidth { get; set; }
        public short ImageHeight { get; set; }
        public IntPtr ImagePtr { get; set; }

        public Image(string fileName, short width, short height)
        {
            ImagePtr = SdlImage.IMG_Load(fileName);
            if (ImagePtr == IntPtr.Zero)
            {
                Console.WriteLine("Image not found");
                Environment.Exit(1);
            }

            ImageWidth = width;
            ImageHeight = height;
        }

        public void MoveTo(short x, short y)
        {
            X = x;
            Y = y;
        }
    }
}
