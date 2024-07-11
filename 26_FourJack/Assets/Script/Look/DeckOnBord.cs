using System.Collections.Generic;
using UnityEngine;

using BackJackSystem;

public class DeckOnBord : MonoBehaviour
{
    #region Values

    private byte cardsRemoved;
    private List<GameObject> cards;

    [SerializeField] Players[] OnCardDrawEvent;
    [SerializeField] GameHandler OnRoundEndEvent;

    #endregion

    #region Methods
    void Awake()
    {
        // deals with the cards ind deck
        cardsRemoved = 0;
        cards = new List<GameObject>();
        foreach (Transform card in transform)
            cards.Add(card.gameObject);

        // linkes all the events
        OnRoundEndEvent.OnRoundEnd += OnRoundEndEvent_OnRoundEnd;
        foreach (Players eventer in OnCardDrawEvent)
            eventer.OnPlayerDraw += Eventer_OnPlayerDraw;       
    }

    private void OnRoundEndEvent_OnRoundEnd()
    {
        ReasetDeck();
    }

    private void Eventer_OnPlayerDraw(Card obj)
    {
        RemoveCard();
    }

    // remove a card from the deck piel
    private void RemoveCard()
    {
        cards[cardsRemoved].SetActive(false);
        cardsRemoved++;
    }

    // sets the cards that are gone to be visebol agien
    private void ReasetDeck()
    {
        
        for (int i = 0; i < cardsRemoved; i++)
        {
            cards[i].SetActive(true); 
        }

        cardsRemoved = 0;
    }
    #endregion
}
