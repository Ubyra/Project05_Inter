using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState_PutDown : MatchState
{
    public MatchState_PutDown(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2f);
        Debug.Log("_Put Down a Card");

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

    public override IEnumerator PutCard()
    {
        waitTime = new WaitForSeconds(2f);

        System.PlayerHand.canHighlightCard = false;
        //System.PlayerHand.canMoveCard = false;
        // Put the Card;

        yield return waitTime;

        System.SetState(new MatchState_EnemyTurn(System));
    }

    public override void CardOverlaySelection()
    {
        // Allow the card to overlay;
    }
}