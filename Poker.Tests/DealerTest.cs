using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void CalculateHands_GivenTwoPairAndFourOfAKind_ExptectedWinnerIsSecondHand()
        {
            Dealer D = new Dealer();
            D.CalculateHands(new string[] { "H2H7D6SJCJ", "HKHJDKSKCK" });

        }
    }
}
