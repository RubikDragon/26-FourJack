using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeckHandler
{
    // the current deck
    private static Stack<Card> deck;

    public static void SetDeck(Card[] cards)
    {
        string cardOrder = "";

        deck = new Stack<Card>(cards);

        // debug shows that deck is random
        foreach (Card iss in deck)
        {
            cardOrder += $"[{iss}],";
        }

        Debug.Log(cardOrder);
    }

    public static Card PeekTopCard()
    {
        return deck.Peek();
    }

    // somone draws a card
    public static Card DrawCard()
    {
        return deck.Pop();        
    }
}
