using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState_Discard : MatchState
{
    public MatchState_Discard(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2f);
        Debug.Log("_Discard");

        System.PlayerHand.canHighlightCard = true;
        System.PlayerHand.canMoveCard = true;

        return base.Start();
    }

    public override IEnumerator SelectCard()
    {
        waitTime = new WaitForSeconds(2f);

        System.PlayerHand.SelectCard();

        yield return waitTime;
    }

    public override IEnumerator Discard()
    {
        waitTime = new WaitForSeconds(2f);

        System.PlayerHand.canHighlightCard = false;
        System.DiscardCard();

        yield return waitTime;

        System.SetState(new MatchState_PutDown(System));
    }

    public override void CardOverlaySelection()
    {
        // Allow the card to overlay;
    }
}