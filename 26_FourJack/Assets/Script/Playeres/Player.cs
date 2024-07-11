using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BackJackSystem;

public class Player : Players
{
    [SerializeField] private GameObject ActionUI;

    private bool actionChosen;
    private bool isPayingRaise;

    // events   
    public event Action OnPlayerAction;

    public override void PlayerAction()
    {
        ActionUI.SetActive(true);
    }

    public override bool MathChipRaise(byte chipAmount)
    {
        // indsures the game waits ontil the player has made there chose of where or not to pay the raise amount
        StartCoroutine(WaitFourPlayerChose());

        if (isPayingRaise)
            ChipHandler.AddChips(chipAmount);

        return isPayingRaise;
    }


    // waits ontil the player has made a choise
    private IEnumerator WaitFourPlayerChose()
    {
        yield return new WaitUntil(() => actionChosen == true);
        actionChosen = false;
    }
    // confurms the player choise
    public void ActionChosen(bool chosen)
    {
        isPayingRaise = chosen;
        actionChosen = true;
    }

    // called by button
    #region


    public void PlayerDrawCard()
    {
        DrawCard();
    }

    // ís called by a button when the player has don a atcion
    public void EndPlayerAction()
    {
        ActionUI.SetActive(false);
        posibolActions.HasDonAction();
    }

    #endregion
}
