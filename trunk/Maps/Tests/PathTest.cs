using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Maps.Tests
{
    /// <summary>
    /// Testing Persistent Wall class.
    /// </summary>
    class PathTest
    {
        /// <summary>
        /// Testing accessors of PersistentWall.
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
