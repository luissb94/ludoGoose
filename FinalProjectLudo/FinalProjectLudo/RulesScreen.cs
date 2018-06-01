//Luis Selles Blanes
//V0.03 - Making the rules of the Ludo and Goose
//      - They will be readed from a file.
//V0.11 - Added try/catch to file access methods
//V0.12 - Added heritage

using System;
using Tao.Sdl;
using System.IO;
using System.Collections.Generic;

namespace FinalProjectLudo
{
    class RulesScreen : Screen
    {
        protected IntPtr textRules, textTitle;
        protected Font font;
        protected Image imgRules;

        public RulesScreen(Hardware hardware) : base(hardware)
        {
            imgRules = new Image("img/playerSelect.jpg", 1152, 648);
            imgRules.MoveTo(0, 0);
            this.hardware = hardware;
        }

        //This method will find the rules.txt, if not found it will display an image of 
        //404 file not found, else it will display the rules.
        public void Show(string lang)
        {
            IntPtr txtExit;

            bool exitRules = false;
            short yInit = 100;
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);
            string fileName;

            if(lang == "spanish")
            {
                textTitle = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "REGLAS DEL PARCHIS", black);
                fileName = "files/rules.txt";
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Pulsa escape para salir", black);
            }
            else
            {
                textTitle = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "LUDO RULES", black);
                txtExit = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "Press Escape to exit", black);

                fileName = "files/rulesEnglish.txt";
            }
            

            try
            {
                if (!File.Exists(fileName))
                {
                    imgRules = new Image("img/404.jpg", 1152, 652);
                    imgRules.MoveTo(0, 0);
                    hardware.ClearScreen();
                    hardware.DrawImage(imgRules);
                    hardware.UpdateScreen();
                }
                else
                {
                    int countRulesMin = 0, countRulesMax = countRulesMin + 10;
                    hardware.ClearScreen();
                    hardware.DrawImage(imgRules);
                    hardware.UpdateScreen();
                    List<string> lines = new List<string>();

                    StreamReader rulesFile = File.OpenText(fileName);
                    string line = rulesFile.ReadLine();
                    while (line != null)
                    {
                        lines.Add(line);
                        line = rulesFile.ReadLine();
                    }

                    rulesFile.Close();


                    //Reading rules from a file and trying to get down or up using the KEYS.UP and DOWN
                    do
                    {
                        hardware.ClearScreen();
                        hardware.DrawImage(imgRules);
                        hardware.WriteText(textTitle, 425, 50);
                        hardware.WriteText(txtExit, 400, 600);
                        for (int i = countRulesMin; i < countRulesMax; i++)
                        {
                            textRules = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                                        lines[i], red);

                            hardware.WriteText(textRules, 50, yInit);
                            yInit += 50;
                        }

                        hardware.UpdateScreen();

                        do
                        {
                            if (hardware.KeyPressed() == Hardware.KEY_ESC)
                            {
                                exitRules = true;
                            }
                            /*
                            if (hardware.KeyPressed() == Hardware.KEY_UP && countRulesMin > 0)
                            {
                                countRulesMin--;
                                yInit = 200;
                            }
                            if (hardware.KeyPressed() == Hardware.KEY_DOWN 
                                && countRulesMax < (lines.Count - 1))
                            {
                                countRulesMin++;
                                yInit = 200;
                            }*/
                        } while (!exitRules || hardware.KeyPressed() ==
                            Hardware.KEY_DOWN || hardware.KeyPressed() == Hardware.KEY_UP);

                    } while (!exitRules);
                }

            }
            catch (PathTooLongException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");

                if (lang == "spanish")
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: RulesScreen - La ruta es muy larga");
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: RulesScreen - The path is too long");
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
                    " - Error: RulesScreen - No se encuentra el fichero");
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: RulesScreen - The file is not found");
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
                    " - Error: RulesScreen - " + e.Message);
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: RulesScreen - " + e.Message);
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
                    " - Error: RulesScreen - " + e.Message);
                }
                else
                {
                    fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: RulesScreen - " + e.Message);
                }

                fileErrorLog.Close();
            }
        }
    }
}
