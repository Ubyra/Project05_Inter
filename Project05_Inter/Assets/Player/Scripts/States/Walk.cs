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
        Player.rb.AddForce(Player.direction * Player.playerVelocity);
        //Vector3 movement = Player.direction * Player.playerVelocity;
        //Player.rb.velocity = movement;
    }

    public override void Stop()
    {
        //Player.rb.velocity = Vector3.zero;
        Player.SetState(new Idle(Player));
    }
}