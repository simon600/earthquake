using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{

    /// <summary>
    /// GameSettings class holds settings for the program.
    /// Those setting are global for every game instance.
    /// (e.g. they do not need to be set up every time we create a new game)
    /// </summary>
    public class GameSettings
    {
        // game speed 
        private int gameSpeed = 4;

        // say if bonuses is enabled
        private bool bonusesOn = true;
        
        // sound value percentage
        private int soundVolume = 0;

        // music volume percentage 
        private int musicVolume = 0;

        //  a keys settings for player one
        private GameControllKeys playerOneKeys;

        //  a keys settings for player two
        private GameControllKeys playerTwoKeys;


        public GameSettings()
        {
            playerOneKeys = new GameControllKeys(Players.Player1);
            playerTwoKeys = new GameControllKeys(Players.Player2);
        }

        public int GameSpeed
        {
            get { return gameSpeed; }
            set { gameSpeed = value; }
        }

        public bool BonusesOn
        {
            get { return bonusesOn; }
            set { bonusesOn = value; }
        }


        public int SoundVolume
        {
            get { return soundVolume; }
            set { soundVolume = value; }
        }

        public int MusicVolume
        {
            get { return musicVolume; }
            set { musicVolume = value; }
        }

        public GameControllKeys PlayerOneKeys
        {
            get { return playerOneKeys; }
            set { playerOneKeys = value; }
        }

        public GameControllKeys PlayerTwoKeys
        {
            get { return playerTwoKeys; }
            set { playerTwoKeys = value; }
        }
    }
}
