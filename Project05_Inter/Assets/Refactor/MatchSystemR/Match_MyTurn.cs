using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_MyTurn : Match_StateR
{
    public Match_MyTurn(MatchSystemR system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2f);
        Debug.Log("_My Turn");

        System.PlayerHand.canHighlightCard = false;
        //System.PlayerHand.canMoveCard = false;

        yield return waitTime;

        // Draw the card;
        Debug.Log("_I Draw a card");

        yield return waitTime;

        System.SetState(new Match_Discard(System));
    }
}