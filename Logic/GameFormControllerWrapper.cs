using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Logic
{
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

        public bool Tick()
        {
            return this.controller.Tick();
        }
    }
}
