using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BackJackSystem
{

    public class GameHandler : MonoBehaviour
    {
        private enum GameState
        {
            GameBegin,
            RoundBegin,
            Round,
            AwaitingAction,
            DonAction,
            RoundEnd,
            GameOver
        }

        //​​ btw you can disable the heart on top of the first comment if you press on the three dots at the top of the chat

        #region Values
        private GameState gameState;

        // the amount score cards are not alowed to go over and need to get close to
        [SerializeField] private ushort maxScore;

        [SerializeField] private byte StartingHealt;
        [SerializeField] private ushort turnAmount;

        [Header("Deck of cards")]
        [SerializeField] private Card[] cards;

        // playeres
        [SerializeField] private Dealer dealer;
        [SerializeField] private List<Players> inGamePlayers = new List<Players>();


        private bool RoundHasBeanStoped;

        // events
        public event Action OnRoundEnd;
        public event Action OnPlayerRoundWin;
        public event Action OnPlayerRoundLose;
        #endregion

        private void Awake()
        {
            ChipHandler.SetMaxChips(10);
            gameState = GameState.GameBegin;

            // likes all the playeres with the game
            foreach (Players player in inGamePlayers)
                player.GameSetUp(this, StartingHealt);

            ChipHandler.OnRaise += ChipHandler_OnChipAdded;

            GameIsOn();
        }

        private void ChipHandler_OnChipAdded(Players raiser, byte raisAmount)
        {
            BidRaised(raiser, raisAmount);
        }

        private void GameIsOn()
        {
            if (inGamePlayers.Count >= 1 && gameState == GameState.RoundEnd || gameState == GameState.GameBegin)
            {
                gameState = GameState.RoundBegin;
                StartCoroutine(Round());
            }

            // Checks if the player won or not
            if (inGamePlayers[0] is Player)
            {
                OnPlayerRoundWin?.Invoke();
            }
            else
            {
                OnPlayerRoundLose?.Invoke();
            }
        }

        private IEnumerator Round()
        {
            // starts my making a deck of random cards
            var numbers = cards;
            numbers.Shuffle();            
            DeckHandler.SetDeck(numbers);

            // contines to go fruge turns ontil turnAmount is reaced
            for (int turns = 0; turns < turnAmount; turns++)
            {
                Debug.Log($"Turn:({turns})");
                dealer.DealerGetCard();

                // goes fruge ithe og the playeres turns
                foreach (Players action in inGamePlayers)
                {
                    // calles that that player now has to make a action
                    gameState = GameState.AwaitingAction;
                    action.PlayerAction();

                    yield return new WaitUntil(() => gameState == GameState.DonAction);
                }

                if (RoundHasBeanStoped)
                    break;
            }

            yield return new WaitForSeconds(3);

            Debug.Log("round has ended");
            gameState = GameState.RoundEnd;
            OnRoundEnd?.Invoke();

            // if the game was not forsed ended
            if (!RoundHasBeanStoped)
            {
                RoundWinder();
                GameIsOn();
            }

        }

        /// <summary>
        /// Makes sure the playes mathes the raised amount. 
        /// if there don,t then the round stops and there take the damage
        /// </summary>
        /// <param name="raiser"></param>
        /// <param name="raisAmount"></param>
        private void BidRaised(Players raiser, byte raisAmount)
        {
            bool hasMathedChips = true;

            foreach (Players player in inGamePlayers)
            {
                Debug.Log($"{player.name} the one who raised {raiser.name}");

                // egnores the playere as there have allrede paid by raising
                if (player != raiser)
                {
                    hasMathedChips = player.MathChipRaise(raisAmount);
                }

                // if a player refuses to pay then the round ends and there take damage
                if (!hasMathedChips)
                {
                    Debug.Log($"{player.name} refused to pay");

                    // stops and starts a new round
                    RoundHasBeanStoped = true;
                    HasDonAction();
                    RoundHasBeanStoped = false;
                    DamagePlayer(player);
                    GameIsOn();

                    break;
                }
            }
        }

        private void RoundWinder()
        {
            List<Players> rank = new List<Players>(inGamePlayers);
            List<Players> overMax = new List<Players>();

            foreach (Players player in inGamePlayers)
            {
                if (maxScore < player.GetPlayerScore() + dealer.GetDealerScore())
                {
                    overMax.Add(player);
                }
            }

            // indsures that if a player has over the maxScore then there the one to take damage
            if (overMax.Count > 0)
            {
                int ranToTakeDamge = Random.Range(0, overMax.Count);
                DamagePlayer(overMax[ranToTakeDamge]);
            }
            else
            {
                // sorts the playeres by score. (lowest to highst)
                CustumSord sort = new CustumSord();
                rank.Sort(sort);

                // damages the player with the smallest score and if there belove 0 then remove them from the list
                DamagePlayer(rank[0]);
            }
        }

        private void DamagePlayer(Players player)
        {
            player.DamagePlayer(ChipHandler.TotalChips);
            if (player.Healt <= 0)
                inGamePlayers.Remove(player);
        }

        public void HasDonAction()
        {
            gameState = GameState.DonAction;
        }
    }

    class CustumSord : IComparer<Players>
    {
        public int Compare(Players x, Players y)
        {

            if (x.GetPlayerScore() == 0 || y.GetPlayerScore() == 0)
            {
                return 0;
            }

            // CompareTo() method 
            return x.GetPlayerScore().CompareTo(y.GetPlayerScore());

        }
    }
}
