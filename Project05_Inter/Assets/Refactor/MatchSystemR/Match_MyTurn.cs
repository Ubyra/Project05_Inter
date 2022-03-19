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
    }

    public override IEnumerator DrawCard()
    {
        waitTime = new WaitForSeconds(0.6f);

        System.PlayerHand.DrawCard(System.PlayerHand.CurrentCardsInHand);

        yield return waitTime;

        System.SetState(new Match_Discard(System));
    }
}