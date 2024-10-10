using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : Players
{
    public override void PlayerAction()
    {
        NormalEnemyAI();
        

        base.PlayerAction();
    }

    private void NormalEnemyAI()
    {
        DrawCard();
        //Random.Range(0, overMax.Count)
    }

    public override bool MathChipRaise(byte chipAmount)
    {
        return base.MathChipRaise(chipAmount);
    }
}
