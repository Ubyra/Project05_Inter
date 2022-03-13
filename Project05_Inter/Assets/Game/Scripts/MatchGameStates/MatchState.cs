using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatchState
{
    protected MatchSystem Match;

    public MatchState(MatchSystem system)
    {
        Match = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}
