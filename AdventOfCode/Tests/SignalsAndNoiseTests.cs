namespace AdventOfCode.Tests
{
    using AdventOfCode.Properties;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SignalsAndNoiseTests
    {
        [TestMethod]
        public void Test1()
        {
            var san = new SignalsAndNoise();

            var expected = "advent";

            var actual = san.Decode(Resources.SANTestIn);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SignalsAndNoiseActual()
        {
            var san = new SignalsAndNoise();

            var expected = "easter";

            var actual = san.Decode(Resources.SANActualIn);

            Assert.AreEqual(expected, actual);
        }
    }
}