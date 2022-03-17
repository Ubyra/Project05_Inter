using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_EnemyTurn : Match_State
{
    public Match_EnemyTurn(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("_Enemy Turn");
        return base.Start();
    }
}