using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystems : PlayerStateMachine
{
    [Header("Player Atributes")]
    public Rigidbody rb;
    public PlayerNPCChecker npcChecker;
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
            {
                atualText = -1;
                interfaceManager.dialogueText.text = "";

                if (atualInteractedNPC != null)
                    atualInteractedNPC.GetComponent<NPC_System>().isTalking = false;

                Dialogue(false);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                State.Interact();
            }

        }
        else
        {
            atualText = -1;
            interfaceManager.dialogueText.text = "";

            if(atualInteractedNPC != null)
                atualInteractedNPC.GetComponent<NPC_System>().isTalking = false;

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
            Vector3 angle = (transform.position + direction) - transform.position;
            Quaternion rotation = Quaternion.Euler(0f, angle.y, 0f);

            transform.rotation = rotation;

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
        if(npcChecker.targetNPC.interactionState == 0)
        {
            if (atualText == -1)
            {
                npcChecker.targetNPC.StopMove();
                npcChecker.targetNPC.isTalking = true;

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
                    npcChecker.targetNPC.isTalking = false;
                    atualText = -1;
                    npcChecker.targetNPC.interactionState = 1;
                    npcChecker.targetNPC.canvasManager.UpdateDisplay();
                    Dialogue(false);
                }
            }
        }
        else if (npcChecker.targetNPC.interactionState == 1)
        {
            npcChecker.targetNPC.SetState(new NPC_Dead(npcChecker.targetNPC));
        }
    }
}