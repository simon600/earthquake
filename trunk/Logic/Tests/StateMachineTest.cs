using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Logic.Tests
{
    /// <summary>
    /// State machine tests
    /// </summary>
    [TestFixture]
    public class StateMachineTest
    {
        private StateMachine stateMachine;

        [SetUp]
        public void SetUp()
        {
            System.Console.WriteLine("Setting up tests...");
            this.stateMachine = new StateMachine();
        }

        [TearDown]
        public void TearDown()
        {
            System.Console.WriteLine("Tearing down...");
        }

        [Test]
        public void TestMachine()
        {
            /* well, nothing to test? */
        }
    }
}
