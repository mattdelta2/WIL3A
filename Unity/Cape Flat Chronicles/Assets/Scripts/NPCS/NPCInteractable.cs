using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractable : MonoBehaviour
{
    public string npcName; // The name of the NPC

    public NPCDialogueManager dialogueManager;
    
    public ChoiceManager choiceManager;
 
    

    public void Interact()
    {
 
        

        // Call the DisplayDialogue method with this NPC's name
        if (dialogueManager != null)
        {
            dialogueManager.DiaplayDialogue(npcName);
            Debug.Log(npcName);

            if (choiceManager != null)
            {
                choiceManager.ShowChoicePanel();
                
            }
            else
            {
                Debug.LogError("ChoiceManager not found or not assigned in the Inspector.");
            }
        }
        else
        {
            Debug.LogError("NPCDialogueManager not found in the scene.");
        }
    }
}
