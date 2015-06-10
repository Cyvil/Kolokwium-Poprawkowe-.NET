using System;

namespace Cards
{
    /// <summary>
    /// DO NOT MODIFY THIS FILE
    /// </summary>
    [Flags]
    public enum CardRank
    {
        Ace = 2<<14,
        King = 2<<13,
        Queen = 2<<12,
        Jack = 2<<11,
        Card10 = 2<<10,
        Card9 = 2 << 9,
        Card8 = 2<<8,
        Card7 = 2<<7,
        Card6 = 2<<6,
        Card5 = 2<<5,
        Card4 = 2<<4,
        Card3 = 2<<3,
        Card2 = 2<<2
    }
}
