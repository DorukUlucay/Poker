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
            Dealer D = new Dealer(2);
            CalculatedHand Winner = D.CalculateHands(new string[] { "H2H7D6SJCJ", "HKHJDKSKCK" });

            Assert.AreEqual(HandRanks.FourOfAKind, Winner.Rank);

        }


        [TestMethod]
        public void DealPlayerHands_DealHandsForThreePlayers_ExpectThreeHands()
        {
            Dealer D = new Dealer(3);
            
            D.NewHand();
            string[] Hands = D.DealPlayerHands();

            Assert.AreEqual(3, Hands.Length);
        }
    }
}
