using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHander : MonoBehaviour
{
    [SerializeField] private ushort maxScore;

    [SerializeField] private ushort turnAmount;
    [SerializeField] private Card[] cards;

    [SerializeField] private Players[] players;



    public void PlayerAction()
    {

    }


    public void Round()
    {
        for (int turns = 0; turns < turnAmount; turns++)
        {
            // dealer adds card


            foreach (Players action in players)
            {




            }
        }


    }

    private void RoundWinder()
    {
        List<ushort> rank = new List<ushort>();

        foreach (Players player in players)
        {
            // reamber to add the dealeres hand
            if (player.GetPlayerScore() < maxScore)
                rank.Add(player.GetPlayerScore());
        }
    }
}
