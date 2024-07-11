using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card/PlaningCard")]
public class Card : ScriptableObject
{
    //suits: clubs (♣), diamonds ( ), hearts (♥) and spades (♠). IsCard
    
    public enum Suits
    {
        Blank,
        Club,
        Heart,
        Diamond,
        spade
    }

    [SerializeField] private Suits cardSuit;
    [SerializeField] [Range(0, 7)] private byte cardNummber;

    [Space(5)]
    [SerializeField] private GameObject cardLook;

    public Suits CardSuit { get => cardSuit;}
    public byte CardNummber { get => cardNummber;}
    public GameObject CardLook { get => cardLook;}
}
