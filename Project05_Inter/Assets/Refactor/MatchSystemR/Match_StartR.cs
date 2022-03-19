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
        waitTime = new WaitForSeconds(.5f);
        Debug.Log("_Match Start_");

        // Defines who's start. Then, go to their turns.

        //bool myTurn = Random.Range(0, 100) < 50;
        bool myTurn = true;

        yield return waitTime;

        for (int i = 0; i < System.PlayerHand.initialCardInHand; i++)
        {
            System.PlayerHand.DrawCard(i);

            yield return new WaitForSeconds(.15f);
        }

        if (myTurn) System.SetState(new Match_MyTurn(System));
        else System.SetState(new Match_EnemyTurnR(System));
    }
}