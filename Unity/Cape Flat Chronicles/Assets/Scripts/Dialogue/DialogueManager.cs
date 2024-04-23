using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue currentDialogue; // Current dialogue being displayed

    // Method to start a conversation with a given dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        // Notify ChoiceManager or other scripts to display the dialogue
        DialogueStarted(currentDialogue);
    }

    // Method to progress to the next dialogue entry
    public bool ProgressDialogue()
    {
        // Check if there are next dialogues to progress to
        if (currentDialogue != null && currentDialogue.nextDialogues != null && currentDialogue.nextDialogues.Count > 0)
        {
            // Progress to the next dialogue entry
            currentDialogue = currentDialogue.nextDialogues[0];
            // Notify ChoiceManager or other scripts to display the next dialogue
            DialogueStarted(currentDialogue);
            return true;
        }
        else
        {
            // End the conversation
            EndDialogue();
            return false;
        }
    }

    // Method to handle the end of a conversation
    private void EndDialogue()
    {
        // Notify other scripts that the dialogue has ended (e.g., ChoiceManager)
        DialogueEnded();
    }

    // Event methods for communicating with other scripts (e.g., ChoiceManager)
    protected virtual void DialogueStarted(Dialogue dialogue) { }
    protected virtual void DialogueEnded() { }
}
