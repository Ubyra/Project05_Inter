using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChecker : MonoBehaviour
{
    public float radiusCheck;
    public LayerMask NPCLayer;
    public NPCSystem closestNPC;

    private void Update()
    {
        CheckArround();
    }

    public void DisplayNPCCanvas(bool active)
    {
        if (closestNPC == null)
            return;

        closestNPC.interactionCanvas.SetActive(active);
    }

    private void CheckArround()
    {
        Collider[] arround = Physics.OverlapSphere(transform.position, radiusCheck, NPCLayer);


        if (arround.Length > 0)
        {
            for (int i = 0; i < arround.Length; i++)
            {
                if (closestNPC == null)
                {
                    closestNPC = arround[i].GetComponent<NPCSystem>();
                }

                if (Vector3.Distance(transform.position, arround[i].transform.position) < Vector3.Distance(transform.position, closestNPC.transform.position))
                {
                    DisplayNPCCanvas(false);
                    closestNPC = arround[i].GetComponent<NPCSystem>();
                }
            }

            DisplayNPCCanvas(true);
        }
        else
        {
            if (closestNPC != null)
                DisplayNPCCanvas(false);

            closestNPC = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusCheck);
    }
}