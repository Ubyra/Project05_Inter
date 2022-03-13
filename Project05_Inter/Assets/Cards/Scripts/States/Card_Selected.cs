using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Selected : CardState
{
    public Card_Selected(CardSystem system) : base(system)
    {
    }

    public override IEnumerator Start()
    {
        Card.UpdateNewScale(false);
        return base.Start();
    }

    public override IEnumerator PutCard()
    {
        if(Card.matchSystem.clickedSpot != null)
        {
            Card.StartCardMovement(Card.matchSystem.clickedSpot.modelTransform.position, Card.matchSystem.clickedSpot.modelTransform.rotation);

            yield return new WaitForSeconds(Card.desiredMovementTime);

            Card.SetState(new Card_InMatch(Card));
        }
        else
        {
            yield break;
        }
    }

    public override IEnumerator OnCardClick()
    {
        if (!Card.IsMouseColliding && Card.matchSystem.clickedSpot == null)
        {
            Card.StartCardMovement(Card.startPosition, Card.startRotation);

            yield return new WaitForSeconds(Card.desiredMovementTime);

            Card.SetState(new Card_Hand(Card));
        }
        else if (Card.matchSystem.clickedSpot != null)
        {
            Card.StartCardMovement(Card.matchSystem.clickedSpot.modelTransform.position, Card.matchSystem.clickedSpot.modelTransform.rotation);

            yield return new WaitForSeconds(Card.desiredMovementTime);

            Card.SetState(new Card_InMatch(Card));
        }
        else
        {
            yield break;
        }
    }

    public override IEnumerator Discard()
    {
        return base.Discard();
    }
}