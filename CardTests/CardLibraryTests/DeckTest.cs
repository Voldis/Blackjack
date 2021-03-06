﻿using AutoFixture.Xunit2;
using CardLibrary;
using CardLibrary.Cards;
using FluentAssertions;
using System;
using System.Linq;
using MoreLinq;
using Xunit;
using System.Collections.Generic;

namespace CardTests.CardLibraryTest
{
    public class DeckTest
    {
        private const int STANDARD_DECK_COUNT = 52;

        [Fact]
        public void Deck_Build_52Cards()
        {
            Deck.Standard52CardDeck().Cards
                .Should().HaveCount(STANDARD_DECK_COUNT)
                .And.BeInAscendingOrder(x => x.Value)
                .And.OnlyHaveUniqueItems();
        }

        [Fact]
        public void Deck_Creation_IsEmpty()
        {
            Deck deak = new Deck();
            deak.Should().NotBeNull();
            deak.Count.Should().Be(0, "Deck is empty.");
        }

        [Fact]
        public void Deck_Add_SingleCardSuccefully()
        {
            Deck sut = Deck.EmptyDeck();
            sut = sut.Add(Card.AceOfClubs);
            sut.Cards.Should().Contain(Card.AceOfClubs);
        }

        [Fact]
        public void Deck_Add_RangeOfCards()
        {
            Deck sut = Deck.EmptyDeck();
            sut = sut.Add(new List<Card>() 
            { 
                Card.AceOfClubs, 
                Card.AceOfDiamonds 
            });
            sut.Cards.Should()
                .Contain(Card.AceOfClubs).And
                .Contain(Card.AceOfDiamonds);
        }

        [Fact]
        public void Deck_Pop_RemoveLastElement()
        {
            var sut = Deck.Standard52CardDeck();
            var originalDeck = sut.Cards;
            var deck = sut.Pop(out Card card);

            card.Should().Be(originalDeck.Last());
            deck.Cards.Should()
                .NotContain(card).And
                .HaveCount(originalDeck.Count - 1);
        }

        [Theory, AutoData]
        public void Deck_Pop_ThrowsIfDeckIsEmpty(Deck sut)
        {
            Assert.Throws<InvalidOperationException>(() => sut.Pop(out Card card));
        }

        [Fact]
        public void Deck_Shuffle_Equivalency()
        {
            var deck = Deck.Standard52CardDeck();
            var cards = deck.Cards;
            var shuffledCards = deck.Shuffle().Cards;

            shuffledCards
                .Should().HaveCount(STANDARD_DECK_COUNT)
                .And.BeEquivalentTo(cards)
                .And.OnlyHaveUniqueItems();
        }
    }
}