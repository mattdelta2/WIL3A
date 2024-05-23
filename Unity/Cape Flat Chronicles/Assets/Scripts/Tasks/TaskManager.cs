using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<Task> teacherTasks;
    public List<Task> gangMemberTasks;

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


    public void CompleteTask(Task task)
    {
        task.isCompleted = true;
    }

    public void AcceptTask(Task task)
    {
        task.isAccepted = true;
    }

    public void DeclineTask(Task task)
    {
        task.isAccepted = false;
    }
}
