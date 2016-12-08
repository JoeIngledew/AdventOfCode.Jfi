namespace AdventOfCode.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LookAndSayTests
    {
        [TestMethod]
        public void LookAndSayActual()
        {
            var las = new LookAndSay();

            var output = las.RunLookAndSayOnRepeat("3113322113", 50);

            Assert.AreEqual(10, output.Length);
        }
    }
}