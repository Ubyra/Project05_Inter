using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : MonoBehaviour
{
    public List<GameObject> Card;

    public virtual void FillDeck()
    {
    }

    public virtual void Shuffle()
    {
    }

    public virtual void DrawCard(Transform t)
    {
    }

    public virtual void ReturnCard(GameObject c)
    {
    }
}
