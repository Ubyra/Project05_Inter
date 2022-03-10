using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_", menuName = "Scriptable Object/Create New NPC")]
public class NPCConfigs : ScriptableObject
{
    [Header("NPC Atributtes")]
    public string npcName;
    public Material npcMaterial;

    [Header("Dialogues")]
    public string[] firstDialogueOption;
    public string[] secondDialogueOption;
    public string[] thirdDialogueOption;
}
