using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Maps.Tests
{
    /// <summary>
    /// PersistentWall tests
    /// </summary>
    [TestFixture]
    public class PersistentWallTests
    {
        /// <summary>
        /// Test accessors.
        /// </summary>
        [Test]
        public void TestAccessors()
        {
            PersistentWall fieldOne = new PersistentWall();
            PersistentWall fieldTwo = new PersistentWall();

            Assert.IsTrue(fieldOne.Bonus == fieldTwo.Bonus);
        }
    }
}
