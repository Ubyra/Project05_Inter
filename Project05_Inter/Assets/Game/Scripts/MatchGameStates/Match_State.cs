using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Match_State
{
    protected MatchSystem Match;

    public Match_State(MatchSystem system)
    {
        Match = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator ShowCards()
    {
        yield break;
    }

    public virtual IEnumerator ShowBoard()
    {
        yield break;
    }
}
