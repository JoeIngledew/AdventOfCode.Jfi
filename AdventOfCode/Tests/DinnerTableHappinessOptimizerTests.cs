namespace AdventOfCode.Tests
{
    using AdventOfCode.Properties;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DinnerTableHappinessOptimizerTests
    {
        [TestMethod]
        public void ActualBestHappinessTest()
        {
            var dtho = new DinnerTableHappinessOptimizer();

            var input = Resources.DTHOActualIn;

            var optimal = dtho.GetOptimalDeltaHappiness(input);

            Assert.AreEqual(1, optimal);
        } 
    }
}