using System.Collections;
using UnityEngine;

public class Idle : PlayerState
{
    public Idle(PlayerSystems system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        yield break;
    }

    public override void Move()
    {
        Player.SetState(new Walk(Player));
    }
}