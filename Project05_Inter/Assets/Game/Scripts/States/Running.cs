using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : GameState
{
    public Running(GameSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Debug.Log("Game is Running.");
        yield break;
    }

    public override void Pause()
    {
        Game.SetState(new Paused(Game));
    }
}
