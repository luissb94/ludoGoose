//Luis Sellés Blanes
//V0.01 - Creating box class
//V0.07 - Finished methods to upload and download from ftp
//          and method to load data of the arrayboxes from a file.
//V0.11 - Modified file access methods and added new variables to struct

using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace FinalProjectLudo
{
    public struct BoxProperties
    {
        public int x;
        public int y;
        public int x2;
        public int y2;
        public string color;
        public bool isMultipiece;
        public bool isHouse;
        public bool isFinishBox;
        public bool isEmpty;
        public string chipInside;
        public string chipInside2;
    }


    class Box
    {
        protected string FTPuser = "luisludo";
        protected string FTPpass = "Ef2oo6$0";

        private int Number { get; set; }
        private List<Chip> chips = new List<Chip>();
        protected BoxProperties[] arrayBox = new BoxProperties[115];


        public Box() {
        }
        
        public List<Chip> Chips
        {
            get { return this.chips; }
        }


        //This method will be to check if the box is empty, full or if it got one chip
        public void RemovePiece(Chip chip)
        {
            chips.Remove(chip);

            if (chips.Count == 0)
            {
                arrayBox[chip.GetPosChip()].isEmpty = true;
                //isEmpty = true;
                arrayBox[Number].isMultipiece = false;
                //isMultipiece = false;
            }

            if (chips.Count == 1)
            {
                arrayBox[chip.GetPosChip()].isMultipiece = false;
                //isMultipiece = false;
            }

        }

        //Gets which chip is in the 1nd box
        public string GetPos1(int i)
        {

            return arrayBox[i].chipInside;
        }

        //Gets which chip is in the 2nd box
        public string GetPos2(int i)
        {

            return arrayBox[i].chipInside2;
        }

        //Method to add a Chip into the box
        public void AddChip(Chip chip)
        {

            arrayBox[chip.GetPosChip()].isEmpty = false;
            chips.Add(chip);

            if (chips.Count > 1)
            {
                arrayBox[Number].isMultipiece = true;
            }

        }

        //Method to upload the file boxesData.txt with the content of 
        //all the boxes in Ludo game. After that i will make another
        //method to download this file and parse the data, to make
        //all players get syncronized.
        public void UploadToFtp()
        {
            StreamWriter file = File.CreateText("files/boxesData.txt");

            for(int i = 0; i < arrayBox.Length; i++)
            {
                file.WriteLine(arrayBox[i].x + "," + arrayBox[i].y + ","
                    + arrayBox[i].x2 + "," + arrayBox[i].y2 + "," + arrayBox[i].color
                    + "," + arrayBox[i].isMultipiece + "," + arrayBox[i].isHouse
                    + "," + arrayBox[i].isFinishBox + "," + arrayBox[i].isEmpty);
            }

            file.Close();

            string fileToUpload = "files/boxesData.txt";
            WebClient ftp = new WebClient();

            ftp.Credentials = new NetworkCredential(FTPuser, FTPpass);

            ftp.UploadFile("ftp://185.22.92.60/httpdocs/boxesData.txt","STOR", fileToUpload);
        }

        //Download file from ftp.
        public void DownloadFromFtp()
        {

            string fileToDownload = "files/boxesdownload.txt";
            WebClient ftp = new WebClient();

            ftp.Credentials = new NetworkCredential(FTPuser, FTPpass);

            ftp.DownloadFile("ftp://185.22.92.60/httpdocs/boxesData.txt", fileToDownload);
        }

        //This method reads the data from a given file. It's format is
        //x,y,color,isMultipiece,isHouse,isFinishBox,isEmpty
        public BoxProperties[] LoadData(string fileName)
        {
            try
            {
                StreamReader file = File.OpenText(fileName);
                string line;
                string[] lineSplitted;
                int count = 0;

                do
                {
                    line = file.ReadLine();

                    if (line != null)
                    {
                        lineSplitted = line.Split(',');
                        arrayBox[count].x = Convert.ToInt32(lineSplitted[0]);
                        arrayBox[count].y = Convert.ToInt32(lineSplitted[1]);
                        arrayBox[count].x2 = Convert.ToInt32(lineSplitted[2]);
                        arrayBox[count].y2 = Convert.ToInt32(lineSplitted[3]);
                        arrayBox[count].color = lineSplitted[4];
                        arrayBox[count].isMultipiece = Convert.ToBoolean(lineSplitted[5]);
                        arrayBox[count].isHouse = Convert.ToBoolean(lineSplitted[6]);
                        arrayBox[count].isFinishBox = Convert.ToBoolean(lineSplitted[7]);
                        arrayBox[count].isEmpty = Convert.ToBoolean(lineSplitted[8]);
                        arrayBox[count].chipInside = lineSplitted[9];
                        arrayBox[count].chipInside2 = lineSplitted[10];

                        count++;
                    }
                } while (line != null);

                file.Close();
            }
            catch (PathTooLongException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") + 
                    " - Error: Box.LoadData - The path is too long");
                fileErrorLog.Close();
            }
            catch (FileNotFoundException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.LoadData - The file is not found");
                fileErrorLog.Close();
            }
            catch (IOException e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.LoadData - " + e.Message);
                fileErrorLog.Close();
            }
            catch (Exception e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.LoadData -" + e.Message);
                fileErrorLog.Close();
            }
            return this.arrayBox;
        }

        //Method to save data
        public void SaveData(BoxProperties[] boxes)
        {
            try
            {
                StreamWriter outputFile = File.CreateText("files/boxesData.txt");

                for(int i = 0; i < boxes.Length; i++)
                {
                    outputFile.WriteLine(boxes[i].x + "," + boxes[i].y + "," + boxes[i].x2 +
                        "," + boxes[i].y2 + "," + boxes[i].color + "," + boxes[i].isMultipiece +
                        "," + boxes[i].isHouse + "," + boxes[i].isFinishBox + "," +
                        boxes[i].isEmpty + "," + boxes[i].chipInside + "," + boxes[i].chipInside2);
                }
                outputFile.Close();
            }
            catch (PathTooLongException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.SaveData - The path is too long");
                fileErrorLog.Close();
            }
            catch (FileNotFoundException)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.SaveData -  The file is not found");
                fileErrorLog.Close();
            }
            catch (IOException e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.SaveData -  " + e.Message);
                fileErrorLog.Close();
            }
            catch (Exception e)
            {
                DateTime now = DateTime.Now;
                StreamWriter fileErrorLog = File.AppendText("files/error.log");
                fileErrorLog.WriteLine(now.ToString("yyyy-MM-dd HH:mm:ss") +
                    " - Error: Box.SaveData -  " + e.Message);
                fileErrorLog.Close();
            }
        }
    }
}
