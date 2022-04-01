using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : MonoBehaviour
{
    public Transform playerHand;
    public Transform enemyHand;
    public Collider areaCollider;
    public List<GameObject> Card;
    public GameObject TopCard{ get { return Card[0]; } }

    public virtual void FillDeck()
    {
    }

    public virtual void Shuffle()
    {
    }

    public virtual void DrawCard(Transform t)
    {
    }

    public virtual void ReturnCard(GameObject card, Transform position)
    {
    }

    public virtual void ReturnAllDiscardDeck(Deck deck)
    {
    }

    public virtual void AddCard(GameObject card)
    {
    }


    public virtual void UpdateDeckVisuals()
    {
    }
}
