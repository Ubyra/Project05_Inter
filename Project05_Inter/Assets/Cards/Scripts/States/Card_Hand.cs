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
        if (Card.IsMouseColliding) Card._highLight.OnHighlight(Card.transform);
        else Card._highLight.OnDehighlight(Card.transform);
    }

    public override IEnumerator OnCardClick()
    {
        if (Card.IsMouseColliding)
        {
            Card.ChangeCardSelected();
            Card.StartCardMovement(Card.matchSystem._selectedCardReference.position, Card.matchSystem._selectedCardReference.rotation);
            Card.matchSystem._camSystem.ChangeCamera("Selected");

            yield return new WaitForSeconds(Card.desiredMovementTime);

            Card.SetState(new Card_Selected(Card));
        }
        else
        {
            yield break;
        }
    }
}