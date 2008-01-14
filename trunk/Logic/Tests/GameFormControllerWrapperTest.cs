using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    /// <summary>
    /// Game Form Controller Wrapper tests
    /// </summary>
    [TestFixture]
    public class GameFormControllerWrapperTest
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
        public void TestAccessors()
        {
            Assert.IsTrue(this.wrapper.GraphicsEngine == this.wrappedController.GraphicsEngine);
            Assert.IsTrue(this.wrapper.StateMachine == this.wrappedController.StateMachine); 
        }

        /* since there is no way to create exact same state machines 
           thus there are no more tests */
    }
}
