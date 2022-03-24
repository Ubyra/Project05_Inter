using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [Header("External References")]
    public MainDeck deck;
    public CardSystemR[] cardPool;
    public Transform selectedCardPosition;
    public MatchSystemR matchSystem;

    [Header("Player Hand")]
    public List<CardSystemR> cardsInHand;
    public CardConfig[] configs;
    public CardSystemR _selectedCard;
    public int initialCardInHand;
    public int CurrentCardsInHand { get; private set; }

    [Header("Other Configs")]
    public bool canMoveCard = true;
    public bool canHighlightCard = false;
    private List<Vector3> cardPositions;

    #region Métodos Default

    private void Awake()
    {
        GetCardPool();
    }

    private void Start()
    {
        CurrentCardsInHand = 0;
        cardPositions = new List<Vector3>();
    }

    private void Update()
    {
        CardHighlight();
        CardMovements();
    }

    #endregion

    #region Métodos de Seleção

    public void GetCardPool()
    {
        cardPool = GetComponentsInChildren<CardSystemR>();

        for (int i = 0; i < cardPool.Length; i++)
        {
            cardPool[i].cardCollider.enabled = false;
        }
    }

    public void SelectCard()
    {
        var colisor = MouseSelector.HitCollider();
        var selectedCardSystem = colisor.GetComponentInParent<CardSystemR>();

        if (_selectedCard != null)
        {
            _selectedCard.UnSelect = true;
            _selectedCard.IsSelected = false;
        }

        if (selectedCardSystem != null && selectedCardSystem != _selectedCard)
        {
            if (!selectedCardSystem.IsInMovement)
            {
                _selectedCard = selectedCardSystem;
                _selectedCard.Select = true;
                _selectedCard.IsSelected = true;
                _selectedCard.StartCardMovement(selectedCardPosition.position, selectedCardPosition.rotation, 0.3f);
            }
        }
        else
        {
            _selectedCard = null;
        }
    }

    #endregion

    #region Métodos de Atualização

    public void CardHighlight()
    {
        if (canHighlightCard)
        {
            foreach (CardSystemR c in cardPool)
            {
                c.CardHighlight();
            }
        }
    }

    public void CardMovements()
    {
        if (canMoveCard)
        {
            foreach (CardSystemR c in cardPool)
            {
                c.MovementCard();
            }
        }
    }

    [ContextMenu("Update Cards In their Own Position")]
    public void UpdateCardsPositions()
    {
        float totalSpace = (0.8f * CurrentCardsInHand);
        float firstPosition = -(totalSpace / 2);
        float xPos = firstPosition;

        for (int i = 0; i < CurrentCardsInHand + 1; i++)
        {
            var position = new Vector3(xPos, 0f + transform.position.y, 0f + transform.position.z);

            if (cardPool[i].Config != null)
                cardPool[i].StartCardMovement(position, Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);

            xPos += 0.75f;
        }
    }

    public void UpdateVectors()
    {

        if (cardPositions.Count > 0)
            cardPositions.Clear();

        float totalSpace = (0.8f * CurrentCardsInHand);
        float firstPosition = -(totalSpace / 2);
        float xPos = firstPosition;

        for (int i = 0; i < CurrentCardsInHand + 1; i++)
        {
            var position = new Vector3(xPos, 0f + transform.position.y, 0f + transform.position.z);

            if (cardPool[i].Config != null)
                cardPositions.Add(position);

            xPos += 0.75f;
        }
    }

    public void UpdateThisCardPosition(int index)
    {
        UpdateVectors();

        cardPool[index].StartCardMovement(cardPositions[index], Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);
        cardPool[index].cardCollider.enabled = true;
    }

    #endregion

    #region Métodos de Ação

    public void DrawCard(int index)
    {
        cardPool[index].Config = deck.NextCardToDraw();
        cardPool[index].UIElements.UpdateElements();

        UpdateCardsPositions();
        UpdateThisCardPosition(index);

        CurrentCardsInHand += 1;
    }

    public void Discard()
    {
        var DiscardedCard = _selectedCard;

        _selectedCard.UnSelect = false;
        _selectedCard.IsSelected = false;
        _selectedCard = null;

        DiscardedCard.StartCardMovement(matchSystem.spots[matchSystem.Round].transform.position, matchSystem.spots[matchSystem.Round].transform.rotation, 0.3f);
    }
    #endregion
}