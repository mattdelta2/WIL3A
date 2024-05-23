using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{

    private FirstPersonController fpscontroller;

    public TaskManager taskManager;

    public void CompleteTask(Task task, string npctype)
    {
        taskManager.CompleteTask(task);

        if(npctype == "Teacher")
        {
            fpscontroller.EducationStatus++;
        }
        else if(npctype == "GangMember")
        {
            fpscontroller.GangStatus++;
        }
    }

    public void DeclineTask(Task task, string npctype)
    {

        if(npctype == "Teacher")
        {
            fpscontroller.EducationStatus--;
        }
        else if(npctype == "GangMember")
        {
            fpscontroller.GangStatus--;
        }
    }
    
    
}
