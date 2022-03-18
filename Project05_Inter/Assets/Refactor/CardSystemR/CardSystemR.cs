using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystemR : Card_StateMachineR
{
    [Header("Card Config")]
    public CardConfig Config;

    [Header("External Scripts")]
    public Collider cardCollider;
    public IHighlightSelection highlightSelection;
    public bool IsMouseOver => MouseSelector.HitCollider() == cardCollider;

    [Header("Card System Atributtes")]
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
        highlightSelection = GetComponent<IHighlightSelection>();
    }

    private void Start()
    {
        SetState(new Card_StartR(this));
        highlightSelection.HighlightInitialize(transform);
    }

    public void CardHighlight()
    {
        if (IsMouseOver)
            highlightSelection.OnHighlight(transform);
        else
            highlightSelection.OnDehighlight(transform);
    }

    public void StartCardMovement(Vector3 pos, Quaternion rotation, float movementTime)
    {
        atualPosition = transform.position;
        atualRotation = transform.rotation;

        desiredPosition = pos;
        desiredRotation = rotation;
        desiredMovementTime = movementTime;

        isInMovement = true;
        enlapsedTime = 0;
    }

    public void MovementCard()
    {
        bool isInDesiredPosition = transform.position == desiredPosition;

        if (isInMovement)
        {
            enlapsedTime += Time.deltaTime;
            percentageComplete = enlapsedTime / desiredMovementTime;

            transform.SetPositionAndRotation(Vector3.Lerp(atualPosition, desiredPosition, Mathf.SmoothStep(0, 1, percentageComplete)), Quaternion.Lerp(atualRotation, desiredRotation, Mathf.SmoothStep(0, 1, percentageComplete)));

            if (isInDesiredPosition)
            {
                isInMovement = false;
                desiredPosition = Vector3.zero;
                desiredRotation = Quaternion.Euler(Vector3.zero);
            }
        }
    }
}