using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    /// <summary>
    /// Welcome Form Controller Wrapper tests 
    /// </summary>
    [TestFixture]
    public class WelcomeFormWrapperTest
    {
        private WelcomeFormControllerWrapper wrapper;
        private Controller wrappedController;

        [SetUp]
        public void SetUp()
        {
            System.Console.WriteLine("Setting up tests...");
            this.wrappedController = new Controller();
            this.wrapper = new WelcomeFormControllerWrapper(this.wrappedController);
        }

        [TearDown]
        public void TearDown()
        {
            System.Console.WriteLine("Tearing down...");
        }

        [Test]
        public void TestAccessors()
        {
            Assert.IsTrue(this.wrapper.GraphicsEngine == this.wrappedController.GraphicsEngine);
            Assert.IsTrue(this.wrapper.StateMachine == this.wrappedController.StateMachine);
            Assert.IsTrue(this.wrapper.GameOptionsFormControllerWrapper is GameOptionsFormControllerWrapper);
            Assert.IsTrue(this.wrapper.SelectPlayersFormControllerWrapper is SelectPlayerFormControllerWrapper);
        }
    }
}
