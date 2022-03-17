using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_YourTurn : Match_State
{
    public Match_YourTurn(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("_My Turn");
        return base.Start();
    }

    public override IEnumerator ShowCards()
    {
        Match._camSystem.ChangeCamera("Hand");

        yield return new WaitForSeconds(.3f);
    }

    public override IEnumerator ShowBoard()
    {
        Match._camSystem.ChangeCamera("Board");

        yield return new WaitForSeconds(.3f);
    }
}