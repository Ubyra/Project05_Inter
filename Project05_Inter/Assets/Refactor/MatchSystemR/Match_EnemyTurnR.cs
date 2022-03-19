using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_EnemyTurnR : Match_StateR
{
    public Match_EnemyTurnR(MatchSystemR system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2);
        Debug.Log("_Enemy Turn");

        System.PlayerHand.canHighlightCard = false;
        //System.PlayerHand.canMoveCard = false;

        yield return waitTime;

        // Enemy Draw's a card;
        Debug.Log("_Enemy Draw a Card");

        yield return waitTime;

        // Enemy Discard's a card;
        Debug.Log("_Enemy Discard a Card");

        yield return waitTime;

        // Enemy PutDown a card;
        Debug.Log("_Enemy Put Down a Card");

        yield return waitTime;

        System.SetState(new Match_MyTurn(System));
    }
}