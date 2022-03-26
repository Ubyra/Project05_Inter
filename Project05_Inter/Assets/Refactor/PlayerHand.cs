using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : Hand
{
    [Header("External Atributtes")]
    public Transform _SelectCardPosition;
    public GameObject _selectedCard;

    [Header("Card Atributtes")]
    public bool canMoveCard;
    public bool canHighlightCard;
    public List<Vector3> cardPositions;

    private void Awake()
    {
        CardsInHand = new List<GameObject>();
        cardPositions = new List<Vector3>();
    }

    private void Update()
    {
        CardHighlight();
        CardMovements();
    }

    #region Update Methods

    public void UpdateCardPosition()
    {
        UpdateVectorsPositions();

        for (int i = 0; i < CardsInHand.Count; i++)
        {
            CardsInHand[i].GetComponent<CardSystem>().StartCardMovement(cardPositions[i], Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);
            CardsInHand[i].GetComponent<CardSystem>().cardCollider.enabled = true;
        }
    }

    public void UpdateCardPosition(int index)
    {
        UpdateVectorsPositions();

        CardsInHand[index].GetComponent<CardSystem>().StartCardMovement(cardPositions[index], Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);
        CardsInHand[index].GetComponent<CardSystem>().cardCollider.enabled = true;
    }

    public void UpdateCardPosition(GameObject g)
    {
        UpdateVectorsPositions();

        g.GetComponent<CardSystem>().StartCardMovement(cardPositions[cardPositions.Count -1], Quaternion.Euler(new Vector3(-20f, 0f, 0f)), 0.3f);
        g.GetComponent<CardSystem>().cardCollider.enabled = true;
    }

    public void CardHighlight()
    {
        if (canHighlightCard)
        {
            foreach (GameObject g in CardsInHand)
            {
                g.GetComponent<CardSystem>().CardHighlight();
            }
        }
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
        string debug = "-- Start First Draw \n";
        WaitTime = new WaitForSeconds(.1f);

        yield return WaitTime;

        debug += "- Let's draw \n";
        while(CardsInHand.Count < Match.initialDraw)
        {
            DrawCard(MainDeck);
            debug += "- Draw \n" + CardsInHand[CardsInHand.Count - 1].GetComponent<CardSystem>().Config.cardName + " " + CardsInHand[CardsInHand.Count - 1].GetComponent<CardSystem>().Config.cardSuit.ToString() + "\n";

            yield return WaitTime;
        }

        debug += "[Cards Drawed] Expected: " + CardsInHand.Count + "/ Total: " + Match.initialDraw;
        Debug.Log(debug);
    }

    public override void DrawCard(Deck deck)
    {
        CardsInHand.Add(deck.TopCard);
        deck.DrawCard(transform);
        UpdateCardPosition();
    }

    public override void DiscardCard(GameObject card, Transform position)
    {
        
    }

    public override void SelectCard()
    {
        if (canHighlightCard)
        {
            if(_selectedCard == null)
            {
                for (int i = 0; i < CardsInHand.Count; i++)
                {
                    if(MouseSelector.HitCollider() == CardsInHand[i].GetComponent<CardSystem>().cardCollider)
                    {
                        CardsInHand[i].GetComponent<CardSystem>().StartCardMovement(_SelectCardPosition.position, _SelectCardPosition.rotation, 0.3f);
                    }
                }
            }
            else
            {
                UpdateCardPosition(_selectedCard);
                _selectedCard = null;
            }
        }
    }
    #endregion
}