using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    // Private
    private Vector3 spawnPos;
    private Vector3 playerNewPos = Vector3.zero;
    private Camera playerCamera;
    
    private float lateralMovement = 0f;
    private float upDownMovement = 0f;
    private float walkSpeed = 3.5f;
    private float xMouseSensibility = 1.5f;
    private float zMouseSensibility = 1.5f;

    // Constant
    const string xKeyboardName = "Horizontal";
    const string zKeyboardName = "Vertical";
    const string xMouseName = "Mouse X";
    const string yMouseName = "Mouse Y";
    const float minViewAngle = -60.0f;
    const float maxViewAngle = 45.0f;

    private bool canMove = true;

    private void Start()
    {
        playerCamera = transform.GetComponentInChildren<Camera>();
        spawnPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
            canMove = !canMove;

        if (canMove)
        {
            MovePlayer();
        }
    }

    private void LateUpdate()
    {
        if (canMove)
        {
            MouseLook();
            CheckOutboundPos();
        }
    }

    /// <summary>
    /// Translate the player by keyboard input. Multiply by walk speed.
    /// </summary>
    private void MovePlayer()
    {
        playerNewPos.x = Input.GetAxis(xKeyboardName) * walkSpeed;
        playerNewPos.z = Input.GetAxis(zKeyboardName) * walkSpeed;

        transform.Translate(playerNewPos * Time.deltaTime);
    }

    /// <summary>
    /// Rotate the player and camera by mouse movement. Multiply by mouse sensibility.
    /// </summary>
    private void MouseLook()
    {
        upDownMovement -= Input.GetAxis(yMouseName) * xMouseSensibility;
        upDownMovement = Mathf.Clamp(upDownMovement, minViewAngle, maxViewAngle);
        lateralMovement += Input.GetAxis(xMouseName) * zMouseSensibility;

        transform.eulerAngles = new Vector3(0f, lateralMovement, 0f);
        playerCamera.transform.eulerAngles = new Vector3(upDownMovement, lateralMovement, 0f);
    }

    /// <summary>
    /// Move the player to spawn position when out of bounds.
    /// </summary>
    private void CheckOutboundPos()
    {
        if (transform.position.y < -5)
            transform.position = spawnPos;
    }
}
