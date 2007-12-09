using System;
using System.Collections.Generic;
using System.Text;

namespace StateMachine
{
    public class StateMachine
    {
        private State currentState = null;
        private GameSettings currentGameSettings;
        private float currentFPS;

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
    }
}
