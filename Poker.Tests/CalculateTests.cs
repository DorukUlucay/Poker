using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.Tests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void IsFlush_Flush_ReturnTrue()
        {
            Poker.Calculator Calc = new Calculator();

            string[] x = { "S2", "S4", "S6", "SQ", "SJ" };
            bool y = Calc.isFlush(x);

            Assert.AreEqual(true, y);
        }

        [TestMethod]
        public void IsFlush_NotFlush_ReturnFalse()
        {
            Poker.Calculator Calc = new Calculator();

            string[] x = { "S2", "HA", "SQ", "SQ", "SJ" };
            bool y = Calc.isFlush(x);

            Assert.AreEqual(false, y);
        }

        [TestMethod]
        public void IsStraight_Straight_ReturnTrue()
        {
            Poker.Calculator Calc = new Calculator();

            int[] x = { 1, 2, 3, 4, 5 };
            bool y = Calc.isStraight(x);

            Assert.AreEqual(true, y);
        }

        [TestMethod]
        public void IsFullHouse_FullHouse_ReturnTrue()
        {
            Poker.Calculator Calc = new Calculator();

            int[] x = { 2, 3, 2, 2, 3 };
            bool y = Calc.isFullHouse(x);

            Assert.AreEqual(true, y);
        }

        [TestMethod]
        public void IsFullHouse_NotFullHouse_ReturnFalse()
        {
            Poker.Calculator Calc = new Calculator();

            int[] x = { 2, 3, 4, 2, 3 };
            bool y = Calc.isFullHouse(x);

            Assert.AreEqual(false, y);
        }

        [TestMethod]
        public void IsThreeOfAKind_GivenThreeOfAKind_ReturnTrue()
        {
            Poker.Calculator Calc = new Calculator();

            int[] x = { 5, 6, 7, 6, 6 };
            bool y = Calc.isThreeOfAKind(x);

            Assert.AreEqual(true, y);
        }

        [TestMethod]
        public void IsThreeOfAKind_NotGivenThreeOfAKind_ReturnFalse()
        {
            Poker.Calculator Calc = new Calculator();

            int[] x = { 5, 6, 7, 8, 6 };
            bool y = Calc.isThreeOfAKind(x);

            Assert.AreEqual(false, y);
        }

        [TestMethod]
        public void IsPair_GivenPair_ExpectedTrue()
        {
            Poker.Calculator Calc = new Calculator();

            string[] Hands = { "S9S8H7H8CA" };
            Poker.Calculator.CalculatedHand C = Calc.CalculateHand(Hands[0]);

            Assert.AreEqual(Poker.Calculator.HandRanks.Pair, C.Rank);
        }

        [TestMethod]
        public void IsFour_GivenFour_ExpectedTrue()
        {
            Poker.Calculator Calc = new Calculator();

            int[] sorted = { 2, 2, 2, 2, 1 };
            bool result = Calc.isFourOfAKind(sorted);

            Assert.AreEqual(true, result);
        }


        
        [TestMethod]
        public void CalculateHand_GivenRoyalFlush_ExpectedTrue()
        {
            Poker.Calculator Calc = new Calculator();

            string[] Hands = { "HKHQH0HJHA" };
            Poker.Calculator.CalculatedHand C = Calc.CalculateHand(Hands[0]);

            Assert.AreEqual(Poker.Calculator.HandRanks.RoyalFlush, C.Rank);
        }

        [TestMethod]
        public void CalculateHand_Given8HighStraightFlush_Expected8HighStraightFlush()
        {
            Poker.Calculator Calc = new Calculator();

            string[] Hands = { "H7H5H6H8H4" };
            Poker.Calculator.CalculatedHand C = Calc.CalculateHand(Hands[0]);

            Assert.AreEqual(Poker.Calculator.HandRanks.StraightFlush, C.Rank);
            Assert.AreEqual(8, C.HighCard);
        }

        [TestMethod]
        public void CalculateHand_GivenJHigh4OfAKind_ExpectedJHighFourOfAKind()
        {
            Poker.Calculator Calc = new Calculator();

            string[] Hands = { "HJHKSJCJDJ" };
            Poker.Calculator.CalculatedHand C = Calc.CalculateHand(Hands[0]);

            Assert.AreEqual(Poker.Calculator.HandRanks.FourOfAKind, C.Rank);
            Assert.AreEqual(11, C.HighCard);
        }
    }
}