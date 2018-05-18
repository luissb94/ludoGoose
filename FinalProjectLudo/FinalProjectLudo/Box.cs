//Luis Sellés Blanes
//V0.01 - Creating box class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLudo
{
    public struct BoxPropietes
    {
        public int x;
        public int y;
        public string color;
        public bool isMultipiece;
        public bool isHouse;
        public bool isFinishBox;
        public bool isEmpty;
    }


    class Box
    {
        //protected string Color { get; set; }
        //protected int X;
        //protected int Y;
        private int Number { get; set; }
        //private bool isMultipiece { get; set; }
        //private bool isHouse { get; set; }
        //private bool isFinishBox { get; set; }
        //private bool isEmpty { get; set; }

        private List<Chip> chips = new List<Chip>();
        protected BoxPropietes[] arrayBox = new BoxPropietes[104];

        public Box() { }


        /*
        public Box(string color, int number, bool isHouse, bool isFinishBox, bool isEmpty)
        {
            this.Color = color;
            this.Number = number;
            this.isHouse = isHouse;
            this.isFinishBox = isFinishBox;
        }
        */


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

    }
}
