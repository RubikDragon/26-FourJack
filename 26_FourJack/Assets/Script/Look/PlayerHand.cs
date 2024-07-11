using UnityEngine;

namespace BackJackSystem.Look
{
    public class PlayerHand : CardHand
    {
        [SerializeField] private Players onNewCard;

        protected override void Awake()
        {
            onNewCard.OnPlayerDraw += OnNewCard_OnPlayerDraw;
            base.Awake();
        }

        private void OnNewCard_OnPlayerDraw(Card card)
        {
            AddCardToHand(card);
        }
    }
}

