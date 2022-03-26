using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState_EnemyTurn : MatchState
{
    public MatchState_EnemyTurn(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        waitTime = new WaitForSeconds(2);
        Debug.Log("_Enemy Turn");

        yield return waitTime;

        // Enemy Draw's a card;
        System.EnemyHand.DrawCard(System.MainDeck);

        yield return waitTime;

        // Enemy Discard's a card;
        System.EnemyHand.DiscardCard(System.EnemyHand.CardsInHand[0], System.DiscardDeck.transform);

        yield return waitTime;

        // Enemy PutDown a card;
        Debug.Log("_Enemy Put Down a Card");

        yield return waitTime;

        System.SetState(new MatchState_MyTurn(System));
    }
}