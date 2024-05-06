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
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
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
        //mainCamera.transform.localRotation = Quaternion.Euler(verticleRotation,0,0);

    }


    public void Isinteracting()
    {
        isInteractingWithNPC = false;
        Cursor.visible = false ;
        
    }

}
