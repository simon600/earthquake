using System;
using NUnit.Framework;

namespace TheEarthQuake.Maps.Tests
{
    /// <summary>
    /// Map tests
    /// </summary>
    [TestFixture]
    public class MapTests
    {
        private Map map;

        /// <summary>
        /// Setting up tests.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setting up...");
            this.map = new Map();
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
        public void TestHeightWidth()
        {
            Console.WriteLine("Test if map width and height is odd positive number");
            bool result;

            if(map.MapWidth > 0 && map.MapWidth % 2 == 1 && map.MapHeight > 0 && map.MapHeight % 2 == 1)
                result = true;
            else
                result = false;

            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Testing if field size is positive number.
        /// </summary>
        [Test]
        public void TestFieldSize()
        {
            Console.WriteLine("Test if field size is positive number");
            bool result;

            if (map.FieldSize > 0.0)
                result = true;
            else
                result = false;

            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// Testing whether each field was initialized properly.
        /// </summary>
        [Test]
        public void TestFieldsNotNull()
        {
            Console.WriteLine("Test if map field was initialized properly");

            Field[,] fields = map.Fields;
            bool result = true;

            for (int i = 0; i < map.MapHeight; i++)
            {
                for (int j = 0; j < map.MapWidth; j++)
                {
                    if (fields[i, j] == null)
                        result = false;
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public void TestGetBonusForPlayer()
        {
            Console.WriteLine("Test if function GetBonusForPlayer works properly");
            Field field = map.Fields[0,0];

            field.Bonus = new Bonuses.SampleBonus();

            Bonuses.Bonus bonus = map.GetBonusForPlayer(0, 0);

            Assert.IsNotNull(bonus);            
        }
    }
}
