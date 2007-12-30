using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    class PlayerWrapper
    {
        private Player player;

        /// <summary>
        /// Constructor for PlayerWrapper.
        /// </summary>
        /// <param name="player">Player to wrap</param>
        public PlayerWrapper(Player player)
        {   
            this.player = player;
        }

        /// <summary>
        /// Accessor for base shift of the player position.
        /// </summary>
        public static float BaseStep
        {
            get 
            {
                return Player.BaseStep;
            }
        }

        /// <summary>
        /// Accessor for the player's border.
        /// </summary>
        public static float PlayerRadius
        {
            get
            {
                return Player.PlayerRadius;
            }
        }
       
        /// <summary>
        /// Accessor to height in discrete coordinate system.
        /// </summary>
        public int PositionI
        {
            get 
            {
                return player.PositionI;
            }
        }

        /// <summary>
        /// Accessor for width in discrete coordinate system.
        /// </summary>
        public int PositionJ
        {
            get
            {
                return player.PositionJ;
            }
        }
        
        /// <summary>
        /// Accessor for heigth in floating point coordinate system.
        /// </summary>
        public float PositionX
        {
            get
            {
                return player.PositionX;
            }
        }

        /// <summary>
        /// Accessor for width in floating point coordinate system.
        /// </summary>
        public float PositionY
        {
            get
            {
                return player.PositionY;
            }
        }

        /// <summary>
        /// Accessor for player's speed.
        /// </summary>
        public int Speed
        {
            get
            {
                return player.Speed;
            }
        }

        /// <summary>
        /// Accessor for mine power.
        /// </summary>
        public int MinePower
        {
            get
            {
                return player.MinePower;
            }
        }

        /// <summary>
        /// Accessor for mine range.
        /// </summary>
        public int MineRange
        {
            get
            {
                return player.MineRange;
            }
        }

        /// <summary>
        /// Accessor for mine type.
        /// </summary>
        public int MineType
        {
            get
            {
                return player.MineType;
            }
        }

        /// <summary>
        /// Accessor for shield.
        /// </summary>
        public int Shield
        {
            get
            {
                return player.Shield;
            }
        }

        /// <summary>
        /// Accessor for lives number that player has left.
        /// </summary>
        public int Lives
        {
            get
            {
                return player.Lives;
            }
        }

        /// <summary>
        /// Accessor for player's health.
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return player.CurrentHealth;
            }
        }

        /// <summary>
        /// Accessor for a number of mines that player can set simultanously.
        /// </summary>
        public int SimultanousMines
        {
            get
            {
                return player.SimultanousMines;
            }
        }

        /// <summary>
        /// Accessor for the time of a mine to blow up.
        /// </summary>
        public int MineDetonationTimeOffset
        {
            get
            {
                return player.MineDetonationTimeOffset;
            }
        }

        /// <summary>
        /// Accessor for player's maximum health amount.
        /// </summary>
        public int MaxHealth
        {
            get
            { 
                return player.MaxHealth;
            }
        }

        /// <summary>
        /// Accessor for a number of mines already triggered.
        /// </summary>
        public bool TriggeredMines
        {
            get
            {
                return player.TriggeredMines;
            }
        }

        /// <summary>
        /// ???. Both get and set.
        /// </summary>
        public bool CanThrow
        {
            get
            {
                return player.CanThrow;
            }
        }

        /// <summary>
        /// Accessor for option saying: can the player walk on mines?.
        /// </summary>
        public bool CanWalkMines
        {
            get
            {
                return player.CanWalkMines;
            }
        }

        /// <summary>
        /// Accessor for option: can player move a set up mine?
        /// </summary>
        public bool CanShiftMines
        {
            get
            {

                return player.CanShiftMines;
            }
        }
    }
}
