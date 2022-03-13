using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_", menuName = "Scriptable Object/Create New Card")]
public class CardConfig : ScriptableObject
{
    [Header("Card Atributtes")]
    public string cardName;
    public string cardDescription;
    public int[] cardValue;
    public string[] cardNaipe;
}
