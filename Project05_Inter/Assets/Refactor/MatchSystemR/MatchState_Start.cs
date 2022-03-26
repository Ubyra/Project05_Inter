using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState_Start : MatchState
{
    public MatchState_Start(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(.5f);
        Debug.Log("_Match Start_");

        System.StartCoroutine(System.PlayerHand.FirstDraw());
        System.StartCoroutine(System.EnemyHand.FirstDraw());

        //bool myTurn = Random.Range(0, 100) < 50;
        bool myTurn = false;

        yield return waitTime;

        if (myTurn) System.SetState(new MatchState_MyTurn(System));
        else System.SetState(new MatchState_EnemyTurn(System));
    }
}