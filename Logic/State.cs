using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Maps;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// Options available from main menu.
    /// </summary>
    public enum MainMenuItem { start = 1, options, end };

    /// <summary>
    /// Options available from start menu.
    /// </summary>
    public enum StartMenuItem { play = 1, back, generateMap };

    /// <summary>
    /// Abstract class state - any machine state must derive from it.
    /// </summary>
    public abstract class State
    {
        protected Map currentMap = null;
    }

    /// <summary>
    /// Machine state: Game. When machine state is game, 
    /// then players are both having fun with trying to blow up each other.
    /// </summary>
    public class GameState : State
    {        
        private Player[] players = null;    // array holding players 

        /// <summary>
        /// Accessor for the map that is being drawn. Only get.
        /// </summary>
        public Map CurrentMap
        {
            get
            {
                return currentMap;
            }
        }

        /// <summary>
        /// Accessor for array of players. Only get.
        /// </summary>
        public Player[] Players
        {
            get
            {
                return players;
            }
        }
    }

    /// <summary>
    /// Machine state: Main Menu. In this state user chooses,
    /// from main menu options, what does he want to do.
    /// </summary>
    public class MainMenuState : State
    {
        /// <summary>
        /// Default option.
        /// </summary>
        private MainMenuItem currentMainMenuItem = MainMenuItem.start;

        /// <summary>
        /// Accessor for main menu item. Both get and set.
        /// </summary>
        public MainMenuItem CurrentMainMenuItem
        {
            get
            {
                return currentMainMenuItem;
            }
            set
            {
                currentMainMenuItem = value;
            }
        }
    }

    /// <summary>
    /// Machine state: Start Menu. In this state user chooses,
    /// from start menu options, what does he want to do.
    /// </summary>
    public class StartMenu : State
    {
        public Map CurrentMap
        {
            get
            {
                return currentMap;
            }
        }
    }


}
