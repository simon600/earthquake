using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    /// <summary>
    /// Controller tests
    /// </summary>

    [TestFixture]
    public class ControllerTest
    {

        [SetUp]
        public void SetUp()
        { }

        [Test]
        public void TestController()
        {
            Controller testedController = new Controller();
            Assert.IsTrue(testedController.GraphicsEngine != 
                new Controller().GraphicsEngine);

            Assert.IsTrue(testedController.StateMachine  != 
                new Controller().StateMachine );
        }
    }
}
