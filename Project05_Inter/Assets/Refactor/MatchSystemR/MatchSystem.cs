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
    public ICombinations CombinationsConfigs;

    [SerializeField] public CardSystem SelectedCard { get; private set; }
    public int Turn { get; private set; }
    public int Round { get; private set; }

    public CameraSystem CamSystem;

    [Header("Match Configs")]
    public int initialDraw;
    public int PlayerPoints { get; private set; }
    public int EnemyPoints { get; private set; }

    private void Awake()
    {
        CombinationsConfigs = GetComponent<ICombinations>();
    }

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
        if (Turn > Board.PlayerSpots.Count - 1)
        {
            SetState(new MatchState_PointsCounting(this));
        }
        else
        {
            SetState(new MatchState_EnemyTurn(this));
        }
    }

    public IEnumerator NextRound()
    {
        WaitForSeconds WaitTime = new WaitForSeconds(0.6f);
        Round += 1;

        PlayerHand.DiscardAllHand();
        EnemyHand.DiscardAllHand();
        Board.DiscardSpots();

        yield return WaitTime;

        DiscardDeck.ReturnAllDiscardDeck(MainDeck);

        yield return WaitTime;

        MainDeck.Shuffle();

        StartCoroutine(PlayerHand.FirstDraw());
        yield return StartCoroutine(EnemyHand.FirstDraw());

        yield return WaitTime;

        Turn = 0;

        SetState(new MatchState_EnemyTurn(this));
    }

    public void CountingPoints()
    {
        List<GameObject> PlayerCards = new List<GameObject>();
        List<GameObject> EnemyCards = new List<GameObject>();

        for (int i = 0; i < Board.PlayerSpots.Count; i++)
        {
            PlayerCards.Add(Board.PlayerSpots[i].cardInThisSpot);
            EnemyCards.Add(Board.EnemySpots[i].cardInThisSpot);

            PlayerPoints += PlayerCards[i].GetComponent<CardSystem>().Config.cardValue;
            EnemyPoints += EnemyCards[i].GetComponent<CardSystem>().Config.cardValue;
        }

        PlayerPoints += CombinationsConfigs.CheckCombinationOne(PlayerCards);
        EnemyPoints += CombinationsConfigs.CheckCombinationOne(EnemyCards);

        Debug.Log("Player: " + PlayerPoints + "| Enemy: " + EnemyPoints);
    }

    public void ResetPoints()
    {
        PlayerPoints = 0;
        EnemyPoints = 0;
        Debug.Log("Player: " + PlayerPoints + "| Enemy: " + EnemyPoints);
    }
}