using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string speakerName; // The name of the speaker (e.g., NPC or player)
    public string dialogueText; // The dialogue text

    // List of player responses (optional)
    public List<string> playerResponses;

    // List of next dialogues for branching (optional)
    public List<Dialogue> nextDialogues;
}
