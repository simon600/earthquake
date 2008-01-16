using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Windows.Forms;

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
            playerOneKeys = new GameControllKeys(Maps.Players.Player1);
            playerTwoKeys = new GameControllKeys(Maps.Players.Player2);
            LoadFromXML();
        }

        private void LoadFromXML()
        {
            XmlDocument document = new XmlDocument();
            document.Load(ConfigurationManager.AppSettings["gameConfig"]);

            this.musicVolume = Convert.ToInt32(document.SelectSingleNode("/GameSettings/Music").InnerText);
            this.soundVolume = Convert.ToInt32(document.SelectSingleNode("/GameSettings/Sound").InnerText);
            this.bonusesOn = Convert.ToBoolean(document.SelectSingleNode("/GameSettings/BonusesOn").InnerText);
            this.gameSpeed = Convert.ToInt32(document.SelectSingleNode("/GameSettings/GameSpeed").InnerText);

            playerOneKeys.Up = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Up").InnerText);
            playerOneKeys.Down = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Down").InnerText);
            playerOneKeys.Left = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Left").InnerText);
            playerOneKeys.Right = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Right").InnerText);
            playerOneKeys.Bomb = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Bomb").InnerText);
            playerOneKeys.Special = (Keys) Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Special").InnerText);

            playerTwoKeys.Up = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Up").InnerText);
            playerTwoKeys.Down = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Down").InnerText);
            playerTwoKeys.Left = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Left").InnerText);
            playerTwoKeys.Right = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Right").InnerText);
            playerTwoKeys.Bomb = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Bomb").InnerText);
            playerTwoKeys.Special = (Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Special").InnerText);
        }


        public void UpdateXML()
        {
            XmlDocument document = new XmlDocument();
            document.Load(ConfigurationManager.AppSettings["gameConfig"]);

            document.SelectSingleNode("/GameSettings/Music").InnerText = this.musicVolume.ToString();
            document.SelectSingleNode("/GameSettings/Sound").InnerText = this.soundVolume.ToString();
            document.SelectSingleNode("/GameSettings/BonusesOn").InnerText = this.bonusesOn.ToString();
            document.SelectSingleNode("/GameSettings/GameSpeed").InnerText = this.gameSpeed.ToString();

            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Up").InnerText = ((int)playerOneKeys.Up).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Down").InnerText = ((int)playerOneKeys.Down).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Left").InnerText = ((int)playerOneKeys.Left).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Right").InnerText = ((int)playerOneKeys.Right).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Bomb").InnerText = ((int)playerOneKeys.Bomb).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerOne/Special").InnerText = ((int)playerOneKeys.Special).ToString();

            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Up").InnerText = ((int)playerTwoKeys.Up).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Down").InnerText = ((int)playerTwoKeys.Down).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Left").InnerText = ((int)playerTwoKeys.Left).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Right").InnerText = ((int)playerTwoKeys.Right).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Bomb").InnerText = ((int)playerTwoKeys.Bomb).ToString();
            document.SelectSingleNode("/GameSettings/Controlls/PlayerTwo/Special").InnerText = ((int)playerTwoKeys.Special).ToString();
            
            document.Save(ConfigurationManager.AppSettings["gameConfig"]);
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
