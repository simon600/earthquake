using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TheEarthQuake.Maps.Tests
{
    /// <summary>
    /// MapWrapper tests
    /// </summary>
    [TestFixture]
    public class MapWrapperTests
    {
        private Maps.Map map;
        private Maps.MapWrapper wrapper;

        /// <summary>
        /// Setting up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setting up...");
            this.map = new Map();
            this.wrapper = new MapWrapper(this.map);
        }

        /// <summary>
        /// Closing tests.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing down...");
        }

        /// <summary>
        /// Testing whether mapWidth and mapHeight is odd natural number
        /// </summary>
        [Test]
        public void TestAccessors()
        {
            for (int i = 0; i < this.map.MapHeight; i++)
            {
                for (int j = 0; j < this.map.MapWidth; j++)
                {
                    /* we remember, that map.getfield returns a clone */
                    Assert.IsFalse(this.map.GetField(i, j) == this.wrapper.GetField(i, j));
                    Assert.IsTrue(this.map.GetField(i, j).Bonus == this.wrapper.GetField(i, j).Bonus);
                }
            }

            Assert.IsTrue(this.wrapper.BonusSize == this.map.BonusSize);
            Assert.IsTrue(this.wrapper.FieldSize == this.map.FieldSize);
            Assert.IsTrue(this.wrapper.MapHeight == this.map.MapHeight);
            Assert.IsTrue(this.wrapper.MapWidth == this.map.MapWidth);
        }
    }
}
