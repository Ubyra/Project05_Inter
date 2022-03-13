using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MouseSelector
{
    private static Ray mouseRay => Camera.main.ScreenPointToRay(Input.mousePosition);

    public static Ray GetMouseRay()
    {
        return mouseRay;
    }

    public static Collider HitCollider()
    {
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, 100.0f))
        {
            return hit.collider;
        }
        else return null;
    }
}
