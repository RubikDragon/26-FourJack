using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Players : MonoBehaviour
{
    protected List<Card> handOfCards;

    protected GameHander posibolActions;

    public Action<short> OnAddChipL;

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

        posibolActions.HasDonAction();
    }

    public void AddChip(short howMutheToAdd)
    {
        OnAddChipL?.Invoke(howMutheToAdd);
    }

}
