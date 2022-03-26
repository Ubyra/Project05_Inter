using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatchState
{
    protected MatchSystem System;
    protected WaitForSeconds waitTime;

    public MatchState(MatchSystem system)
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

    public virtual IEnumerator DrawCard(Deck deck)
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

    public virtual void CardOverlaySelection()
    {

    }
}