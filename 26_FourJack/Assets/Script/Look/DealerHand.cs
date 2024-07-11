using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BackJackSystem.Look
{
    public class DealerHand : CardHand
    {
        [SerializeField] private Dealer onCardDraw;

        protected override void Awake()
        {
            onCardDraw.OnDealerDraw += OnCardDraw_OnDealerDraw;
            base.Awake();
        }

        private void OnCardDraw_OnDealerDraw(Card card)
        {
            AddCardToHand(card);
        }
    }
}


