﻿using CardLibrary;
using CardLibrary.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

/*
Game play:
    1) Player is dealt two cards.
        a) Face up or down depending.
        b) Dealer also dealt two cards.
            i) One exposed one hidden.
            ii) Or one card exposed.
    2) Once player hand is completed it is the dealers turn.
        a) Skiped if player is busted or blackjack.
        b) Reveals hidden card.
        c) Hit until soft 17.
    3) You are betting that you are closer to 21 than the dealer without exceding 21.

    Win/loss conditions:
    1) If the player exceeds a sum of 21 ("busts"),
        the player loses, even if the dealer also exceeds 21.
    2) If the dealer exceeds 21 ("busts") and the player does not, the player wins.
    3) If the player attains a final sum higher than the dealer
        and does not bust, the player wins.
    4) If both dealer and player receive a blackjack 
        or any other hands with the same sum called a "push", no one wins.

    Aces:
    1) Ace card is one or eleven.
        a) 'Soft' if a hand with a ace as an 11.
        b) Otherwise called 'hard'.

*/
namespace BlackjackLibrary
{
    public sealed class Blackjack
    {
        public Blackjack()
        {
            Dealer = new Participant(Deck.Standard52CardDeck().Shuffle());
            Player = new Participant();
        }

        private Participant Dealer { get; init; }
        private Participant Player { get; init; }

        public void StartGame()
        {
            // Player is dealt two cards.


            bool gameLoopFlag = false;
            do
            {

                if (Console.ReadKey().KeyChar == 'q')
                {
                    gameLoopFlag = true;
                }
            } while (gameLoopFlag);
        }

        private IEnumerable<Card> Deal(Participant deck, int amount)
        {
            var cards = deck.Remove(amount);
            return cards;
        }
    }
}