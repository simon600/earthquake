using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    /// <summary>
    /// Map Select Form Controller tests
    /// </summary>
    [TestFixture]
    public class MapSelecFormControllerWrapperTest
    {
        private MapSelectFormControllerWrapper wrapper;
        private Controller wrappedController;

        [SetUp]
        public void SetUp()
        {
            System.Console.WriteLine("Setting up tests...");
            this.wrappedController = new Controller();
            this.wrapper = new MapSelectFormControllerWrapper(this.wrappedController);
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
            Assert.IsTrue(this.wrapper.gameFormControllerWrapper is GameFormControllerWrapper);
            Assert.IsTrue(this.wrapper.selectPlayerFormControllerWrapper is SelectPlayerFormControllerWrapper);
        }
    }
}
