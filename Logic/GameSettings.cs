using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// A bunch of resolutions that user can choose from.
    /// </summary>
    public enum Resolution { r640x480 = 1, r800x600, r1024x768, r1280x1024, r1280x800 };

    /// <summary>
    /// GameSettings class holds settings for the program.
    /// Those setting are global for every game instance.
    /// (e.g. they do not need to be set up every time we create a new game)
    /// </summary>
    public class GameSettings
    {
        private Resolution gameResolution = Resolution.r800x600;      
        private bool soundOn = true;        

        /// <summary>
        /// Accessor for the resolution set. Both get and set.
        /// </summary>
        public Resolution GameResolution
        {
            get
            {
                return gameResolution;
            }
            set
            {
                gameResolution = value;
            }
        }

        /// <summary>
        /// Accessor for sound on/off option. Both set and get.
        /// </summary>
        public bool SoundOn
        {
            get
            {
                return soundOn;
            }
            set
            {
                soundOn = value;
            }
        }
    }
}
