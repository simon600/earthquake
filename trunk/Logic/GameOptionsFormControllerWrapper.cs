using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// This is a wrapper allowing GameOptionsForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class GameOptionsFormControllerWrapper : ControllerWrapper
    {
        public GameOptionsFormControllerWrapper(Controller controller)
        {
            this.controller = controller;
        }
        public Engine.Engine GraphicsEngine
        {
            get
            {
                return controller.GraphicsEngine;
            }
        }
        public StateMachine StateMachine
        {
            get
            {
                return controller.StateMachine;
            }
        }
    }
}
