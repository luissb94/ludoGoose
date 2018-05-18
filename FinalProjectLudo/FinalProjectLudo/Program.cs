//Luis Selles Blanes
//V0.01 - Creating main to test functionallity.
//V0.03 - Adding the methods to show the different background
//          of the different modes.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLudo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program game = new Program();
            
            Hardware hardware = new Hardware(1152, 652, 24, false);
            WelcomeScreen welcome = new WelcomeScreen(hardware);
            MenuScreen menu = new MenuScreen(hardware);
            CreditsScreen credits = new CreditsScreen(hardware);
            LudoGame ludo = new LudoGame(hardware);
            PlayerSelect playerSelect = new PlayerSelect(hardware);
            RulesScreen rules = new RulesScreen(hardware);

            do
            {
                hardware.ClearScreen();
                welcome.ShowWelcomeScreen();
                if(!welcome.Exit())
                {
                    menu.Show();
                    switch(menu.GetChosenGame())
                    {
                        case 1:
                            playerSelect.ShowPlayerSelect();
                            ludo.LudoPlayGame();
                            break;
                        case 2:
                            playerSelect.ShowPlayerSelect();
                            break;
                        case 3:
                            playerSelect.ShowPlayerSelectAgainstIA();
                            break;
                        case 4:
                            break;
                        case 5:
                            credits.ShowCredits();
                            break;
                        case 6:
                            rules.ShowRules();
                            break;

                        default:
                            //Never will get here because
                            //Player cant choose any other option
                            //Than menu, for now.
                            break;
                    }
                }
                
            } while (!welcome.Exit());
        }
    }
}
