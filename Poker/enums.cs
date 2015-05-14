using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum HandRanks
    {
        RoyalFlush=10,
        StraightFlush=9,
        FourOfAKind=8,
        FullHouse=7,
        Flush=6,
        Straight=5,
        Three=4,
        TwoPair=3,
        Pair=2,
        HighCard=1
    }

    public enum Suites
    { 
        Hearts, 
        Spades, 
        Diamonds, 
        Clubs
    }
}