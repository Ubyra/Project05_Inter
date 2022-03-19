using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystemR : Match_StateMachineR
{
    [Header("External Scripts")]
    public PlayerHand PlayerHand;
    [SerializeField] public CardSystem SelectedCard { get; private set; }

    public CameraSystem CamSystem;

    private void Start()
    {
        SetState(new Match_StartR(this));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(State.SelectCard());
        }
    }

    public void DiscardCard()
    {
        StartCoroutine(State.Discard());
    }

    public void DrawCard()
    {
        StartCoroutine(State.DrawCard());
    }
}