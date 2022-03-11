using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC_State
{
    protected NPC_System NPC;

    public NPC_State(NPC_System system)
    {
        NPC = system;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual void Move()
    {

    }

    public virtual void Stop()
    {

    }
}
