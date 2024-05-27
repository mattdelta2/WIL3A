using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using Unity.VisualScripting;

public class ConverSationStarter : MonoBehaviour
{
    public FirstPersonController fpsController;



     public NPCConversation[] myconvo;
    public int convoUp = 0;

    //Task Management
    public List<Task> teacherTasks;
    public List<Task> gangMemberTasks;
    public Task currentTask;


    private void Start()
    {
        // Assign fpsController to the FirstPersonController component on the player object
        fpsController = FindObjectOfType<FirstPersonController>();
        Cursor.visible = false;
        teacherTasks = new List<Task>
        {
            new Task("Collect Homework", "Collect homework from a fellow class mate"),

            new Task("Tell student to come to class", "Students are not showing up to class, Please find them and tell them to come back to class"),

            new Task("Help students with work", "A student is not coping with the work, please can you explain how to do the work")

        };
        gangMemberTasks = new List<Task>
        {
            new Task("Fetch Gwaai", "Find and bring the gwaais to the gang member"),

            new Task("Deliver a message", "Deliver a message to another gang member"),

            new Task("Find a package", "Find a package and deliver back to gang leader"),

            new Task("Take this package", "Deliver a package to another gang member")
        };

    }
    
    private void OnTriggerStay(Collider other)
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
                // Determine the NPC type and offer task accordingly
                string npcType = gameObject.CompareTag("Teacher") ? "Teacher" : "GangMember";
              
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
        //offers first available task that is not completed
        List<Task> tasksToCheck = npcType == "Teacher" ? teacherTasks : gangMemberTasks;
        foreach (var task in tasksToCheck)
        {
            if (!task.isAccepted && !task.isCompleted)
            {
                task.isAccepted = true; // Mark the task as accepted
               fpsController.activeTasks.Add(task); // Add the task to the activeTasks list
                Debug.Log($"Accepted task: {task.taskName} - {task.description}");
                break;
            }
        }
    }

    public void AcceptTask()
    {
        if(currentTask != null)
        {
            currentTask.isCompleted = true;
            fpsController.AddTask(currentTask);
        }
    }

    public void DeclineTask()
    {
        if(currentTask != null)
        {
            currentTask.isCompleted = false;

            if (gameObject.CompareTag("Teacher"))
            {
                fpsController.EducationStatus -= 5;
            }
            else if( gameObject.CompareTag("GangMember"))
            {
                fpsController.GangStatus -= 5;
            }
            EndConversation();

        }
    }

    public void CompleteTask(string npcType)
    {
        if (currentTask != null)
        {
            currentTask.isCompleted = true;
            fpsController.RemoveTask(currentTask);
            List<Task> tasksToCheck = npcType == "Teacher" ? teacherTasks : gangMemberTasks;

            // Adjust status positively for completion
            if (gameObject.CompareTag("Teacher"))
            {
                AddEducation();
                Debug.Log($"Accepted task: {task.taskName} - {task.description}");
            }
            else if (gameObject.CompareTag("GangMember"))
            {
                Debug.Log($"Accepted task: {task.taskName} - {task.description}");

                AddGangStatus();
            }

            currentTask = null; // Reset the current task
        }
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

    public void StartTask()
    {

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
