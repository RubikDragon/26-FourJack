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
        handOfCards.Add(DeckHandler.DrawCard());
    }
}
