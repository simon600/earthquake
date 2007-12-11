/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;
using NUnit.Framework;

namespace Maps.tests
{
    [TestFixture]
    public class MapTests
    {
        Map testedMap;

        [SetUp]
        public void SetUp()
        {
            testedMap = new Map();
            Console.WriteLine("Setting up...");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing down...");
        }

        [Test]
        public void TestFilledMap()
        {
            Console.WriteLine("Test whether map was fully filled");
            bool result = true;
            Field[,] fields = testedMap.Fields;
            Assert.AreEqual(true, fields != null);

            for(int i = 0; i < Map.MapWidth; i++)
            {
                for (int j = 0; j < Map.MapHeight; j++)
                {
                    if (fields[i, j] == null)
                        result = false;
                }
            }
            Assert.AreEqual(true, result);
        }
    }
}
