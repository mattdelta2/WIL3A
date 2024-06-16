using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAtPlayer : MonoBehaviour
{
    public Transform player; // Assign the player's transform in the Inspector
    public float rotationSpeed = 10.0f; // Speed at which the NPC rotates to face the player

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag if not assigned
        }
    }

    public void LookAtPlayer()
    {
        if (player == null) return;

       
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Keep the rotation only on the y-axis
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
