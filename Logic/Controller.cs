using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Engine;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// Controller class represents a module, that sets up other modules
    /// and interacts with user.
    /// </summary>
    class Controller
    {
        private Engine.Engine graphicsEngine;       // graphics engine, the only one
        private StateMachine stateMachine;          // the only state machine 

        /// <summary>
        /// Constructor. Creates the only instances of state machine
        /// and graphics engine.
        /// </summary>
        public Controller()
        {
            stateMachine = new StateMachine();
            graphicsEngine = new Engine.Engine();

            NewGame();                              // sets up a new game
        }

        /// <summary>
        /// Method that runs the controller. 
        /// </summary>
        public void Run()
        { 
            
       
        }

        /// <summary>
        /// Set up a new game. 
        /// Should be called whenever a new game is started.
        /// </summary>
        private void NewGame()
        {
            stateMachine.CreateGame();              // init machine to a new game

            /* Engine does not have any rights to change anything in
             * map; though, it takes a map wrapper, that restricts 
             * engine rights to reading from the map. 
             */
            graphicsEngine.SetWrapper(stateMachine.GetWrapper());
        }
    }
}
