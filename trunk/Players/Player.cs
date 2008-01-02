using System;
using System.Collections.Generic;
using System.Text;

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
        private PlayerState playerState; // current player state

        private int positionI;    // player position in map fields coordinates
        private int positionJ;    // player position in map fields coordinates

        private float positionX;  // player position in floating coordinates
        private float positionY;  // player position in floating coordinates

        private static float baseStep = (float)1;           // base shift of the player pos. when moving
        private static float playerRadius = (float)18.5;    // border of the player, for collision detection.


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
            this.playerClass.Speed = 2;
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
        /// Accessors for playerState. Both get and set.
        /// </summary>
        public PlayerState PlayerState
        {
            get
            {
                return playerState;
            }

            set
            {
                playerState = value;
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


    }
}