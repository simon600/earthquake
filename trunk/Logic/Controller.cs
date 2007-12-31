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
    /// This is abstract class of controller wrapper;
    /// every controller wrapper should derive from it.
    /// </summary>
    public abstract class ControllerWrapper
    {
        /* every controller wrapper has direct access to 
           the controller */
        protected Controller controller;  
    }

    /// <summary>
    /// This is a wrapper allowing GameForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class GameFormControllerWrapper : ControllerWrapper
    {
        public GameFormControllerWrapper(Controller controller)
        {
            this.controller = controller;
        }

        public void MovePlayer1Up()
        {
            this.controller.MovePlayer1Up();
        }
        public void MovePlayer1Down()
        {
            this.controller.MovePlayer1Down();
        }
        public void MovePlayer1Left()
        {
            this.controller.MovePlayer1Left();
        }
        public void MovePlayer1Right()
        {
            this.controller.MovePlayer1Right();
        }

        public void Player1Special()
        {
            this.controller.Player1Special();
        }
        public void Player1SetUpBomb()
        {
            this.controller.Player1SetUpBomb();
        }

        public void MovePlayer2Up()
        {
            this.controller.MovePlayer2Up();
        }
        public void MovePlayer2Down()
        {
            this.controller.MovePlayer2Down();
        }
        public void MovePlayer2Left()
        {
            this.controller.MovePlayer2Left();
        }
        public void MovePlayer2Right()
        {
            this.controller.MovePlayer2Right();
        }

        public void Player2Special()
        {
            this.controller.Player2Special();
        }
        public void Player2SetUpBomb()
        {
            this.controller.Player2SetUpBomb();
        }
    }

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
    }
    
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

    /// <summary>
    /// This is a wrapper allowing SelectPlayerForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class SelectPlayerFormControllerWrapper : ControllerWrapper
    {
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

    /// <summary>
    /// This is a wrapper allowing WelcomForm to perform
    /// only special subset of actions on controller.
    /// </summary>
    public class WelcomeFormControllerWrapper : ControllerWrapper
    {
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
    
    /// <summary>
    /// Controller class represents a module, that sets up other modules
    /// and performs actions on state machine.
    /// </summary>
    public class Controller
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
        private void NewGame()
        {
            stateMachine.CreateGame();              // init machine to a new game

            /* Engine does not have any rights to change anything in
             * map; though, it takes a map wrapper, that restricts 
             * engine rights to reading from the map. 
             */
            graphicsEngine.SetMapWrapper(stateMachine.GetWrapper());
        }
    }
}
