//Luis Sellés Blanes
//V0.01 -  Creating Player class

using System;
using System.Collections.Generic;

namespace FinalProjectLudo
{
    class Player
    {
        protected string name;
        protected string color;
        protected bool hasWon;
        protected bool lastRoll6;
        protected int count6roll = 0;
        protected int chipsOut = 0;
        protected bool GotWall = false;
        protected Chip chip;
        protected List<Chip> playerChips;
        protected bool repeatTurn = false;

        public Player(string name, string color)
        {
            this.name = name;
            this.color = color;
            this.hasWon = false;
            this.lastRoll6 = false;
            this.count6roll = 0;
            this.chip = new Chip();
            this.playerChips = new List<Chip>();
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

        public void SetChipsOut()
        {
            chipsOut++;
        }
        public int GetChipsOut()
        {
            return chipsOut;
        }

        public void SetRepeatTurn(bool status)
        {
            this.repeatTurn = status;
        }

        public bool GetRepeatTurn()
        {
            return this.repeatTurn;
        }

        public List<Chip> GetPlayerChip()
        {
            playerChips = chip.Load();
            return this.playerChips;
        }
    }
}
