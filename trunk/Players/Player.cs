using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Maps.Bonuses;

/*
 *   TODO:
 *      -> dodac niezmiennik dla klasy gracza. poczatkowo, niech sprawdza,
 *         czy jego pozycje w odpowiednich systemach wspolrzednych sa zgodne.
 *      
 */

namespace TheEarthQuake.Players
{
    /// <summary>
    /// Player class. Holds every information about the player;
    /// his position (in both coordinate systems), his class and current player state (e.g. currentHeath)
    /// </summary>
    public class Player
    {
        private PlayerClass playerClass; // player class
        private Bonus myBonus;

        private int positionI;    // player position in map fields coordinates
        private int positionJ;    // player position in map fields coordinates

        private float positionX;  // player position in floating coordinates
        private float positionY;  // player position in floating coordinates

        private static float baseStep = (float)0.1;       // base shift of the player pos. when moving
        private static float playerRadius = (float)16;    // border of the player, for collision detection.

        

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
        /// 1) i * fieldSize &gt; x &gt; (i+1) * fieldSize
        /// 2) j * fieldSize &gt; y &gt; (j+1) * fieldSize
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
            this.playerClass = new PlayerClass();
            myBonus = null;
        }


        /// <summary>
        /// Accessors for playerClass. Both get and set.
        /// </summary>
        public PlayerClass PlayerClass
        {
            get
            {
                return playerClass;
            }
            set
            {
                playerClass = value;
            }
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
        /// Accessor for actually speed. Both get and set.
        /// </summary>
        public int Speed
        {
            get
            {
                if (myBonus != null && myBonus.Type == TypeOfBonus.Speed)
                {
                    return playerClass.BasicSpeed + myBonus.Modyfication;
                }
                else
                {
                    return playerClass.BasicSpeed;
                }
            }
        }
        /// <summary>
        /// Accessor for class name. Both get and set.
        /// </summary>
        public string Name
        {
            get
            {
                return playerClass.Name; ;
            }

            set
            {
                playerClass.Name = value;
            }
        }

        /// <summary>
        /// Accessor for texture path. Both get and set.
        /// </summary>
        public string TexturePath
        {
            get
            {
                return playerClass.TexturePath;
            }
            set
            {
                playerClass.TexturePath = value;
            }
        }

        /// <summary>
        /// Access for logo path. Both get and set.
        /// </summary>
        public string LogoPath
        {
            get
            {
                return playerClass.LogoPath;
            }

            set
            {
                playerClass.LogoPath = value;
            }
        }


        /// <summary>
        /// Accessor for mine power. Both get and set.
        /// </summary>
        public int MinePower
        {
            get
            {
                return playerClass.MinePower;
            }

            set
            {
                playerClass.MinePower = value;
            }
        }

        /// <summary>
        /// Accessor for mine range. Both get and set.
        /// </summary>
        public int MineRange
        {
            get
            {
                return playerClass.MineRange;
            }

            set
            {
                playerClass.MineRange = value;
            }
        }

        /// <summary>
        /// Accessor for mine type. Both get and set.
        /// </summary>
        public int MineType
        {
            get
            {
                return playerClass.MineType;
            }

            set
            {
                playerClass.MineType = value;
            }
        }

        /// <summary>
        /// Accessor for shield. Both get and set.
        /// </summary>
        public int Shield
        {
            get
            {
                return playerClass.Shield;
            }

            set
            {
                playerClass.Shield = value;
            }
        }

        /// <summary>
        /// Accessor for a number of mines that player can set simultanously. Both get and set.
        /// </summary>
        public int MaxBomb
        {
            get
            {
                return playerClass.MaxBomb;
            }

            set
            {
                playerClass.MaxBomb = value;
            }
        }

        /// <summary>
        /// Accessor for the time of a mine to blow up. Both get and set.
        /// </summary>
        public int MineDetonationTimeOffset
        {
            get
            {
                return playerClass.MineDetonationTimeOffset;
            }

            set
            {
                playerClass.MineDetonationTimeOffset = value;
            }
        }

        /// <summary>
        /// Accessor for player's maximum health amount. Both get and set.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return playerClass.MaxHealth;
            }
            set
            {
                playerClass.MaxHealth= value;
            }
        }

        /// <summary>
        /// ???. Both get and set.
        /// </summary>
        public bool CanThrow
        {
            get
            {
                return playerClass.CanThrow;
            }

            set
            {
                playerClass.CanThrow = value;
            }
        }

        /// <summary>
        /// Accessor for option saying: can the player walk on mines?. Both get and set.
        /// </summary>
        public bool CanWalkMines
        {
            get
            {
                return playerClass.CanWalkMines;
            }

            set
            {
                playerClass.CanWalkMines = value;
            }
        }

        /// <summary>
        /// Accessor for option: can player move a set up mine? Both get and set.
        /// </summary>
        public bool CanShiftMines
        {
            get
            {
                return playerClass.CanShiftMines;
            }

            set
            {
                playerClass.CanShiftMines = value;
            }
        }

        /// <summary>
        /// Accessor for lives number that player has left. Both get and set.
        /// </summary>
        public int Lives
        {
            get
            {
                return playerClass.Lives;
            }

            set
            {
                playerClass.Lives = value;
            }
        }

        /// <summary>
        /// Accessor for player's health. Both get and set.
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return playerClass.CurrentHealth;
            }

            set
            {
                playerClass.CurrentHealth = value;
            }
        }



        /// <summary>
        /// Modify a player who take bonus
        /// </summary>
        /// <param name="bonus">Finded bonus</param>
        public void TakeBonus(Bonus bonus)
        {
            myBonus = bonus;
            bonus.Activation(this);
            
        }
    }
}