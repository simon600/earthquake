using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Engine;

/*
    TODO: Zamknac wrappery w podjednostce projektu? (namespace, statyczne 
 *        w klasie kontrolera? )
 */

namespace TheEarthQuake.Logic
{        
    /// <summary>
    /// Controller class represents a module, that sets up other modules
    /// and performs actions on state machine.
    /// </summary>
    public class Controller
    {
        private Engine.Engine graphicsEngine;       // graphics engine, the only one
        private StateMachine stateMachine;          // the only state machine 
        private static Controller instace;          // main controller for game

        public static Controller Instace
        {
            get
            {
                if (instace == null)
                {
                    instace = new Controller();
                }
                return instace;
            }
        }





        public Engine.Engine GraphicsEngine
        {
            get
            {
                return this.graphicsEngine;
            }

            set
            {
                this.graphicsEngine = value;
            }
        }

        public StateMachine StateMachine
        {
            get
            {
                return this.stateMachine;
            }
        }

        /// <summary>
        /// Constructor. Creates the only instances of state machine
        /// and graphics engine.
        /// </summary>
        public Controller()
        {
            stateMachine = new StateMachine();
        }

        public void MovePlayer1Up()
        {
            this.stateMachine.MovePlayer(Players.Player1, Directions.Up);
        }
        public void MovePlayer1Down()
        {
            this.stateMachine.MovePlayer(Players.Player1, Directions.Down);
        }
        public void MovePlayer1Left()
        {
            this.stateMachine.MovePlayer(Players.Player1, Directions.Left);
        }
        public void MovePlayer1Right()
        {
            this.stateMachine.MovePlayer(Players.Player1, Directions.Right);
        }

        public void Player1Special()
        {
            /* should run state-machines method player1special */
        }
        public void Player1SetUpBomb()
        {
            /* should run state-machines method player1setupbomb */
        }

        public void MovePlayer2Up()
        {
            this.stateMachine.MovePlayer(Players.Player2, Directions.Up);
        }
        public void MovePlayer2Down()
        {
            this.stateMachine.MovePlayer(Players.Player2, Directions.Down);
        }
        public void MovePlayer2Left()
        {
            this.stateMachine.MovePlayer(Players.Player2, Directions.Left);
        }
        public void MovePlayer2Right()
        {
            this.stateMachine.MovePlayer(Players.Player2, Directions.Right);
        }

        public void Player2Special()
        {
            /* should run state-machines method player1special */
        }
        public void Player2SetUpBomb()
        {
            /* should run state-machines method player1setupbomb */
        }

        /// <summary>
        /// Set up a new game. 
        /// Should be called whenever a new game is started.
        /// </summary>
        public void NewGame()
        {
            graphicsEngine = new Engine.Engine();
            stateMachine.CreateGame();              // init machine to a new game

            /* Engine does not have any rights to change anything in
             * map; though, it takes a map wrapper, that restricts 
             * engine rights to reading from the map. 
             */
            graphicsEngine.SetMapWrapper(stateMachine.GetMapWrapper());
        }
    }
}
