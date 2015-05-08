using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class CalculatedHand
    {
        public HandRanks Rank;
        public int HighCard;
        public int[] Kickers = new int[5];
    }
}
