using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_Discard : Match_StateR
{
    public Match_Discard(MatchSystemR system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        System.PlayerHand.canHighlightCard = true;
        System.PlayerHand.canMoveCard = true;
        return base.Start();
    }

    public override IEnumerator SelectCard()
    {
        waitTime = new WaitForSeconds(2f);

        // Card is Selected ? Animation to Select : Animation to Hand;

        yield return waitTime;
    }

    public override IEnumerator Discard()
    {
        waitTime = new WaitForSeconds(2f);

        System.PlayerHand.canHighlightCard = false;
        //System.PlayerHand.canMoveCard = false;
        // Discard the card;

        yield return waitTime;

        System.SetState(new Match_PutDown(System));
    }

    public override void CardOverlaySelection()
    {
        // Allow the card to overlay;
    }
}