using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card_StateR
{
    protected CardSystemR System;
    protected WaitForSeconds waitTime;

    public Card_StateR(CardSystemR system)
    {
        System = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator NextState()
    {
        yield break;
    }

    public virtual IEnumerator DrawCard()
    {
        yield break;
    }

    public virtual IEnumerator Discard()
    {
        yield break;
    }

    public virtual IEnumerator SelectCard()
    {
        yield break;
    }

    public virtual IEnumerator PutCard()
    {
        yield break;
    }
}