using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Wait : NPC_State
{
    public NPC_Wait(NPC_System system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        return base.Start();
    }

    public override void Move()
    {
        NPC.SetState(new NPC_Walk(NPC));
    }

    public override void Stop()
    {
    }
}