using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// This is a wrapper allowing SelectPlayerForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class SelectPlayerFormControllerWrapper : ControllerWrapper
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
        public SelectPlayerFormControllerWrapper(Controller controller)
        {
            this.controller = controller;
        }

        public MapSelectFormControllerWrapper MapSelectFormControllerWrapper
        {
            get
            {
                return new MapSelectFormControllerWrapper(this.controller);
            }
        }
    }
}
