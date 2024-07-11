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
}