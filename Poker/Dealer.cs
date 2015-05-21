using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Dealer
    {
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