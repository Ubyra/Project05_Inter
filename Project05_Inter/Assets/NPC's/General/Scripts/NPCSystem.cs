using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{
    public GameObject interactionCanvas;
    public NPCConfigs configs;
    private MeshRenderer myMaterial;

    private void Awake()
    {
        myMaterial = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        myMaterial.material = configs.npcMaterial;
    }
}
