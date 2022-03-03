using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerSystems Player;

    public PlayerState(PlayerSystems system)
    {
        Player = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void Stop()
    {

    }

    public virtual void Move()
    {

    }

    public virtual void Jump()
    {

    }
}