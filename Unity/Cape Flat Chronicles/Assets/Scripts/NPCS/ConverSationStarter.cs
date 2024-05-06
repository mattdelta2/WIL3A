using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConverSationStarter : MonoBehaviour
{
    private FirstPersonController fpsController;


    [SerializeField] private NPCConversation myconvo;

    private void Start()
    {
        // Assign fpsController to the FirstPersonController component on the player object
        fpsController = FindObjectOfType<FirstPersonController>();

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
                Cursor.visible = true;
                fpsController.isInteractingWithNPC = true;
                ConversationManager.Instance.StartConversation(myconvo);
            }
        }
    }


}
