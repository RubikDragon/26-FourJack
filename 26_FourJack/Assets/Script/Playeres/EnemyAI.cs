using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : Players
{
    public override void PlayerAction()
    {
        NormalEnemyAI();


        base.PlayerAction();
    }

    private void NormalEnemyAI()
    {
        Card newCard = DeckHandler.DrawCard();

        handOfCards.Add(newCard);
        Debug.Log($"Enemy drew card{newCard}");
    }
}
