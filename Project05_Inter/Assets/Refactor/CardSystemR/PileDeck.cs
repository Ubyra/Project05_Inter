using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileDeck : MonoBehaviour
{
    [Header("Deck Essentials")]
    public List<CardConfig> deck;

    [Header("External Scripts")]
    public MatchSystemR Match;
    public PlayerHand Hand;
    public Collider deckCollider;
    public bool IsMouseColliding => MouseSelector.HitCollider() == deckCollider;

    private void Update()
    {
        if (IsMouseColliding && Input.GetMouseButtonDown(0))
        {
            Match.DrawCard();
            Match.DiscardCard();
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
            if (number == array[i])
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