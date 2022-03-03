using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerState
{
    public Walk(PlayerSystems system) : base(system)
    {
    }

    public override void Move()
    {
        Player.rb.AddForce(Player.direction * Player.playerVelocity * Time.deltaTime * 100, ForceMode.Acceleration);
    }

    public override void Stop()
    {
        Player.SetState(new Idle(Player));
    }
}