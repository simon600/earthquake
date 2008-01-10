using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// This is a wrapper allowing MapSelectForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class MapSelectFormControllerWrapper : ControllerWrapper
    {
        public MapSelectFormControllerWrapper(Controller controller)
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
        /// <summary>
        /// This property is used to generate controller wrapper for the form,
        /// that is generated when button2 is pressed. 
        /// </summary>
        public SelectPlayerFormControllerWrapper selectPlayerFormControllerWrapper
        {
            get
            {
                return new SelectPlayerFormControllerWrapper(this.controller);
            }
        }

        /// <summary>
        /// This property is used to generate a controller wrapper, for the form,
        /// that is generated when button1 is pressed.
        /// </summary>
        public GameFormControllerWrapper gameFormControllerWrapper
        {
            get
            {
                return new GameFormControllerWrapper(this.controller);
            }
        }
    }
}
