using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int quantity = 3;
            string name = "TESTCARD";
            string inputString = "x3 TESTCARD";

            var parser = new CardProbabilityCalculator.CardParser();
        }
    }
}
