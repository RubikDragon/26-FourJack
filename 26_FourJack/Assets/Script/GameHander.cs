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
    private bool roundIsGoving;


    public Action OnRoundEnd;

    // winning or lose
    public Action OnPlayerWin;
    public Action OnPlayerLose;
    

    private void Awake()
    {
        // likes all the playeres with the game
        foreach (Players player in Playeres)
            player.LinkWithGame(this);

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
            if (!roundIsGoving)
            {
                roundIsGoving = true;
                StartCoroutine(Round());
            }
            
            debug++;
            
        }

        // Checks if the player won or not
        if (Playeres[0] is Player)
        {
            OnPlayerWin?.Invoke();
        }
        else
        {
            OnPlayerLose?.Invoke();
        }
    }

    private IEnumerator Round()
    {
        var numbers = cards;
        numbers.Shuffle();

        // starts my making a deck of random cards
        DeckHandler.SetDeck(numbers);

        // contines to go fruge turns ontil turnAmount is reaced
        for (int turns = 0; turns < turnAmount; turns++)
        {
            Debug.Log($"Turn:({turns})");

            // adds card to dealer
            dealer.DrawCard(DeckHandler.DrawCard());

            foreach (Players action in Playeres)
            {
                // calles that that player now has to make a action

                hasDonAction = false;
                action.PlayerAction();


                // waits ontil the player is don with there action before moving on to the next player
                yield return new WaitUntil(() => hasDonAction == true);
                //yield return null;
/*                while (!hasDonAction)
                {
                    yield return null;
                }*/
            }
        }

        

        OnRoundEnd?.Invoke();

        Debug.Log("round has ended");
        roundIsGoving = false;
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
