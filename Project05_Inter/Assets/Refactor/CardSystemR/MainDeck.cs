using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDeck : MonoBehaviour
{
    [Header("Deck Essentials")]
    public CardConfig[] cards;
    public List<CardConfig> deck;

    [Header("External Scripts")]
    public MatchSystemR Match;
    public PlayerHand Hand;
    public Collider deckCollider;
    public bool IsMouseColliding => MouseSelector.HitCollider() == deckCollider;

    private void Start()
    {
        RandomizeDeck();
    }

    private void Update()
    {
        if(IsMouseColliding && Input.GetMouseButtonDown(0))
        {
            Match.DrawCard();
        }
    }

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

    public void DrawCard()
    {
        Hand.DrawCard(Hand.CurrentCardsInHand);
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

    public CardConfig NextCardToDraw()
    {
        var cardDrawed = deck[0];
        deck.Remove(deck[0]);

        return cardDrawed;
    }

}
