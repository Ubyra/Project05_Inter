using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : PlayerStateMachine
{
    [Header("Player Atributes")]
    public Rigidbody rb;
    public NPCChecker npcChecker;
    public UiElementsManager interfaceManager;
    public GameObject atualInteractedNPC;
    public int atualText = -1;

    [Header("Player Movement")]
    public float playerVelocity;
    public float turnSmoothTime = 0.1f;
    public Vector3 direction;
    private Vector3 inputDirection;
    private float turnSmoothVelocity;

    private void Start()
    {
        SetState(new PlayerStart(this));
        inputDirection = Vector3.zero;
    }

    private void Update()
    {
        MovementCheck();

        if (npcChecker.targetNPC != null)
        {
            if (npcChecker.targetNPC.gameObject != atualInteractedNPC)
                Dialogue(false);

            if (Input.GetKeyDown(KeyCode.G))
            {
                State.Interact();
            }

        }
        else
        {
            interfaceManager.dialogueText.text = "";
            Dialogue(false);
        }

    }

    private void MovementCheck()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();

        direction.x = inputDirection.x;
        direction.z = inputDirection.z;
        direction.Normalize();

        if (inputDirection.magnitude >= 0.1f)
        {
            //float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            State.Move();
        }
        else if (inputDirection.magnitude < 0.1f)
        {
            State.Stop();
        }
    }

    public void Dialogue(bool condition)
    {
        if (condition)
        {
            atualInteractedNPC = npcChecker.targetNPC.gameObject;
        }
        else
        {
            atualInteractedNPC = null;
        }

        interfaceManager.dialogueObject.SetActive(condition);
    }

    public void DialogueController()
    {
        if (atualText == -1)
        {
            atualText = 0;
            interfaceManager.dialogueText.text = npcChecker.targetNPC.configs.firstDialogueOption[atualText];
            interfaceManager.dialogueName.text = npcChecker.targetNPC.configs.npcName;
            Dialogue(true);
        }
        else
        {
            atualText += 1;
            if (atualText < npcChecker.targetNPC.configs.firstDialogueOption.Length)
            {
                interfaceManager.dialogueText.text = npcChecker.targetNPC.configs.firstDialogueOption[atualText];
            }
            else
            {
                atualText = -1;
                Dialogue(false);
            }
        }
    }
}