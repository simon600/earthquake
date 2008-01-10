using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// This is a wrapper allowing WelcomForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class WelcomeFormControllerWrapper : ControllerWrapper
    {
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
        public WelcomeFormControllerWrapper(Controller controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// This property is used to generate controller wrapper for 
        /// the form, which is created when "startbutton" is pressed.
        /// </summary>
        public SelectPlayerFormControllerWrapper SelectPlayersFormControllerWrapper
        {
            get
            {
                return new SelectPlayerFormControllerWrapper(this.controller);
            }
        }

        /// <summary>
        /// This property is used to generate controller wrapper for 
        /// the form, which is created when "optionbutton" is pressed.
        /// </summary>
        public GameOptionsFormControllerWrapper GameOptionsFormControllerWrapper
        {
            get
            {
                return new GameOptionsFormControllerWrapper(this.controller);
            }
        }
    }
}
