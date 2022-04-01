using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState_PointsCounting : MatchState
{
    public MatchState_PointsCounting(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(1f);
        System.PlayerHand.canHighlightCard = true;

        Debug.Log("_Counting Points");
        System.CountingPoints();

        yield return waitTime;

        Debug.Log("_Points Counted");
        System.ResetPoints();
        System.StartCoroutine(System.NextRound());
    }
}