using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Players, IactionAbol
{
    [SerializeField] private GameObject ActionUI;


    [SerializeField] private short healt;
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

        base.PlayerAction();
        throw new NotImplementedException();
    }

    public void Action()
    {

        ActionUI.SetActive(true);

        base.PlayerAction();
        throw new NotImplementedException();
    }

    // ís called by a button when the player has don a atcion
    public void PlayerHasDonAction()
    {
        posibolActions.HasDonAction();
    }


}
