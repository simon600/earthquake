using System;
using System.Collections.Generic;
using System.Text;

/*
 *   TODO:
 *      -> dodac niezmiennik dla klasy gracza. poczatkowo, niech sprawdza,
 *         czy jego pozycje w odpowiednich systemach wspolrzednych sa zgodne.
 *      -> uzupelnic komentarze w kodzie (pola klasy)
 */

namespace TheEarthQuake.Players
{
    /// <summary>
    /// Player class. Holds every information about the player;
    /// his position (in both coordinate systems), its speed, its 
    /// actual mine attributes, etc, etc.
    /// </summary>
    public class Player
    {
        private int positionI;    // player position in map fields coordinates
        private int positionJ;    // player position in map fields coordinates

        private float positionX;  // player position in floating coordinates
        private float positionY;  // player position in floating coordinates

        private int speed;        // player speed
        private int minePower;    // how strong player's mines are 
        private int mineRange;    // radius of mine explosion (in map fields)
        private int mineType;     // mine type 
        private int shield;       // how many points of shield player has
        private int lives;        // number of lifes that player 
        private int currentHealth;// current player health
        private int maxHealth;    // player maximum health amount
        private int simultanousMines; //how many mines player can set simultanously
        private int mineDetonationTimeOffset; //how many seconds elapsed between mine setting and mine explosion

        private bool triggeredMines; //tells if player can blow up mine remotly
        private bool canThrow;       //tells if player can throw mines
        private bool canWalkMines;   //tells if player can walth through set mines
        private bool canShiftMines;  //tells if player can shift set mines

        private static float baseStep = (float)1;           // base shift of the player pos. when moving
        private static float playerRadius = (float)12.5;    // border of the player, for collision detection.

        /// <summary>
        /// Accessor for base shift of the player position. Only get.
        /// </summary>
        public static float BaseStep
        {
            get
            {
                return baseStep;
            }
        }

        /// <summary>
        /// Accessor for the player's border. Only get.
        /// </summary>
        public static float PlayerRadius
        {
            get
            {
                return playerRadius;
            }
        }

        /// <summary>
        /// Constructor for a player. 
        /// Warning: initial parameters must hold
        /// these inequations:
        /// 1) i * fieldSize < x < (i+1) * fieldSize
        /// 2) j * fieldSize < y < (j+1) * fieldSize
        /// </summary>
        /// <param name="i">height in discrete coordinate system</param>
        /// <param name="j">width in discrete coordinate system</param>
        /// <param name="x">height in floating point coordinate system</param>
        /// <param name="y">width in floating point coordinate system</param>
        public Player(int i, int j, float x, float y)
        {
            positionI = i;
            positionJ = j;
            positionX = x;
            positionY = y;
        }

        /// <summary>
        /// Accessor to height in discrete coordinate system. Both get and set.
        /// </summary>
        public int PositionI
        {
            get
            {
                return this.positionI;
            }

            set
            {
                this.positionI = value;
            }
        }

        /// <summary>
        /// Accessor for width in discrete coordinate system. Both get and set.
        /// </summary>
        public int PositionJ
        {
            get
            {
                return this.positionJ;
            }

            set
            {
                this.positionJ = value;
            }
        }

        /// <summary>
        /// Accessor for heigth in floating point coordinate system. Both get and set.
        /// </summary>
        public float PositionX
        {
            get
            {
                return this.positionX;
            }

            set
            {
                this.positionX = value;
            }
        }

        /// <summary>
        /// Accessor for width in floating point coordinate system. Both get and set.
        /// </summary>
        public float PositionY
        {
            get
            {
                return this.positionY;
            }

            set
            {
                this.positionY = value;
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
        /// Accessor for lives number that player has left. Both get and set.
        /// </summary>
        public int Lives
        {
            get
            {
                return this.lives;
            }

            set
            {
                this.lives = value;
            }
        }

        /// <summary>
        /// Accessor for player's health. Both get and set.
        /// </summary>
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
        /// Accessor for a number of mines already triggered. Both get and set.
        /// </summary>
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