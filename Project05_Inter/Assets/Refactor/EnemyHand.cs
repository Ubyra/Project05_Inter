using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : Hand
{
    [Header("Card Atributtes")]
    public bool canMoveCard;
    public List<Vector3> cardPositions;

    private void Awake()
    {
        cardPositions = new List<Vector3>();
    }

    private void Update()
    {
        CardMovements();
    }

    #region Update Methods

    public void UpdateCardPosition()
    {
        UpdateVectorsPositions();

        for (int i = 0; i < CardsInHand.Count; i++)
        {
            CardsInHand[i].GetComponent<CardSystem>().StartCardMovement(cardPositions[i], Quaternion.Euler(new Vector3(20f, 0f, 0f)), 0.3f);
            CardsInHand[i].GetComponent<CardSystem>().cardCollider.enabled = true;
        }
    }

    public void UpdateCardPosition(int index)
    {
        UpdateVectorsPositions();

        CardsInHand[index].GetComponent<CardSystem>().StartCardMovement(cardPositions[index], Quaternion.Euler(new Vector3(20f, 0f, 0f)), 0.3f);
        CardsInHand[index].GetComponent<CardSystem>().cardCollider.enabled = true;
    }

    public void UpdateCardPosition(GameObject g)
    {
        UpdateVectorsPositions();

        g.GetComponent<CardSystem>().StartCardMovement(cardPositions[cardPositions.Count -1], Quaternion.Euler(new Vector3(20f, 0f, 0f)), 0.3f);
        g.GetComponent<CardSystem>().cardCollider.enabled = true;
    }

    public void CardMovements()
    {
        if (canMoveCard)
        {
            foreach (GameObject g in CardsInHand)
            {
                g.GetComponent<CardSystem>().MovementCard();
            }
        }
    }

    public void UpdateVectorsPositions()
    {
        cardPositions.Clear();

        float total = 0.8f * CardsInHand.Count;
        float firstPosition = 0.45f -(total/2);
        float xPos = firstPosition;

        for (int i = 0; i < CardsInHand.Count; i++)
        {
            var position = new Vector3(xPos, 0f + transform.position.y, 0f + transform.position.z);

            cardPositions.Add(position);

            xPos += 0.75f;
        }
    }
    #endregion

    #region Action Methods

    public override IEnumerator FirstDraw()
    {
        WaitTime = new WaitForSeconds(.1f);

        yield return WaitTime;

        while(CardsInHand.Count < Match.initialDraw)
        {
            DrawCard(MainDeck);

            yield return WaitTime;
        }
    }

    public override void DrawCard(Deck deckUsed)
    {
        CardsInHand.Add(deckUsed.TopCard);
        deckUsed.DrawCard(transform);
        UpdateCardPosition();
    }

    public override void DiscardCard(GameObject card, Transform position)
    {
        Debug.Log("Discard");

        card.transform.SetParent(position, true);

        card.GetComponent<CardSystem>().StartCardMovement(DiscardDeck.transform.position, DiscardDeck.transform.rotation, 0.3f);

        UpdateCardPosition();

        CardsInHand.Remove(card);
    }
    #endregion
}