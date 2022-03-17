using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHighlight : MonoBehaviour, IHighlightSelection
{
    [Range(1, 2)] public float scaleFactor;
    public Vector3 startScale;
    private Vector3 newScale;
    private bool isHighlighed;

    public void HighlightInitialize(Transform selection)
    {
        startScale = selection.localScale;
    }

    public void OnHighlight(Transform selection)
    {
        newScale = startScale * scaleFactor;

        if(!isHighlighed) selection.transform.localScale = newScale;
        isHighlighed = true;
    }

    public void OnDehighlight(Transform selection)
    {
        newScale = startScale;

        if(isHighlighed) selection.transform.localScale = newScale;
        isHighlighed = false;
    }
}