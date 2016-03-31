using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RegexTests
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void TestInputRegex()
        {
            string inputText = "[6]";
            var converter = new CardProbabilityCalculator.TextConverter();

            var result = converter.CreateCardFromLine(inputText);

            Assert.AreEqual("6", result);
        }
    }
}
