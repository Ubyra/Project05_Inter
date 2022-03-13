using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match_Start : MatchState
{
    public Match_Start(MatchSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        //Match.turn = (int) Random.Range(0f, 1.99f);

        if(Match.turn == 0)
        {
            Match.SetState(new Match_YourTurn(Match));
        }
        else
        {
            Match.SetState(new Match_EnemyTurn(Match));
        }

        return base.Start();
    }
}
