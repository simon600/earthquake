using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachine
{
    public enum MainMenuItem { start = 1, opcje, koniec };
    public enum StartMenuItem { play = 1, back, generateMap };

    public abstract class State
    {
        protected Map.Map currentMap = null;
    }

    public class GameState : State
    {        
        private Player.Player[] players = null;

        public Map.Map CurrentMap
        {
            get
            {
                return currentMap;
            }
        }

        public Player.Player[] Players
        {
            get
            {
                return players;
            }
        }
    }

    public class MainMenuState : State
    {        
        private MainMenuItem currentMainMenuItem = MainMenuItem.start;

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

    public class StartMenu : State
    {
        public Map.Map CurrentMap
        {
            get
            {
                return currentMap;
            }
        }
    }


}
