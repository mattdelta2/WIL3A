using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public string npcName; // The name of the NPC

    public NPCDialogueManager dialogueManager;

    public void Interact()
    {
        

        // Call the DisplayDialogue method with this NPC's name
        if (dialogueManager != null)
        {
            dialogueManager.DiaplayDialogue(npcName);
            Debug.Log(npcName);
        }
        else
        {
            Debug.LogError("NPCDialogueManager not found in the scene.");
        }
    }
}
