using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Maps.Tests
{
    /// <summary>
    /// NonPersistentWall tests
    /// </summary>
    [TestFixture]
    public class NonPersistentWallTests
    {
        /// <summary>
        /// Test accessors.
        /// </summary>
        [Test]
        public void TestAccessors()
        {
            NonPersistentWall fieldOne = new NonPersistentWall();
            NonPersistentWall fieldTwo = new NonPersistentWall();

            Assert.IsTrue(fieldOne.Bonus == fieldOne.Bonus);
        }
    }
}
