//Luis Sellés Blanes
//V0.01 - Creating dice class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectLudo
{
    class Dice
    {
        Random rand_num;
        protected int Number;

        public Dice()
        {
            rand_num = new Random();
        }

        //Method to get a roll between 1 and 6
        public int GetRollValue()
        {
            Number = rand_num.Next(1, 7);
            return Number;
        }
    }
}
