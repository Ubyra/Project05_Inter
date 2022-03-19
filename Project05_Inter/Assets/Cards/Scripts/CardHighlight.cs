using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlight : MonoBehaviour, IHighlightSelection
{
    [Range(1, 2)] public float scaleFactor;
    public Vector3 startScale;
    private Vector3 newScale;
    private bool isHighlighed;
    public Canvas Layer;

    public void HighlightInitialize(Transform selection)
    {
        startScale = selection.localScale;
    }

    public void OnHighlight(Transform selection)
    {
        newScale = startScale * scaleFactor;

        if (!isHighlighed)
        {
            Layer.sortingOrder = 1;
            selection.transform.localScale = newScale;
        }
        isHighlighed = true;
    }

    public void OnDehighlight(Transform selection)
    {
        newScale = startScale;

        if (isHighlighed)
        {
            Layer.sortingOrder = 0;
            selection.transform.localScale = newScale;
        }
        isHighlighed = false;
    }
}