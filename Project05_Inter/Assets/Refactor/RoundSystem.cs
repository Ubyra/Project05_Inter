using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public MatchSystem Match;
    public int Round { get; private set; }

    public IEnumerator NextRound()
    {
        WaitForSeconds WaitTime = new WaitForSeconds(0.6f);
        Round += 1;

        Match.PlayerHand.DiscardAllHand();
        Match.EnemyHand.DiscardAllHand();

        yield return WaitTime;

        Match.DiscardDeck.ReturnAllDiscardDeck(Match.MainDeck.transform);

        yield return WaitTime;

        Match.MainDeck.Shuffle();

        yield return WaitTime;

        StartCoroutine(Match.PlayerHand.FirstDraw());
        StartCoroutine(Match.EnemyHand.FirstDraw());
    }
}