using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Players
{
    public class PlayerWrapper
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
                return player.PlayerClass.Speed;
            }
        }

        /// <summary>
        /// Accessor for mine power.
        /// </summary>
        public int MinePower
        {
            get
            {
                return player.PlayerClass.MinePower;
            }
        }

        /// <summary>
        /// Accessor for mine range.
        /// </summary>
        public int MineRange
        {
            get
            {
                return player.PlayerClass.MineRange;
            }
        }

        /// <summary>
        /// Accessor for mine type.
        /// </summary>
        public int MineType
        {
            get
            {
                return player.PlayerClass.MineType;
            }
        }

        /// <summary>
        /// Accessor for shield.
        /// </summary>
        public int Shield
        {
            get
            {
                return player.PlayerClass.Shield;
            }
        }

        /// <summary>
        /// Accessor for lives number that player has left.
        /// </summary>
        public int Lives
        {
            get
            {
                return player.PlayerState.Lives;
            }
        }

        /// <summary>
        /// Accessor for player's health.
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                return player.PlayerState.CurrentHealth;
            }
        }

        /// <summary>
        /// Accessor for a number of mines that player can set simultanously.
        /// </summary>
        public int SimultanousMines
        {
            get
            {
                return player.PlayerClass.SimultanousMines;
            }
        }

        /// <summary>
        /// Accessor for the time of a mine to blow up.
        /// </summary>
        public int MineDetonationTimeOffset
        {
            get
            {
                return player.PlayerClass.MineDetonationTimeOffset;
            }
        }

        /// <summary>
        /// Accessor for player's maximum health amount.
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return player.PlayerClass.MaxHealth;
            }
        }

        /// <summary>
        /// Accessor for a number of mines already triggered.
        /// </summary>
        public bool TriggeredMines
        {
            get
            {
                return player.PlayerState.TriggeredMines;
            }
        }

        /// <summary>
        /// ???. Both get and set.
        /// </summary>
        public bool CanThrow
        {
            get
            {
                return player.PlayerClass.CanThrow;
            }
        }

        /// <summary>
        /// Accessor for option saying: can the player walk on mines?.
        /// </summary>
        public bool CanWalkMines
        {
            get
            {
                return player.PlayerClass.CanWalkMines;
            }
        }

        /// <summary>
        /// Accessor for option: can player move a set up mine?
        /// </summary>
        public bool CanShiftMines
        {
            get
            {

                return player.PlayerClass.CanShiftMines;
            }
        }
    }
}
