﻿using Ardalis.SmartEnum;

namespace CardLibrary.Cards
{
    public sealed class Suit : SmartEnum<Suit>
    {
        public static readonly Suit Spades = new Suit(nameof(Spades), 1);
        public static readonly Suit Hearts = new Suit(nameof(Hearts), 2);
        public static readonly Suit Diamonds = new Suit(nameof(Diamonds), 3);
        public static readonly Suit Clubs = new Suit(nameof(Clubs), 4);

        private Suit(string name, int value) : base(name, value) { }
    }
}
