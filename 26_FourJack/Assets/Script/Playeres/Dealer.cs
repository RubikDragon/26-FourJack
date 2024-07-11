using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{ 
    private bool hasDrawenBlank = false;
    [SerializeField] private Card blankCard; 

    public event Action<Card> OnDealerDraw;

    private List<Card> dealerCards = new List<Card>();

    public void DealerGetCard()
    {
        Card card = DeckHandler.DrawCard();

        if (!hasDrawenBlank)
        {
            hasDrawenBlank = true;
            card = blankCard;

        }

        dealerCards.Add(card);
        OnDealerDraw?.Invoke(card);
    }

    // returns the playres hand point
    public ushort GetDealerScore()
    {
        ushort totalScore = 0;

        foreach (Card cardvalue in dealerCards)
        {
            totalScore += cardvalue.CardNummber;
        }

        return totalScore;
    }
}