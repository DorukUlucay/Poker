using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Calculator
    {

        public enum HandRanks
        {
            RoyalFlush, 
            StraightFlush, 
            FourOfAKind, 
            FullHouse, 
            Flush, 
            Straight, 
            Three, 
            TwoPair, 
            Pair, 
            HighCard
        }

        public class CalculatedHand
        {
            public HandRanks Rank;
            public int HighCard;
        }

        //hands are a string array. it'll be json
        public void CalculateHands(string[] Hands)
        {
            foreach (string Hand in Hands)
            {
                CalculateHand(Hand);
            }
        }


        public CalculatedHand CalculateHand(string Hand)
        {
            string[] Cards =  Split(Hand, 2).ToArray();

            bool flush = isFlush(Cards);

            int[] nums = new int[5];

            for (int i = 0; i < 5; i++)
            {
                string Number = Cards[i][1].ToString();

                int val = 0;

                if (!int.TryParse(Number, out val))
                {
                    switch (Number)
                    {
                        case "A": val = 14; break;
                        case "K": val = 13; break;
                        case "Q": val = 12; break;
                        case "J": val = 11; break;
                    }
                }
                nums[i] = val == 0 ? 10 : val;
            }

            Array.Sort(nums);

            bool Straight = isStraight(nums);
            int HighCard = nums[4];

            CalculatedHand CH = new CalculatedHand();
            CH.HighCard = HighCard;

            if (flush & Straight)
            {
                if (HighCard == 14)
                {
                    CH.Rank = HandRanks.RoyalFlush;    
                }
                else
                {
                    CH.Rank = HandRanks.StraightFlush;
                }
            }
            else if (isFourOfAKind(nums))
            {
                CH.Rank = HandRanks.FourOfAKind;
            }
            else if (isFullHouse(nums))
            {
                CH.Rank = HandRanks.FullHouse;
            }
            else if (flush)
            {
                CH.Rank = HandRanks.Flush;
            }
            else if (Straight)
            {
                CH.Rank = HandRanks.Straight;
            }
            else if (isThreeOfAKind(nums))
            {
                CH.Rank = HandRanks.Three;
            }
            else if (isTwoPair(nums))
            {
                CH.Rank = HandRanks.TwoPair;
            }
            else if (IsPair(nums))
            {
                CH.Rank = HandRanks.Pair;
            }
            else
            {
                CH.Rank = HandRanks.HighCard;
            }

            return CH;
        }



        public bool isFlush(string[] Cards)
        {
            char suite = 'N';
            bool isFlush = true;

            suite = Cards[0][0];

            foreach (string card in Cards)
            {
                if (suite != card[0])
                {
                    isFlush = false;
                }
            }

            return isFlush;
        }


        public bool isStraight(int[] sorted)
        {
            if (sorted[4]-1 == sorted[3]
                && sorted[3] - 1 == sorted[2]
                && sorted[2] - 1 == sorted[1]
                && sorted[1] - 1 == sorted[0]
                )
            {
                return true;
            }
            return false;
        }

        public bool isFourOfAKind(int[] sorted)
        {
            var x = sorted.GroupBy(o => o);

            if (x.Count() == 2)
            {
                if (x.ElementAt(0).Count() == 4 || x.ElementAt(1).Count() == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public bool isFullHouse(int[] sorted)
        {
            var x = sorted.GroupBy(o => o);

            if (x.Count() == 2)
            {
                if (x.ElementAt(0).Count() == 2 || x.ElementAt(0).Count() == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool isThreeOfAKind(int[] sorted)
        {
            var x = sorted.GroupBy(o => o);

            if (x.Count() == 3)
            {
                if (x.ElementAt(0).Count() == 3 || x.ElementAt(1).Count() == 3 || x.ElementAt(2).Count() == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool isTwoPair(int[] sorted)
        {
            var x = sorted.GroupBy(o => o);

            if (x.Count() == 3)
            {
                if (x.ElementAt(0).Count() == 2 && x.ElementAt(1).Count() == 2 
                    ||
                    x.ElementAt(1).Count() == 2 && x.ElementAt(2).Count() == 2
                    ||
                    x.ElementAt(2).Count() == 2 && x.ElementAt(0).Count() == 2 

                    ){

                        return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool IsPair(int[] sorted)
        {
            var x = sorted.GroupBy(o => o);

            if (x.Count() == 4)
            {
                if (x.ElementAt(0).Count() == 2 || x.ElementAt(1).Count() == 2 || x.ElementAt(2).Count() == 2 || x.ElementAt(3).Count() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}