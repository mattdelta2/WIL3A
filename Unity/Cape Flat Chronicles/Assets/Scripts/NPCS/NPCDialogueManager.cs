using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueManager : MonoBehaviour
{
    //script should be needed

    [System.Serializable]
    public class NPC
    {
        public string npcName;
        public string[] dialogueLines;
    }

    public List<NPC> npcList = new List<NPC>();
    public PlayerStats playerStats;


    public void DiaplayDialogue(string npcName)
    {

        // Find the NPC in the list.
        NPC npc = npcList.Find(n => n.npcName == npcName);
        if (npc != null)
        {
            // Display the NPC's dialogue.
            foreach (string line in npc.dialogueLines)
            {
                Debug.Log(line);
                // Here you would add your code to display the dialogue line to the player.
            }
        }
        else
        {
            Debug.LogError("NPC not found!");
        }
    }

    
    

}



