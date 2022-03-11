using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Walk : NPC_State
{
    public NPC_Walk(NPC_System system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        return base.Start();
    }

    public override void Move()
    {
        NPC.rb.AddForce(NPC.direction * NPC.speed * Time.deltaTime * 100, ForceMode.Acceleration);
    }

    public override void Stop()
    {
        NPC.SetState(new NPC_Wait(NPC));
    }
}
