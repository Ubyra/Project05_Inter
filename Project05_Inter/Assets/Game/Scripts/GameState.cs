using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameSystem Game;

    public GameState(GameSystem system)
    {
        Game = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void Pause()
    {

    }
}