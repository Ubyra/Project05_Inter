using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystem : MatchStateMachine
{
    [Header("Other Scripts Access")]
    public CameraSystem _camSystem;
    public Transform _selectedCardReference;
    public PlayerHand _playerHand;

    [Header("Match Atributes")]
    public int turn;
    public CardSpot clickedSpot;

    private void Start()
    {
        SetState(new Match_Start(this));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(State.ShowCards());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(State.ShowBoard());
        }
    }
}