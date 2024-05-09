using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/PlaningCard")]
public class Card : ScriptableObject
{
    //suits: clubs (♣), diamonds ( ), hearts (♥) and spades (♠). IsCard
    public enum Suits
    {
        Club,
        Heart,
        Diamond,
        spade
    }

    public struct CardInfo
    {
        public Suits suits;
        public ushort Nummber;
    }

    [SerializeField] public CardInfo IsCard;

    public CardInfo GetCardInfo()
    {
        return IsCard;
    }
}
