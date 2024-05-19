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

    [System.Serializable]
    public struct CardInfo
    {
        public Suits suits;
        [Range(1, 7)] public ushort Nummber;
    }

    public CardInfo IsCard;

    public CardInfo GetCardInfo()
    {
        return IsCard;
    }
}
