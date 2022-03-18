using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_StartR : Match_StateR
{
    public Match_StartR(MatchSystemR system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2f);
        Debug.Log("_Match Start_");

        // Defines who's start. Then, go to their turns.

        bool myTurn = Random.Range(0, 100) < 50;

        yield return waitTime;

        if (myTurn) System.SetState(new Match_MyTurn(System));
        else System.SetState(new Match_EnemyTurnR(System));
    }
}