using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSystem : MatchSystem_StateMachine
{
    [Header("External Scripts")]
    public Board Board;
    public RoundSystem RoundSystem;
    public PlayerHand PlayerHand;
    public EnemyHand EnemyHand;

    public Deck MainDeck;
    public Deck DiscardDeck;

    [SerializeField] public CardSystem SelectedCard { get; private set; }
    public int Turn { get; private set; }
    public int Round { get; private set; }

    public CameraSystem CamSystem;

    [Header("Match Configs")]
    public int initialDraw;

    private void Start()
    {
        Turn = 0;
        Round = 0;
        SetState(new MatchState_Start(this));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseSelection = MouseSelector.HitCollider();

            bool isSelectingCardSpot = mouseSelection == Board.PlayerSpots[Turn].spotCollider && Board.PlayerSpots[Turn].playerSpot && PlayerHand._selectedCard != null;
            bool isSelectingDiscardSpot = mouseSelection == DiscardDeck.areaCollider;
            bool isSelectingMainDeckSpot = mouseSelection == MainDeck.areaCollider;

            if (isSelectingMainDeckSpot)
            {
                StartCoroutine(State.DrawCard(MainDeck));
            }
            else if (isSelectingDiscardSpot)
            {
                if (PlayerHand._selectedCard != null)
                    StartCoroutine(State.Discard());
                else
                    StartCoroutine(State.DrawCard(DiscardDeck));
            }
            else if (isSelectingCardSpot)
            {
                Debug.Log("Try Put card");
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

    public void DrawCard(Deck deck)
    {
        StartCoroutine(State.DrawCard(deck));
    }

    public void NextTurn()
    {
        Turn += 1;
    }

    public void CheckEndTurn()
    {
        if(Turn >= Board.PlayerSpots.Count - 1)
        {
            StartCoroutine(RoundSystem.NextRound());
        }
    }
}