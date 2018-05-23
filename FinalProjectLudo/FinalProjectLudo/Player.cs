//Luis Sellés Blanes
//V0.01 -  Creating Player class

using System;

namespace FinalProjectLudo
{
    class Player
    {
        protected string name;
        protected string color;
        protected bool hasWon;
        protected bool lastRoll6;
        protected int count6roll = 0;
        
        public Player(string name, string color)
        {
            this.name = name;
            this.color = color;
            this.hasWon = false;
            this.lastRoll6 = false;
            this.count6roll = 0;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetColor()
        {
            return this.color;
        }

        public bool GetWin()
        {
            return this.hasWon;
        }

        public bool GetLastRoll()
        {
            return this.lastRoll6;
        }

        public int GetCount6Rolls()
        {
            return this.count6roll;
        }
    }
}
