using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystem : MatchStateMachine
{
    [Header("Other Scripts Access")]
    public CameraSystem camSystem;
    public Transform selectedCard;

    [Header("Match Atributes")]
    public int turn;
    public CardSpot clickedSpot;

    private void Start()
    {
        SetState(new Match_Start(this));
    }
}