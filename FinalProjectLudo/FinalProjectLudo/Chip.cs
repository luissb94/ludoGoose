//Luis Selles Blanes
//V0.01 - Creating Chip class


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLudo
{
    class Chip
    {
        protected string Color { get; set; }
        protected int Num_piece { get; set; }
        protected bool IsAtHome { get; set; }
        protected bool IsAtFinish { get; set; }
        protected int posChip;
        protected Box box;

        public Chip(string color, int num_piece,int poschip)
        {
            this.Color = color;
            this.Num_piece = num_piece;
            this.posChip = poschip;
            IsAtFinish = false;
            IsAtHome = true;
        }

        public int GetPosChip()
        {
            return posChip;
        }

        public void SetPosChip(int i)
        {
            posChip = i;
        }
    }
}
