using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardState
{
    protected CardSystem Card;

    public CardState(CardSystem system)
    {
        Card = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void CardOver()
    {
    }

    public virtual IEnumerator OnCardClick()
    {
        yield break;
    }

    public virtual IEnumerator PutCard()
    {
        yield break;
    }

    public virtual IEnumerator LooseCard()
    {
        yield break;
    }

    public virtual IEnumerator Discard()
    {
        yield break;
    }
}