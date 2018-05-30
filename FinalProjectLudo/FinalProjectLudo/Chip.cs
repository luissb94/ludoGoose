//Luis Selles Blanes
//V0.01 - Creating Chip class
//V0.08 - Added method to load the chips data from file

using System;
using System.Collections.Generic;
using System.IO;

namespace FinalProjectLudo
{
    class Chip
    {
        protected string color;
        protected int num_piece;
        protected bool isAtHome;
        protected bool isAtFinish;
        protected int posChip;
        protected string boxPos;
        protected int advancedPos = 0;
        protected Box box;
        protected Image imgChip;
        protected List<Chip> chipList = new List<Chip>();

        public Chip() { }

        public Chip(string color, int num_piece,bool isAtHome, 
            bool isAtFinish, int poschip, Image imgChip, string boxPosition,
            int adv)
        {
            this.color = color;
            this.num_piece = num_piece;
            this.posChip = poschip;
            this.isAtFinish = isAtFinish;
            this.isAtHome = isAtHome;
            this.imgChip = imgChip;
            this.boxPos = boxPosition;
            this.advancedPos = adv;
        }

        //Gets the position of the chip
        public int GetPosChip()
        {
            return posChip;
        }
        

        //Sets the position of the chip
        public void SetPosChip(int i)
        {
            posChip = i + 1;
        }
        
        public string GetColor()
        {
            return this.color;
        }

        public int GetNum()
        {
            return this.num_piece;
        }

        public void SetisHome(bool status)
        {
            this.isAtHome = status;
        }

        public bool GetisHome()
        {
            return isAtHome;
        }

        public int GetAdvPos()
        {
            return this.advancedPos;
        }
        
        public void SetAdvPos(int roll)
        {
            advancedPos += roll;
        }
        //Method to get the pos of the chip at the box
        //left or right.
        public string GetBoxPos()
        {
            return boxPos;
        }

        public void SetBoxPos(string status)
        {
            this.boxPos = status;
        }


        //Loads the data of the chips from a file
        public List<Chip> Load(string mode)
        {
            try
            {
                if( mode == "ludo")
                {
                    string fileChipData = "files/chipdata.txt";
                    StreamReader file = File.OpenText(fileChipData);
                    string line;
                    string[] lines;
                    int count = 0;

                    do
                    {
                        line = file.ReadLine();
                        if (line != null)
                        {
                            lines = line.Split(',');

                            chipList.Add(new Chip(lines[0], Convert.ToInt32(lines[1]),
                                Convert.ToBoolean(lines[2]), Convert.ToBoolean(lines[3]),
                                Convert.ToInt32(lines[4]), new Image(lines[5], 35, 35),
                                lines[6], Convert.ToInt32(lines[7])));
                            count++;
                        }
                    } while (line != null);
                    file.Close();
                }
                else if(mode == "goose")
                {
                    string fileChipData = "files/chipdataGoose.txt";
                    StreamReader file = File.OpenText(fileChipData);
                    string line;
                    string[] lines;
                    int count = 0;

                    do
                    {
                        line = file.ReadLine();
                        if (line != null)
                        {
                            lines = line.Split(',');

                            chipList.Add(new Chip(lines[0], Convert.ToInt32(lines[1]),
                                Convert.ToBoolean(lines[2]), Convert.ToBoolean(lines[3]),
                                Convert.ToInt32(lines[4]), new Image(lines[5], 35, 35),
                                lines[6], Convert.ToInt32(lines[7])));
                            count++;
                        }
                    } while (line != null);
                    file.Close();
                }
            }
            catch (PathTooLongException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: The path of LoadChips");
                fileErrorLog.Close();
            }
            catch (FileNotFoundException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: The file of LoadChips is not found");
                fileErrorLog.Close();
            }
            catch (IOException e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: LoadChips - " + e.Message);
                fileErrorLog.Close();
            }
            catch (Exception e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: LoadChips - " + e.Message);
                fileErrorLog.Close();
            }



            return this.chipList;
        }

        public Image GetImg()
        {
            return this.imgChip;
        }
    }
}
