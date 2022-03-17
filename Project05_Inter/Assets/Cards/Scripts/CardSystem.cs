using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : CardStateMachine
{
    [Header("Card Atributtes")]
    public Collider colisor;
    public GameObject cardModel;
    public MatchSystem matchSystem;
    public IHighlightSelection _highLight;

    [Header("Card Configs")]
    public CardConfig cardConfig;
    public bool IsMouseColliding => MouseSelector.HitCollider() == colisor;

    [Header("Card Start Atributes")]
    public Vector3 startPosition;
    public Quaternion startRotation;

    private Vector3 atualPosition;
    private Quaternion atualRotation;

    [Header("Card Movement Atributes")]
    public float desiredMovementTime;
    private float enlapsedTime;
    private float percentageComplete;
    private bool isInMovement = false;
    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    private void Awake()
    {
        _highLight = GetComponent<IHighlightSelection>();
    }

    private void Start()
    {
        SetState(new Card_Hand(this));
        startPosition = transform.position;
        startRotation = transform.rotation;

        atualPosition = transform.position;
        atualRotation = transform.rotation;

        _highLight.HighlightInitialize(transform);
    }

    private void Update()
    {
        if(matchSystem.turn == 0)
        {
            State.CardOver();

            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(State.OnCardClick());
            }

            MovementCard();
        }
    }

    public void StartCardMovement(Vector3 pos, Quaternion rotation)
    {
        atualPosition = transform.position;
        atualRotation = transform.rotation;

        desiredPosition = pos;
        desiredRotation = rotation;

        isInMovement = true;
        enlapsedTime = 0;
    }

    public void MovementCard()
    {
        if (isInMovement)
        {
            enlapsedTime += Time.deltaTime;
            percentageComplete = enlapsedTime / desiredMovementTime;

            transform.position = Vector3.Lerp(atualPosition, desiredPosition, Mathf.SmoothStep(0, 1, percentageComplete));
            transform.rotation = Quaternion.Lerp(atualRotation, desiredRotation, Mathf.SmoothStep(0, 1, percentageComplete));

            if (transform.position == desiredPosition)
            {
                isInMovement = false;
                desiredPosition = Vector3.zero;
                desiredRotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }

    public void ChangeCardSelected()
    {
        if(matchSystem._cardSelected == null)
        {
            matchSystem._cardSelected = this;
            return;
        }

        if(matchSystem._cardSelected != gameObject)
        {
            matchSystem._cardSelected.SetState(new Card_Selected(matchSystem._cardSelected));
            StartCoroutine(matchSystem._cardSelected.State.GoBackToHand());
            matchSystem._cardSelected = this;
        }
    }
}