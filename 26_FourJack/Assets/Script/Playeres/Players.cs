using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Players : MonoBehaviour
{

    [SerializeField] private short healt;

    protected List<Card> handOfCards;

    protected GameHander posibolActions;

    // actions
    public Action<short> OnAddChip;

    private void Awake()
    {
        handOfCards = new List<Card>();
    }

    public void LinkWithGame(GameHander link)
    {
        posibolActions = link;
    }

    // returns the playres hand point
    protected ushort GetPlayerScore()
    {
        ushort totalScore = 0;

        foreach (Card cardvalue in handOfCards)
        {
            totalScore += cardvalue.GetCardInfo().Nummber;
        }

        return totalScore;
    }

    public virtual void PlayerAction()
    {
        Debug.Log("Player has ended there turn");
        posibolActions.HasDonAction();
    }

    public void AddChip(short howMutheToAdd)
    {
        OnAddChip?.Invoke(howMutheToAdd);
    }

}
