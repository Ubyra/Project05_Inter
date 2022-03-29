using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    [Header("Spot Atributes")]
    public int spotOrder;
    public bool playerSpot;
    public GameObject cardInThisSpot;
    private bool startUpdating;

    [Header("External Scripts")]
    public Collider spotCollider;
    public Transform modelTransform;

    private void Update()
    {
        if (startUpdating && cardInThisSpot != null)
        {
            cardInThisSpot.GetComponent<CardSystem>().MovementCard();
        }
    }

    public void ReciveCard(GameObject card)
    {
        cardInThisSpot = card;
        startUpdating = true;
    }
}
