using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void CalculateHands_GivenPairAndFourOfAKind_ExptectedWinnerIsSecondHand()
        {
            Dealer D = new Dealer();
            CalculatedHand Winner = D.CalculateHands(new string[] { "H2H7D6SJCJ", "HKHJDKSKCK" });

            Assert.AreEqual(HandRanks.FourOfAKind, Winner.Rank);

        }
    }
}
