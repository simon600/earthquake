using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    [TestFixture]
    class StateTest
    {
        private GameFormControllerWrapper wrapper;
        private Controller wrappedController;

        [SetUp]
        public void SetUp()
        {
            System.Console.WriteLine("Setting up tests...");
            this.wrappedController = new Controller();
            this.wrapper = new GameFormControllerWrapper(this.wrappedController);
        }

        [TearDown]
        public void TearDown()
        {
            System.Console.WriteLine("Tearing down...");
        }

        [Test]
        public void TestStates()
        {
            /*GameState gameState = new GameState();
            MainMenuState mainMenuState = new MainMenuState();
            StartMenu startMenu = new StartMenu();*/
        }
    }
}
