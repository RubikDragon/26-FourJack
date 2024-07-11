using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackJackSystem;

public abstract class Players : MonoBehaviour
{

    [SerializeField] private byte healt;

    protected List<Card> handOfCards;

    protected GameHander posibolActions;

    public byte Healt { get => healt;}

    // actions
    public event Action<Card> OnPlayerDraw;
    public event Action<int> OnAddChip;
    public event Action<byte> OnDamge;

    private void Awake()
    {
        handOfCards = new List<Card>();       
    }

    // sets up valide informason
    public void GameSetUp(GameHander link, byte SetHealt)
    {
        posibolActions = link;
        healt = SetHealt;
        OnDamge?.Invoke(healt);
    }

    public virtual void PlayerAction()
    {
        Debug.Log($"{this.name} has ended there turn");
        posibolActions.HasDonAction();
    }

    protected void DrawCard()
    {
        Card newCard = DeckHandler.DrawCard();

        handOfCards.Add(newCard);
        OnPlayerDraw?.Invoke(newCard);
        Debug.Log($"{this.name} drew card{newCard}");
    }

    public virtual bool MathChipRaise(byte chipAmount)
    {
        bool hasMathChip = true;

        ChipHandler.AddChips(chipAmount);

        return hasMathChip;
    }

    // damges the player
    public void DamagePlayer(byte damge)
    {
        healt -= damge;
        OnDamge?.Invoke(healt);
    }

    // returns the playres hand point
    public ushort GetPlayerScore()
    {
        ushort totalScore = 0;

        foreach (Card cardvalue in handOfCards)
        {
            totalScore += cardvalue.CardNummber;
        }

        return totalScore;
    }

}
