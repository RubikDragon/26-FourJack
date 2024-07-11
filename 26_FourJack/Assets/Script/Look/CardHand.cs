using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BackJackSystem.Look
{
    public abstract class CardHand : MonoBehaviour
    {
        [Header("Incresing inkrements")]
        [SerializeField] private Vector3 distansIncres;

        private Vector3 newCardLocason;
        private List<GameObject> cardsIndHand;

        [Header("EventRefendse")]
        [SerializeField] private GameHander onRoundEnd;

        protected virtual void Awake()
        {
            newCardLocason = transform.position;

            cardsIndHand = new List<GameObject>();

            onRoundEnd.OnRoundEnd += OnRoundEnd_OnRoundEnd;
        }

        private void OnRoundEnd_OnRoundEnd()
        {
            RemoveCards();
        }

        protected void AddCardToHand(Card card)
        {

            // contanes a way to routate the 
            // https://docs.unity3d.com/Manual/InstantiatingPrefabs.html

            /*        float angle = i * Mathf.PI * 2 / numberOfObjects;
                    float x = Mathf.Cos(angle) * radius;
                    float z = Mathf.Sin(angle) * radius;
                    Vector3 pos = transform.position + new Vector3(x, 0, z);
                    float angleDegrees = -angle * Mathf.Rad2Deg;
                    Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
                    Instantiate(prefab, pos, rot);*/

            // Quaternion.Euler(0, 0, 0)
            //Debug.Log($"new card postion is {newCardLocason}  made from {transform.position}+{distansIncres}");
            GameObject cardMade = Instantiate(card.CardLook, newCardLocason, transform.rotation, transform);
            cardMade.transform.localScale = new Vector3(3, 3, 3);

            newCardLocason += distansIncres;

            // saves the card ind the a list four latter
            cardsIndHand.Add(cardMade);
        }

        /// <summary>
        /// Reasets the look of the hand
        /// </summary>
        private void RemoveCards()
        {
            foreach (GameObject card in cardsIndHand)
            {
                Destroy(card);
            }

            cardsIndHand.Clear();
            //Vector3.zero;
            newCardLocason = transform.position;
        }
    }
}

