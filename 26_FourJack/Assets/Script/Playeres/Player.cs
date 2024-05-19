using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Players
{
    [SerializeField] private GameObject ActionUI;

    [SerializeField] private bool isPlayer;

    // events
    public Action<Card> OnPlayerDraw;
    public Action OnPlayerAction;

    // returns if the player is "Player"
    public bool GetIfIsPlayer()
    {
        return isPlayer;
    }

    public override void PlayerAction()
    {
        ActionUI.SetActive(true);
    }

    // called by button
    #region

    public void PlayerDrawCard()
    {
        Card newCard = DeckHandler.DrawCard();

        handOfCards.Add(newCard);
        Debug.Log($"Player drew card{newCard}");
    }

    // ís called by a button when the player has don a atcion
    public void EndPlayerAction()
    {
        Debug.Log("the Player has ended there turn");

        ActionUI.SetActive(false);
        posibolActions.HasDonAction();
    }

    #endregion
}
