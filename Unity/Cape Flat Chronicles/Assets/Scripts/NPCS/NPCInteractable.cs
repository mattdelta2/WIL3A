using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCInteractable : MonoBehaviour
{
    public string npcName; // The name of the NPC

    public NPCDialogues npcDialogues;

    public ChoiceManager choiceManager;
    public DialogueManager dialogueManager;

    public void Interact(DialogueManager dialogueManager )
    {
        // Check if the dialogue manager and npcDialogues are properly assigned
        if (dialogueManager != null && npcDialogues != null && npcDialogues.dialogues.Count > 0)
        {
            // Start the dialogue using the dialogue manager and the first dialogue in npcDialogues
            dialogueManager.StartDialogue(npcDialogues.dialogues[0]);

            // Optionally, show the choice panel if necessary
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
            // Log error messages if necessary components are missing
            if (dialogueManager == null)
            {
                Debug.LogError("DialogueManager not assigned in the Interact method.");
            }
            if (npcDialogues == null || npcDialogues.dialogues.Count == 0)
            {
                Debug.LogError("NPC dialogues not found or empty.");
            }
        }
    }
}
