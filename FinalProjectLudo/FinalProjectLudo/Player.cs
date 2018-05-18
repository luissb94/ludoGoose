//Luis Sellés Blanes
//V0.01 -  Creating Player class

using System;

namespace FinalProjectLudo
{
    class Player
    {
        protected string Name { get; set; }
        protected string Color { get; set; }
        protected bool hasWon { get; set; }
        protected bool lastRoll6 { get; set; }
        protected int count6roll { get; set; }

        public Player(string name, string color)
        {
            this.Name = name;
            this.Color = color;
            hasWon = false;
            lastRoll6 = false;
            count6roll = 0;
        }

    }
}
