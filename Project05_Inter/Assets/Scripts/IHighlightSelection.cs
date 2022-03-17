using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighlightSelection
{
    void HighlightInitialize(Transform selection);
    void OnHighlight(Transform selection);
    void OnDehighlight(Transform selection);
}