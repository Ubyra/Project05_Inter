using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_EndGame : Match_State
{
    public Match_EndGame(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("_End Game");
        return base.Start();
    }
}