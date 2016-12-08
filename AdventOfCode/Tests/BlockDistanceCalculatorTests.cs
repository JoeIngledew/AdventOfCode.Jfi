namespace AdventOfCode.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BlockDistanceCalculatorTests
    {
        [TestMethod]
        public void TestOne()
        {
            var directions = "R2, L3";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            Assert.AreEqual(5, calc.BlocksFromStart());
        }

        [TestMethod]
        public void TestTwo()
        {
            var directions = "R2, R2, R2";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            Assert.AreEqual(2, calc.BlocksFromStart());
        }

        [TestMethod]
        public void TestTwoPointFive()
        {
            var directions = "R1, R2, L1";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            Assert.AreEqual(4, calc.BlocksFromStart());
        }

        [TestMethod]
        public void TestThree()
        {
            var directions = "R5, L5, R5, R3";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            Assert.AreEqual(12, calc.BlocksFromStart());
        }

        [TestMethod]
        public void Actual()
        {
            var directions = "R1, R1, R3, R1, R1, L2, R5, L2, R5, R1, R4, L2, R3, L3, R4, L5, R4, R4, R1, L5, L4, R5, R3, L1, R4, R3, L2, L1, R3, L4, R3, L2, R5, R190, R3, R5, L5, L1, R54, L3, L4, L1, R4, R1, R3, L1, L1, R2, L2, R2, R5, L3, R4, R76, L3, R4, R191, R5, R5, L5, L4, L5, L3, R1, R3, R2, L2, L2, L4, L5, L4, R5, R4, R4, R2, R3, R4, L3, L2, R5, R3, L2, L1, R2, L3, R2, L1, L1, R1, L3, R5, L5, L1, L2, R5, R3, L3, R3, R5, R2, R5, R5, L5, L5, R2, L3, L5, L2, L1, R2, R2, L2, R2, L3, L2, R3, L5, R4, L4, L5, R3, L4, R1, R3, R2, R4, L2, L3, R2, L5, R5, R4, L2, R4, L1, L3, L1, L3, R1, R2, R1, L5, R5, R3, L3, L3, L2, R4, R2, L5, L1, L1, L5, L4, L1, L1, R1";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            //Assert.AreEqual(12, calc.BlocksFromStart());
            int x = 0;
            int y = 0;

            if (calc.xVisitedTwice.Value < 0) x = 0 - calc.xVisitedTwice.Value;
            else x = calc.xVisitedTwice.Value;

            if (calc.yVisitedTwice.Value < 0) y = 0 - calc.yVisitedTwice.Value;
            else y = calc.yVisitedTwice.Value;

            Assert.AreEqual(0, x + y);
        }

        [TestMethod]
        public void TestFour()
        {
            var directions = "R8, R4, R4, R8";

            var calc = new BlockDistanceCalculator();

            calc.FollowDirections(directions);

            //Assert.AreEqual(12, calc.BlocksFromStart());
            int x = 0;
            int y = 0;

            if (calc.xVisitedTwice.Value < 0) x = 0 - calc.xVisitedTwice.Value;
            else x = calc.xVisitedTwice.Value;

            if (calc.yVisitedTwice.Value < 0) y = 0 - calc.yVisitedTwice.Value;
            else y = calc.yVisitedTwice.Value;

            Assert.AreEqual(4, x + y);
        }
    }
}