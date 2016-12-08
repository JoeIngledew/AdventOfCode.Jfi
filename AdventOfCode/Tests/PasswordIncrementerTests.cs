namespace AdventOfCode.Tests
{
    using System.CodeDom.Compiler;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PasswordIncrementerTests
    {
        [TestMethod]
        public void Test1()
        {
            var input = "abcdefgh";

            var pi = new PasswordIncrementer();

            Assert.AreEqual("abcdffaa", pi.GetNextValidPassword(input));
        }

        [TestMethod]
        public void Test2()
        {
            var input = "ghijklmn";

            var pi = new PasswordIncrementer();

            Assert.AreEqual("ghjaabcc", pi.GetNextValidPassword(input));
        }

        [TestMethod]
        public void RuleTest1()
        {
            var pi = new PasswordIncrementer();
            Assert.IsTrue(pi.CheckRule1("ghjaabcc"));
        }

        [TestMethod]
        public void RuleTest2()
        {
            var pi = new PasswordIncrementer();
            Assert.IsTrue(pi.CheckRule2("ghjaabcc"));
        }

        [TestMethod]
        public void RuleTest3()
        {
            var pi = new PasswordIncrementer();
            Assert.IsTrue(pi.CheckRule3("ghjaabcc"));
        }

        [TestMethod]
        public void PasswordIncrementerActual()
        {
            var input = "hepxxyzz";

            var pi = new PasswordIncrementer();

            Assert.AreEqual(input, pi.GetNextValidPassword(input));
        }
    }
}