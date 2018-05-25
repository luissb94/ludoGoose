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
        protected Box box;
        protected Image imgChip;
        protected List<Chip> chipList = new List<Chip>();

        public Chip() { }

        public Chip(string color, int num_piece,bool isAtHome, bool isAtFinish, int poschip, Image imgChip)
        {
            this.color = color;
            this.num_piece = num_piece;
            this.posChip = poschip;
            this.isAtFinish = isAtFinish;
            this.isAtHome = isAtHome;
            this.imgChip = imgChip;
        }

        //Gets the position of the chip
        public int GetPosChip()
        {
            return posChip;
        }

        //Sets the position of the chip
        public void SetPosChip(int i)
        {
            posChip = i;
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

        //Loads the data of the chips from a file
        public List<Chip> Load()
        {
            try
            {
                string fileChipData = "files/chipdata.txt";
                StreamReader file = File.OpenText(fileChipData);
                string line;
                string[] lines;
                int count = 0;

                do
                {
                    line = file.ReadLine();
                    if(line != null)
                    {
                        lines = line.Split(',');
                        
                        chipList.Add(new Chip(lines[0], Convert.ToInt32(lines[1]), 
                            Convert.ToBoolean(lines[2]), Convert.ToBoolean(lines[3]),
                            Convert.ToInt32(lines[4]), new Image(lines[5], 35, 35)));
                        count++;
                    }
                } while (line != null);
                file.Close();
            }
            catch (Exception e)
            {
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine("Error: " + e.Message);
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
