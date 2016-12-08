namespace AdventOfCode.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HowAboutANiceGameOfChessTests
    {
        [TestMethod]
        public void Test1()
        {
            var cut = new HowAboutANiceGameOfChess();

            var doorId = "abc";

            Assert.AreEqual("18f47a30".ToUpper(), cut.GetPassword(doorId));
        }

        [TestMethod]
        public void Actual()
        {
            var cut = new HowAboutANiceGameOfChess();

            var doorId = "wtnhxymk";

            Assert.AreEqual("18f47a30".ToUpper(), cut.GetPassword(doorId));
        }
    }
}