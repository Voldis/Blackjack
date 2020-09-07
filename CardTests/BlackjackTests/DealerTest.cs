﻿using Xunit;
using Blackjack;
using FluentAssertions;
namespace CardTests.BlackjackTests
{
    public class DealerTest
    {
        [Fact]
        public void Dealer_Deck_IsCreated()
        {
            Dealer dealer = new Dealer();
            dealer.Deck.Count.Should().Be(52);
        }
    }
}