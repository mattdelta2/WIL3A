using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Unity.VisualScripting;

public class ConverSationStarter : MonoBehaviour
{
    private FirstPersonController fpsController;
    private TaskManager taskManager;

    public NPCConversation[] myconvo;
    public int convoUp = 0;


    private void Start()
    {
        fpsController = FindObjectOfType<FirstPersonController>();
        taskManager = FindObjectOfType<TaskManager>();
        Cursor.visible = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fpsController != null && (Input.GetKeyDown(KeyCode.F) || (Input.GetKeyDown(KeyCode.E))))
            {
                ConversationManager.Instance.StartConversation(myconvo[convoUp]);
                Cursor.visible = true;

                convoUp++;
                if (convoUp >= myconvo.Length)
                {
                    convoUp = myconvo.Length - 1;
                }
                fpsController.canMove = false;
            }
        }
    }

    private void StartConversation()
    {
        ConversationManager.Instance.StartConversation(myconvo[convoUp]);
        Cursor.visible = true;
        fpsController.canMove = false;

        //inscreasing the conversation Index for next Interaction
        convoUp++;
        if(convoUp >= myconvo.Length)
        {
            convoUp = myconvo.Length - 1; //stays at last Convo if no more Conversations are available
        }
    }

    /*

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Check if fpsController is not null before attempting to access its properties
            if (fpsController != null && (Input.GetKeyDown(KeyCode.F) || (Input.GetKeyDown(KeyCode.E))))
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

    }*/
    //On trigger enter does not work for interacting with NPCs


    public  void EndConversation()
    {
        if(fpsController!= null)
        {
            fpsController.canMove = true;
            Cursor.visible = false;
        }
    }


    public void OfferTask(string npcType)
    {
        List<Task> tasksToCheck = npcType == "Teacher" ? taskManager.teacherTasks : taskManager.gangMemberTasks;
        foreach (var task in tasksToCheck)
        {
            if (!task.isAccepted && !task.isCompleted)
            {
                taskManager.currentTask = task;
                break;
            }
        }
    }

    public void AcceptTask()
    {
        taskManager.AcceptTask();
    }


    public void DeclineTask()
    {
        taskManager.DeclineTask();
    }

    public void AddEducation()
    {
        fpsController.EducationStatus += 5;
        fpsController.GangStatus -= 5;
        if(fpsController.GangStatus <= 0)
        {
            fpsController.GangStatus = 0;

        }

    }

    public void AddGangStatus()
    {
        fpsController.GangStatus += 5;
        fpsController.EducationStatus -= 5;
        if(fpsController.EducationStatus <= 0)
        {
            fpsController.EducationStatus = 0;
        }

    }



    public void GranEduccationStatus()
    {
        fpsController.EducationStatus -= 5;

    }

    public void GranGangStatus()
    {
        fpsController.GangStatus -= 5;

    }



}
