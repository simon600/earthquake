using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Engine;

/*
  TODO: w kontrolerze nalezy napisac obsluge wejscia!
 
 */

namespace TheEarthQuake.Logic
{
    class Controller
    {
        private Engine.Engine graphicsEngine;
        private StateMachine stateMachine;

        public Controller()
        {
            stateMachine = new StateMachine();
            graphicsEngine = new Engine.Engine();

            NewGame();
        }

        private void NewGame()
        {
            stateMachine.CreateGame();
            graphicsEngine.SetWrapper(stateMachine.GetWrapper());
        }
    }
}
