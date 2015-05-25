using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Dealer
    {

        private int _playerNumber;

        private string[] Deck;

        public void NewHand()
        {
           Deck = NewDeck();
        }

        public Dealer(int PlayerNumber)
        {
            
            _playerNumber = PlayerNumber;    
        }

        public string[] DealPlayerHands()
        {
            string[] PlayerHands = new string[_playerNumber];
            int count = 0;

            for (int i = 0; i < _playerNumber; i++)
            {
                
                PlayerHands[i] = string.Format("{0}|{1}", Deck[count++], Deck[count++]);
                
            }


            return PlayerHands;
        }

        public string[] NewDeck()
        {
            string[] NewDeck = new string[52];
            int count = 0;

            foreach (Poker.Suites item in Enum.GetValues(typeof(Poker.Suites)))
            {
                for (int i = 1; i < 14; i++)
                {
                    string Value = string.Empty;

                    NewDeck[count] = string.Format("{0} of {1}", i, item.ToString());

                    count++;

                }
            }

            Random rnd = new Random();
            string[] MyRandomArray = NewDeck.OrderBy(x => rnd.Next()).ToArray();

            return MyRandomArray;
        }



        public CalculatedHand CalculateHands(string[] Hands)
        {
            HandCalculator HC = new HandCalculator(false);
            CalculatedHand[] CalcHands = new CalculatedHand[Hands.Count()];

            for (int i = 0; i < Hands.Count(); i++)
            {
                CalculatedHand CH = HC.CalculateHand(Hands[i]);
                CalcHands[i] = CH;
            }

            CalculatedHand WinningHand = new CalculatedHand();

            int Highest = 0;

            foreach (CalculatedHand item in CalcHands)
            {
                if ((int)item.Rank > Highest)
                { Highest = (int)item.Rank;
                WinningHand = item;
                }
            }

            return WinningHand;
        }
    }
}