using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHander : MonoBehaviour
{
    [SerializeField] private ushort maxScore;

    [SerializeField] private ushort turnAmount;
    [SerializeField] private Card[] cards;

    [SerializeField] private Dealer dealer;
    [SerializeField] private Players[] Playeres;
    [SerializeField] private IactionAbol[] actions;

    private bool hasDonAction;  


    public Action OnRoundEnd;

    // winning or lose
    public Action OnPlayerWin;
    public Action OnPlayerLose;
    

    private void Awake()
    {
        GameIsGoving();
    }


    public void PlayerAction()
    {

    }

    private void GameIsGoving()
    {
        int debug = 0;


        // keeps goving fruge rounds ontil there is only one player left
        while (Playeres.Length > 1 && debug !< 20)
        {
            StartCoroutine(Round());
            debug++;
            
        }
/*
        // Checks if the player won or not
        if (players[0].GetIfIsPlayer() == true)
        {
            OnPlayerWin?.Invoke();
        }
        else
        {
            OnPlayerLose?.Invoke();
        }*/
    }

    private IEnumerator Round()
    {
        Debug.Log("Was don");

        var numbers = cards;
        numbers.Shuffle();

        // starts my making a deck of random cards
        DeckHandler.SetDeck(numbers);

        // contines to go fruge turns ontil turnAmount is reaced
        for (int turns = 0; turns < turnAmount; turns++)
        {
            // adds card to dealer
            dealer.DrawCard(DeckHandler.DrawCard());

            foreach (Players action in Playeres)
            {
                // calles that that player now has to make a action
                action.PlayerAction();
                hasDonAction = false;

                // waits ontil the player is don with there action before moving on to the next player
                yield return new WaitUntil(() => hasDonAction == true);

/*                while (!hasDonAction)
                {
                    yield return null;
                }*/
            }
        }

        OnRoundEnd.Invoke();

        // damage player and if there belove 0 then remove them from the list
    }

    public void HasDonAction()
    {
        hasDonAction = true;
    }

    private void RoundWinder()
    {
        List<ushort> rank = new List<ushort>();

        foreach (Players player in Playeres)
        {

/*            // reamber to add the dealeres hand
            if (player.GetPlayerScore() < maxScore)
                rank.Add(player.GetPlayerScore());*/
        }
    }
}
