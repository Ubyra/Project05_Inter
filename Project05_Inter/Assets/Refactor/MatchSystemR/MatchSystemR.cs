using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystemR : Match_StateMachineR
{
    [Header("External Scripts")]
    public CardSpot[] spots;
    public PileDeck pileDeck;
    public PlayerHand PlayerHand;
    [SerializeField] public CardSystem SelectedCard { get; private set; }
    public int Round { get; private set; }

    public CameraSystem CamSystem;

    private void Start()
    {
        Round = 0;
        SetState(new Match_StartR(this));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseSelection = MouseSelector.HitCollider();

            bool isSelectingCardSpot = mouseSelection == spots[Round].col && PlayerHand._selectedCard != null;
            bool isSelectingDiscardSpot = mouseSelection == pileDeck.deckCollider && PlayerHand._selectedCard != null;

            if (isSelectingDiscardSpot)
            {
                StartCoroutine(State.Discard());
            }
            else if (isSelectingCardSpot)
            {
                StartCoroutine(State.PutCard());
            }
            else
            {
                StartCoroutine(State.SelectCard());
            }
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