using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    public class StateMachine
    {
        private static float fieldSize = 35;
        private static float width = 1024;
        private static float height = 768;       

        private Logic.Maps.Map map;
        private State currentState = null;
        private GameSettings currentGameSettings;
        private float currentFPS;

        public static float FieldSize
        {
            get
            {
                return fieldSize;
            }
        }

        public static float Height
        {
            get
            {
                return StateMachine.height;
            }
        } 

        public static float Width
        {
            get
            {
                return StateMachine.width;
            }
        } 

        public Logic.Maps.Map Map
        {
            get
            {
                return map;
            }
        }

        public State CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public GameSettings CurrentGameSettings
        {
            get
            {
                return currentGameSettings;
            }
        }

        public float CurrentFPS
        {
            get
            {
                return currentFPS;
            }
            set
            {
                currentFPS = value;
            }
        }

        public StateMachine()
        {
            map = new Maps.Map();
        }
    }
}
