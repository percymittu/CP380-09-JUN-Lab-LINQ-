using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenfordLab;

namespace TestFirstDigit
{
    [TestClass]
    public class TestFirstDigit
    {
        [DataTestMethod]
        [DataRow(5, 5)]
        [DataRow(10, 1)]
        [DataRow(98765, 9)]
        public void TestFirstDigitIsAsExpected(int input, int expected)
        {
            var result = FirstDigit.getFirstDigit(input);
            Assert.AreEqual(expected, result);
        }
    }
}
