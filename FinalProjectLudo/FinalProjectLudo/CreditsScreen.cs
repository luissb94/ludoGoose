//Luis Selles
//V0.02 - Creating credits Screen to read credits from file.
//          Reading the credits from a file and showing it in the credits.
//V0.12 - Added heritage

using System;
using Tao.Sdl;
using System.IO;


namespace FinalProjectLudo
{
    class CreditsScreen : Screen
    {
        protected IntPtr textCredits;
        protected Font font;
        protected Image imgCred;

        public CreditsScreen(Hardware hardware) : base(hardware)
        {
            imgCred = new Image("img/credits.jpg", 1152, 648);
            imgCred.MoveTo(0, 0);

            this.hardware = hardware;
        }

        //Creating Show method, it will show the credits one line by one.
        //If you click ESCAPE after all the credits are shown it will exit from the screen.
        public void Show(string lang)
        {
            IntPtr txtExit;
            short yInit = 200;
            bool finish = false;
            font = new Font("font/fuenteproy.ttf", 20);
            hardware.ClearScreen();
            hardware.DrawImage(imgCred);
            string fileName;
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            if (lang == "spanish")
            {
                fileName = "files/credits.txt";
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Pulsa escape para salir", black);
            }
            else
            {
                fileName = "files/creditsEnglish.txt";
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press escape to exit", black);
            }

            try
            {
                hardware.WriteText(txtExit, 300, 600);
                hardware.UpdateScreen();
                while (!finish)
                {
                    yInit = 200;

                    font = new Font("font/fuenteproy.ttf", 20);
                    Sdl.SDL_Color blue = new Sdl.SDL_Color(0, 0, 255);

                    string[] lines = File.ReadAllLines(fileName);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        textCredits = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                            lines[i], blue);
                        hardware.WriteText(textCredits, 300, yInit);
                        hardware.UpdateScreen();
                        yInit += 100;

                    }

                    do
                    {
                        if (hardware.KeyPressed() == Hardware.KEY_ESC)
                        {
                            finish = true;
                        }
                    } while (!finish);

                }
            }
            catch (PathTooLongException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");

                if(lang == "spanish")
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - La ruta es muy larga");
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - The path is too long");
                }
                

                fileErrorLog.Close();
            }
            catch (FileNotFoundException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                if (lang == "spanish")
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - No se encuentra el fichero");
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - The file is not found");
                }
                
                fileErrorLog.Close();
            }
            catch (IOException e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                if (lang == "spanish")
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - " + e.Message);
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - " + e.Message);
                }
                fileErrorLog.Close();
            }
            catch (Exception e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                if (lang == "spanish")
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - " + e.Message);
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: CreditsScreen - " + e.Message);
                }
                
                fileErrorLog.Close();
            }



        }
    }
}