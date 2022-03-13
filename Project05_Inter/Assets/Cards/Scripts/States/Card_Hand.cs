using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Hand : CardState
{
    public Card_Hand(CardSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        return base.Start();
    }

    public override void CardOver()
    {
        Card.UpdateNewScale(Card.IsMouseColliding);
    }

    public override IEnumerator OnCardClick()
    {
        if (Card.IsMouseColliding)
        {
            Card.StartCardMovement(Card.matchSystem.selectedCard.position, Card.matchSystem.selectedCard.rotation);

            yield return new WaitForSeconds(Card.desiredMovementTime);

            Card.SetState(new Card_Selected(Card));
        }
        else
        {
            yield break;
        }
    }
}