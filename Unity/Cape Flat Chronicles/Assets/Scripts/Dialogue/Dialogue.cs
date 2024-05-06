using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewNPCDialogues", menuName = "Dialogue/NPCDialogues")]
public class NPCDialogues : ScriptableObject
{
    public List<Dialogue> dialogues; // List of dialogues for this NPC

    [System.Serializable]
    public class Dialogue
    {
        public string speakerName; // Name of the speaker (NPC or player)
        public string dialogueText; // Dialogue text
        public List<Dialogue> nextDialogues; // Next dialogue entries for branching
    }
}
