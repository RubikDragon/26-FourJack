using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private bool isPlayer;

    private Card[] cardsIndHand;

    // returns the playres hand point
    public ushort GetPlayerScore()
    {
        ushort totalScore = 0;

        foreach (Card cardvalue in cardsIndHand)
        {
            totalScore += cardvalue.GetCardInfo().Nummber;
        }
            
        return totalScore;
    }

    // returns if the player is "Player"
    public bool GetIfIsPlayer()
    {
        return isPlayer;
    }
}
