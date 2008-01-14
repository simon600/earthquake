using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// This is abstract class of controller wrapper;
    /// every controller wrapper should derive from it.
    /// </summary>
    public abstract class ControllerWrapper
    {
        /* every controller wrapper has direct access to 
           the controller */
        protected Controller controller;
    }
}
