using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{ 
    private bool hasDrawenBlank;
    [SerializeField] private Card blankCard; 

    public Action<Card> OnDealerDraw;

    private List<Card> dealerCards = new List<Card>();

    public void DrawCard(Card card)
    {
        if (!hasDrawenBlank)
        {
            hasDrawenBlank = true;
            card = blankCard;

        }

        dealerCards.Add(card);
        OnDealerDraw?.Invoke(card);

    }
}