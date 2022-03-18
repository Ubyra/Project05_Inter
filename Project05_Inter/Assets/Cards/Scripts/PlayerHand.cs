using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public Deck deck;
    public CardSystemR[] card;
    public GameObject _selectedCard;
    public bool randomizeCards;

    public CardConfig[] configs;
    public bool canMoveCard = true;
    public bool canHighlightCard = false;

    private void Awake()
    {
        if (randomizeCards) Randomize();
    }

    private void Update()
    {
        CardHighlight();
        CardMovements();
    }

    public void Randomize()
    {
        UpdateCardsPositions();

        foreach (CardSystemR c in card)
        {
            c.Config = configs[Random.Range(0, configs.Length)];
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
            foreach(CardSystemR c in card)
            {
                c.MovementCard();
            }
    }

    [ContextMenu("Update Cards In their Own Position")]
    public void UpdateCardsPositions()
    {
        card = GetComponentsInChildren<CardSystemR>();

        float totalSpace = (0.8f * card.Length-1);
        float firstPosition = - (totalSpace / 2);
        float xPos = firstPosition;

        for (int i = 0; i < card.Length; i++)
        {
            var position = new Vector3(xPos, card[i].transform.position.y, card[i].transform.position.z);

            card[i].StartCardMovement(position, Quaternion.identity, 0.3f);
            card[i].MovementCard();

            xPos += 0.75f;
        }
    }
}
