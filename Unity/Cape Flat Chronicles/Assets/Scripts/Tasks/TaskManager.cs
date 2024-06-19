using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<Task> teacherTasks;
    public List<Task> gangMemberTasks;
    public Task currentTask;
    public FirstPersonController fpscontroller;
    public GameObject GangEnd;
    public GameObject EduEnd;

    [SerializeField] ConverSationStarter convoStarter;


    private void Start()
    {
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


    public void CompleteTask(string npcType)
    {
        if (currentTask != null && currentTask.isAccepted)
        {
            currentTask.isCompleted = true;
            currentTask.isAccepted = false;

            // Adjust status positively for completion
            if (npcType == "Teacher")
            {
                AddEducation();
            }
            else if (npcType == "GangMember")
            {
                AddGangStatus();
            }

            if (fpscontroller != null)
            {
                fpscontroller.RemoveTask(currentTask);
                Debug.Log($"Task Completed: {currentTask.taskName}");
            }
            else
            {
                Debug.LogError("fpsController is null. Ensure it's assigned correctly.");
            }

            currentTask = null; // Reset the current task
        }
        else
        {
            Debug.LogError("No task to complete or task was not accepted.");
        }
    }

    public void AddEducation()
    {
        fpscontroller.EducationStatus += 5;
        fpscontroller.GangStatus -= 5;
        if (fpscontroller.GangStatus <= 0)
        {
            fpscontroller.GangStatus = 0;
        }
    }

    public void AddGangStatus()
    {
        fpscontroller.GangStatus += 5;
        fpscontroller.EducationStatus -= 5;
        if (fpscontroller.EducationStatus <= 0)
        {
            fpscontroller.EducationStatus = 0;
        }
    }

    public void LogCurrentTasks()
    {
        if (fpscontroller.activeTasks.Count == 0)
        {
            Debug.Log("No active tasks.");
        }
        else
        {
            foreach (var task in fpscontroller.activeTasks)
            {
                Debug.Log($"Current task: {task.taskName} - {task.description}");
            }
        }
    }

    public void AcceptTask()
    {
        if (currentTask != null)
        {
            currentTask.isAccepted = true;
            fpscontroller.AddTask(currentTask);
            Debug.Log($"Task Accepted: {currentTask.taskName}");
        }
    }

    public void DeclineTask()
    {
        if (currentTask != null)
        {
            currentTask.isAccepted = false;

            if (currentTask != null)
            {
                if (gameObject.CompareTag("Teacher"))
                {
                    fpscontroller.EducationStatus -= 5;
                }
                else if (gameObject.CompareTag("GangMember"))
                {
                    fpscontroller.GangStatus -= 5;
                }
                Debug.Log($"Task Declined: {currentTask.taskName}");
            }
            
        }
    }

    public void EndGame()
    {
        if(fpscontroller.GangStatus == 20)
        {
            Time.timeScale = 0;
            GangEnd.SetActive(true);
            if (fpscontroller != null)
            {
                fpscontroller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }


        }
        else
            if(fpscontroller.EducationStatus ==20)
        {
            Time.timeScale = 0;

            EduEnd.SetActive(true);
            if (fpscontroller != null)
            {
                fpscontroller.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }
    }
}
