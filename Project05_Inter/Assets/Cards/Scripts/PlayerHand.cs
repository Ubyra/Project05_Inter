using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Deck deck;
    public CardSystemR[] card;
    public Transform selectedCardPosition;
    public CardSystemR _selectedCard;
    private Transform selectedCardCurrentTransform;
    private int selectedCardIndex;
    public bool randomizeCards;

    public int initialCardInHand;
    public int CurrentCardsInHand { get; private set; }

    public CardConfig[] configs;
    public bool canMoveCard = true;
    public bool canHighlightCard = false;
    private List<Vector3> cardPositions;

    private void Awake()
    {
        GetCards();
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

    public void DrawCard(int index)
    {
        card[index].Config = deck.NextCardToDraw();
        card[index].UIElements.UpdateElements();

        UpdateCardsPositions();
        UpdateThisCardPosition(index);

        CurrentCardsInHand += 1;
    }

    public void GetCards()
    {
        card = GetComponentsInChildren<CardSystemR>();

        for (int i = 0; i < card.Length; i++)
        {
            card[i].cardCollider.enabled = false;
        }
    }

    public void CardHighlight()
    {
        if (canHighlightCard)
        {
            foreach(CardSystemR c in card)
            {
                c.CardHighlight();
            }
        }
    }

    public void CardMovements()
    {
        if (canMoveCard)
        {
            foreach (CardSystemR c in card)
            {
                c.MovementCard();
            }
        }
    }

    [ContextMenu("Update Cards In their Own Position")]
    public void UpdateCardsPositions()
    {
        float totalSpace = (0.8f * CurrentCardsInHand);
        float firstPosition = - (totalSpace / 2);
        float xPos = firstPosition;

        for (int i = 0; i < CurrentCardsInHand + 1; i++)
        {
            var position = new Vector3(xPos, 0f + transform.position.y, 0f + transform.position.z);

            card[i].StartCardMovement(position, Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);

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

            cardPositions.Add(position);

            xPos += 0.75f;
        }
    }

    public void UpdateThisCardPosition(int index)
    {
        UpdateVectors();

        card[index].StartCardMovement(cardPositions[index], Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);
        card[index].cardCollider.enabled = true;
    }
}