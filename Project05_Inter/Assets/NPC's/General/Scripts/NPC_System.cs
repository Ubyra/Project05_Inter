using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_System : NPC_StateMachine
{
    [Header("NPC Atributes")]
    public int interactionState;
    public GameObject interactionCanvas;
    public NPC_Configs configs;
    public NPC_CanvasManager canvasManager;
    public Rigidbody rb;
    private MeshRenderer myMaterial;

    [Header("NPC random Walk Configs")]
    public float speed = 20f;
    public float timeWaiting = 3f;
    public float timeWaitingRange = 1f;
    private float timeWaitingCounter;
    private bool isWaiting = true;

    public float maxDistanceRadiusToWalk = 4f;
    public Vector3 newPoint;
    public Vector3 direction;
    private Vector3 startPosition;

    [Header("Dialogue Atributtes")]
    public bool isTalking;

    private void Awake()
    {
        myMaterial = GetComponentInChildren<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        State = new NPC_Wait(this);

        startPosition = transform.position;
        myMaterial.material = configs.npcMaterial;

        isWaiting = true;
        isTalking = false;
        timeWaitingCounter = timeWaiting + Random.Range(-timeWaitingRange, timeWaitingRange);
    }

    private void Update()
    {
        NPCMovement();
    }

    public void NPCMovement()
    {
        if (configs.walk)
        {
            if (!isTalking)
            {
                if (isWaiting)
                    timeWaitingCounter -= Time.deltaTime;
                else
                    State.Move();

                if (timeWaitingCounter <= 0)
                {
                    newPoint = RandomPoint();
                    timeWaitingCounter = timeWaiting + Random.Range(-timeWaitingRange, timeWaitingRange);

                    direction = newPoint - transform.position;
                    direction.Normalize();

                    isWaiting = false;
                }

                if (Vector3.Distance(newPoint, transform.position) < .2f)
                {
                    if (isWaiting == false)
                        timeWaitingCounter = timeWaiting + Random.Range(-timeWaitingRange, timeWaitingRange);
                    State.Stop();
                    isWaiting = true;
                }
            }
        }
    }

    public Vector3 RandomPoint()
    {
        Vector3 point = new Vector3(Random.Range(-maxDistanceRadiusToWalk, maxDistanceRadiusToWalk), 0f, Random.Range(-maxDistanceRadiusToWalk, maxDistanceRadiusToWalk)).normalized;
        point *= Random.Range(1f, maxDistanceRadiusToWalk);

        point += startPosition;

        return point;
    }

    public void StopMove()
    {
        if (isWaiting == false)
            timeWaitingCounter = timeWaiting + Random.Range(-timeWaitingRange, timeWaitingRange);
        State.Stop();
        isWaiting = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC"))
        {
            StopMove();
        }
    }
}