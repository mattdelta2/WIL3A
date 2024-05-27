using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{

    [Header("Movement Speeds")]

    [SerializeField] private float walkSpeed = 3f;

    [Header("Look Sensitivity")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float upDownRange = 80f;


    [Header("Input Custimisation")]
    [SerializeField] private string horizontalMoveInput = "Horizontal";
    [SerializeField] private string verticalMoveInput = "Vertical";

    [SerializeField] private string MouseXInput = "Mouse X";
    [SerializeField] private string MouseYInput = "Mouse Y";

    private Camera mainCamera;
    private float verticleRotation;
    private CharacterController characterController;

    public bool isInteractingWithNPC = false;
   


    //Task and Status Management
    public int EducationStatus = 0;
    public int GangStatus = 0;
    public bool canMove = true;
    public List<Task> activeTasks;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Attempt to find any Camera component in the scene
        mainCamera = FindObjectOfType<Camera>();

        // Check if mainCamera was successfully assigned
        if (mainCamera == null)
        {
            Debug.LogWarning("No Camera found in the scene. Please ensure a Camera is present and properly assigned.");
        }
        Cursor.visible = false;

        activeTasks = new List<Task>();
    }

    private void Update()
    {
        if ((canMove))
        {
            HandleMovement();
            HandleRotation();
        }
      //  HandleMovement();
       // HandleRotation();
    }

    void HandleMovement()
    {
        float verticleSpeed = Input.GetAxis(verticalMoveInput) * walkSpeed;
        float horizontalSpeed = Input.GetAxis(horizontalMoveInput) * walkSpeed; 

        Vector3 speed = new Vector3 (horizontalSpeed, 0, verticleSpeed);
        speed  = transform.rotation * speed;

        characterController.SimpleMove(speed);
    }

    void HandleRotation()
    {

        if (isInteractingWithNPC)
        {
            return;
            
        }
        // Check if the camera is not null
        if (mainCamera == null)
        {
            Debug.LogWarning("mainCamera is not assigned in FirstPersonController script.");
            return; // Return early if mainCamera is null to avoid exceptions
        }

        float mouseXRotation = Input.GetAxis(MouseXInput) * mouseSensitivity;
        transform.Rotate(0,mouseXRotation,0);

        verticleRotation -=Input.GetAxis(MouseYInput) * mouseSensitivity;
        verticleRotation = Mathf.Clamp(verticleRotation,-upDownRange,upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticleRotation,0,0);

    }


    public void Isinteracting()
    {
        isInteractingWithNPC = false;
        Cursor.visible = false ;
        
    }

    public void AddTask(Task newTask)
    {
        activeTasks.Add(newTask);
    }

    public void RemoveTask(Task completedTask)
    {
        activeTasks.Remove(completedTask);
    }

    public void LogCurrentTasks()
    {
        if (activeTasks.Count == 0)
        {
            Debug.Log("No active tasks.");
        }
        else
        {
            foreach (var task in activeTasks)
            {
                Debug.Log($"Current task: {task.taskName} - {task.description}");
            }
        }
    }

}
