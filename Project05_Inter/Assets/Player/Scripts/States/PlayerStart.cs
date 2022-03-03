using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : PlayerState
{   
    public PlayerStart(PlayerSystems system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        WaitForSeconds s = new WaitForSeconds(2f);

        yield return s;

        Player.SetState(new Idle(Player));
    }
}