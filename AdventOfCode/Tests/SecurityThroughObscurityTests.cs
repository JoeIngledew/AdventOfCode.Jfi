namespace AdventOfCode.Tests
{
    using System.Text;

    using AdventOfCode.Properties;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SecurityThroughObscurityTests
    {
        [TestMethod]
        public void Test1()
        {
            var sto = new SecurityThroughObscurity();

            var input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var input2 = "a-b-c-d-e-f-g-h-987[abcde]";
            var input3 = "not-a-real-room-404[oarel]";
            var input4 = "totally-real-room-200[decoy]";

            Assert.IsTrue(sto.IsRoomReal(input));

            var sb = new StringBuilder();
            sb.AppendLine(input);
            sb.AppendLine(input2);
            sb.AppendLine(input3);
            sb.AppendLine(input4);

            Assert.AreEqual(1514, sto.GetSumOfValidRoomSectorIds(sb.ToString().Trim()));
        }

        [TestMethod]
        public void Actual()
        {
            var sto = new SecurityThroughObscurity();

            var input = Resources.SecurityThroughObscurityIn;

            Assert.AreEqual(0, sto.GetSumOfValidRoomSectorIds(input));
        }

        [TestMethod]
        public void Test2()
        {
            var sto = new SecurityThroughObscurity();

            var input = "qzmt-zixmtkozy-ivhz-343";

            var actual = sto.GetDecryptedRoomNameAndId(input);

            Assert.AreEqual(343, actual.Value);
            Assert.AreEqual("very encrypted name", actual.Key);
        }
    }
}