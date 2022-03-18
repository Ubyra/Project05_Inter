using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public CardConfig[] cards;
    public List<CardConfig> deck;

    [ContextMenu("Generate Random Deck")]
    public void RandomizeDeck()
    {
        deck.Clear();

        int randomNumber = (int)Random.Range(0, cards.Length);
        List<int> numberAlreadySorted = new List<int>();

        while(numberAlreadySorted.Count != cards.Length)
        {
            if(!ExistNumberInArray(randomNumber, numberAlreadySorted))
            {
                numberAlreadySorted.Add(randomNumber);
                deck.Add(cards[randomNumber]);
            }
            else
                randomNumber = (int)Random.Range(0, cards.Length);
        }
    }

    public bool ExistNumberInArray(int number, List<int> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            if(number == array[i])
            {
                return true;
            }
        }

        return false;
    }

}
