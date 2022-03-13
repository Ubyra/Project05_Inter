using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_YourTurn : MatchState
{
    public Match_YourTurn(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("_My Turn");
        return base.Start();
    }
}