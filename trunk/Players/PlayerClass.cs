/*
 *  Author: Karol Stosiek, Marcin Golebiowski
 */ 
using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Players
{
    /**
     * Player Class. Holds information about what values attributes have in some player class.
     *
     */
    public class PlayerClass
    {
        private string name;       // player class name
        private int speed;        // player speed
        private int minePower;    // how strong player's mines are 
        private int mineRange;    // radius of mine explosion (in map fields)
        private int mineType;     // mine type 
        private int shield;       // how many points of shield player has

        private int maxHealth;    // player maximum health amount
        private int simultanousMines; //how many mines player can set simultanously
        private int mineDetonationTimeOffset; //how many seconds elapsed between mine setting and mine explosion

        private bool canThrow;       //tells if player can throw mines
        private bool canWalkMines;   //tells if player can walk through set mines
        private bool canShiftMines;  //tells if player can shift set mines


        private string texturePath; // path to file with player texture
        private string logoPath;  // path to file with player class logo
        
        public PlayerClass()
        {

        }

        /// <summary>
        /// Accessor for class name. Both get and set.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Accessor for texture path. Both get and set.
        /// </summary>
        public string TexturePath
        {
            get
            {
                return texturePath;
            }
            set
            {
                texturePath = value;
            }
        }

        /// <summary>
        /// Access for logo path. Both get and set.
        /// </summary>
        public string LogoPath
        {
            get
            {
                return logoPath;
            }

            set
            {
                logoPath = value;
            }
        }

        /// <summary>
        /// Accessor for player's speed. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for mine power. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for mine range. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for mine type. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for shield. Both get and set.
        /// </summary>
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

       
     

        /// <summary>
        /// Accessor for a number of mines that player can set simultanously. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for the time of a mine to blow up. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for player's maximum health amount. Both get and set.
        /// </summary>
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

       

        /// <summary>
        /// ???. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for option saying: can the player walk on mines?. Both get and set.
        /// </summary>
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

        /// <summary>
        /// Accessor for option: can player move a set up mine? Both get and set.
        /// </summary>
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
