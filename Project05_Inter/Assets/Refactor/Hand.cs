using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand : MonoBehaviour
{
    [Header("Main Atributtes")]
    public List<GameObject> CardsInHand;
    public MatchSystem Match;
    public Deck MainDeck;
    public Deck DiscardDeck;
    protected WaitForSeconds WaitTime;

    public virtual IEnumerator FirstDraw()
    {
        yield break;
    }

    public virtual void DrawCard(Deck deck)
    {
    }

    public virtual void DiscardCard(GameObject card, Transform position)
    {
    }

    public virtual void DiscardCard(int cardIndex, Transform position)
    {
    }

    public virtual void DiscardAllHand()
    {
    }

    public virtual void PutCard(GameObject card, CardSpot spot)
    {
    }

    public virtual void PutCard(int cardIndex, CardSpot spot)
    {
    }

    public virtual void SelectCard()
    {
    }
}
