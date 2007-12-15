using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    public class Player
    {
        private int speed;//
        private int minePower;//
        private int mineRange;//
        private int mineType;
        private int shield;
        private int lifes;
        private int currentHealth;
        private int maxHealth;//
        private int simultanousMines;//
        private int mineDetonationTimeOffset;

        private bool triggeredMines;
        private bool canThrow;
        private bool canWalkMines;
        private bool canShiftMines;


        public Player()
        {

        }

        public int Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                this.speed = value;
            }
        }

        public int MinePower
        {
            get
            {
                return this.minePower;
            }

            set
            {
                this.minePower = value;
            }
        }

        public int MineRange
        {
            get
            {
                return this.mineRange;
            }

            set
            {
                this.mineRange = value;
            }
        }

        public int MineType
        {
            get
            {
                return this.mineType;
            }

            set
            {
                this.mineType = value;
            }
        }


        public int Shield
        {
            get
            {
                return this.shield;
            }

            set
            {
                this.shield = value;
            }
        }

        public int Lifes
        {
            get
            {
                return this.lifes;
            }

            set
            {
                this.lifes = value;
            }
        }



        public int CurrentHealth
        {
            get
            {
                return this.currentHealth;
            }

            set
            {
                this.currentHealth = value;
            }
        }


        public int SimultanousMines
        {
            get
            {
                return this.simultanousMines;
            }

            set
            {
                this.simultanousMines = value;
            }
        }

        public int MineDetonationTimeOffset
        {
            get
            {
                return this.mineDetonationTimeOffset;
            }

            set
            {
                this.mineDetonationTimeOffset = value;
            }
        }

        public int MaxHealth
        {
            get
            { 
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }



        public bool TriggeredMines
        {
            get
            {
                return this.triggeredMines;
            }

            set
            {
                this.triggeredMines = value;
            }
        }


        public bool CanThrow
        {
            get
            {
                return this.canThrow;
            }

            set
            {
                this.canThrow = value;
            }
        }

        public bool CanWalkMines
        {
            get
            {
                return this.canWalkMines;
            }

            set
            {
                this.canWalkMines = value;
            }
        }


        public bool CanShiftMines
        {
            get
            {

                return this.canShiftMines;
            }

            set
            {
                this.canShiftMines = value;
            }
        }
    }
}
