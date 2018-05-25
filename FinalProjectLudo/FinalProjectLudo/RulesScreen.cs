//Luis Selles Blanes
//V0.03 - Making the rules of the Ludo and Goose
//      - They will be readed from a file.

using System;
using Tao.Sdl;
using System.IO;
using System.Collections.Generic;

namespace FinalProjectLudo
{
    class RulesScreen
    {
        protected IntPtr textRules, textTitle;
        protected Font font;
        protected Hardware hardware;
        protected Image imgRules;

        public RulesScreen(Hardware hardware)
        {
            imgRules = new Image("img/playerSelect.jpg", 1152, 648);
            imgRules.MoveTo(0, 0);
            this.hardware = hardware;
        }
        
        //This method will find the rules.txt, if not found it will display an image of 
        //404 file not found, else it will display the rules.
        public void Show()
        {
            
            bool exitRules = false;
            short yInit = 100;
            font = new Font("font/fuenteproy.ttf", 12);
            Sdl.SDL_Color red = new Sdl.SDL_Color(255, 0, 0);
            Sdl.SDL_Color black = new Sdl.SDL_Color(0, 0, 0);

            textTitle = SdlTtf.TTF_RenderText_Solid(font.GetFontType(),
                    "RULES", black);
            
            try
            {
                if(!File.Exists("files/rules.txt"))
                {
                    imgRules = new Image("img/404.jpg", 1152, 652);
                    imgRules.MoveTo(0, 0);
                    hardware.ClearScreen();
                    hardware.DrawImage(imgRules);
                    hardware.UpdateScreen();
                }
                else
                {
                    int countRulesMin = 0, countRulesMax = countRulesMin + 10 ;
                    hardware.ClearScreen();
                    hardware.DrawImage(imgRules);
                    hardware.UpdateScreen();
                    List<string> lines = new List<string>();

                    StreamReader rulesFile = File.OpenText("files/rules.txt");
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
                        for (int i  = countRulesMin; i < countRulesMax; i++)
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
            catch(PathTooLongException)
            {
                Console.WriteLine("Path is too long.");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File was not Found");
            }
            catch(IOException e)
            {
                Console.WriteLine("I/O error .. " + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error ..." + e.Message);
            }
        }
    }
}
