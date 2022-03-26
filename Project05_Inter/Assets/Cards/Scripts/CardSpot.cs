using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpot : MonoBehaviour
{
    [Header("Spot Atributes")]
    public int spotOrder;
    public Collider col;
    public Transform modelTransform;

    public MatchSystem matchSystem;

    private void Update()
    {
        if(MouseSelector.HitCollider() == col && Input.GetMouseButton(0))
        {
            //matchSystem.clickedSpot = this;
        }
    }
}
