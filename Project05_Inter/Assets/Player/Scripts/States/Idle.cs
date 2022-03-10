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

    public override void Interact()
    {
        // Sett the dialogue Text;
        Player.interfaceManager.dialogueObject.SetActive(true);
        Player.actualInteractedNPC = Player.npcChecker.closestNPC.gameObject;
    }
}