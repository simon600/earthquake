using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Players
{
    /*
     * PlayerState. Holds information about the current player state
     *
     */
    public class PlayerState
    {
        private int currentHealth;// current player health
        private int lives;        // number of lifes that player has left 
        private bool triggeredMines; // number of mines already triggered

        public PlayerState()
        {
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
    }
}
