using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task 
{

    public string taskName;
    public string description;
    public bool isCompleted;
    public bool isAccepted;



    public Task(string name, string desc)
    {

        taskName = name;
        description = desc;
        isCompleted = false;
        isAccepted = false;
    }
}
