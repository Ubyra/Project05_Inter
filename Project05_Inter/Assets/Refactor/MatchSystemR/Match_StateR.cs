using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Match_StateR
{
    protected MatchSystemR System;
    protected WaitForSeconds waitTime;

    public Match_StateR(MatchSystemR system)
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

    public virtual void CardOverlaySelection()
    {

    }
}