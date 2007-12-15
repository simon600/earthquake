using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    public enum Resolution { r640x480 = 1, r800x600, r1024x768, r1280x1024, r1280x800 };

    public class GameSettings
    {
        private Resolution gameResolution = Resolution.r800x600;      
        private bool soundOn = true;        

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
