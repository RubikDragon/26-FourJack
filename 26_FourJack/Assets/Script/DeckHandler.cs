using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeckHandler
{
    // the current deck
    private static Stack<Card> deck;

    public static Action OnCardDraw;

    public static void SetDeck(Card[] cards)
    {
        deck = new Stack<Card>(cards);

        // debug shows that deck is random
        foreach (Card iss in deck)
        {
            Debug.Log(iss);
        }
    }

    public static Card PeekTopCard()
    {
        return deck.Peek();
    }

    // somone draws a card
    public static Card DrawCard()
    {
        OnCardDraw?.Invoke();
        return deck.Pop();
    }



}
