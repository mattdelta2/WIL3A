using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConverSationStarter : MonoBehaviour
{
    public FirstPersonController fpsController;



     public NPCConversation[] myconvo;
    public int convoUp = 0;


    private void Start()
    {
        // Assign fpsController to the FirstPersonController component on the player object
        fpsController = FindObjectOfType<FirstPersonController>();
        Cursor.visible = false;

        // Check if the fpsController reference is successfully assigned
        if (fpsController == null)
        {
            Debug.LogWarning("FirstPersonController not found. Make sure a FirstPersonController component is attached to the player.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if fpsController is not null before attempting to access its properties
            if (fpsController != null && Input.GetKeyDown(KeyCode.F))
            {
                // Start the conversation using the current conversation from the array
                ConversationManager.Instance.StartConversation(myconvo[convoUp]);
                Cursor.visible = true;

                // Increment the conversation index for the next interaction
                convoUp++;

                // Ensure the conversation index doesn't go out of bounds
                if (convoUp >= myconvo.Length)
                {
                    convoUp = myconvo.Length - 1; // Stay at the last conversation if we've reached the end
                }
                fpsController.canMove = false;
            }
        }
    }

    public  void EndConversation()
    {
        if(fpsController!= null)
        {
            fpsController.canMove = true;
            Cursor.visible = false;
        }
    }



}
