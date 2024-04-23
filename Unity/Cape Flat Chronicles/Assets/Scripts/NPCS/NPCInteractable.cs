using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractable : MonoBehaviour
{
    public string npcName; // The name of the NPC

    public NPCDialogueManager npcDialogues;
    
    public ChoiceManager choiceManager;
 
    
    /*
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
    }*/


    public void Interact(DialogueManager dialogueManager)
    {

        // Start the dialogue with the NPC's dialogues using the dialogue manager
        if (npcDialogues != null && npcDialogues.dialogues.Count > 0)
        {
            dialogueManager.StartDialogue(npcDialogues.dialogues[0]);
        }
        else
        {
            Debug.LogError("NPC dialogues not found or empty.");
        }
    }
}
