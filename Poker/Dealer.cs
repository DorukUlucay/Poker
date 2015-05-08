using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Dealer
    {
        public void CalculateHands(string[] Hands)
        {
            HandCalculator HC = new HandCalculator(false);
            CalculatedHand[] CalcHands = new CalculatedHand[Hands.Count()];

            for (int i = 0; i < Hands.Count(); i++)
            {
                CalculatedHand CH = HC.CalculateHand(Hands[i]);
                CalcHands[i] = CH;
            }
        }
    }
}