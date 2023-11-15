using UnityEngine;
using FMOD.Studio;
using RMS;

public class PlayerMovement : MonoBehaviour
{
     // Private
    private Vector3 spawnPos;
    private Vector3 playerNewPos = Vector3.zero;
    private Camera playerCamera;

    private EventInstance playerFootsteps;

    private float lateralMovement = 0f;
    private float upDownMovement = 0f;
    private float walkSpeed = defaultSpeed;
    private float xMouseSensibility = 1.5f;
    private float zMouseSensibility = 1.5f;
    private bool isMoving = false;

    // Constant
    const string xKeyboardName = "Horizontal";
    const string zKeyboardName = "Vertical";
    const string xMouseName = "Mouse X";
    const string yMouseName = "Mouse Y";
    const float defaultSpeed = 5.0f;
    const float minViewAngle = -60.0f;
    const float maxViewAngle = 45.0f;

    public float DefaultSpeed
    {
        get { return defaultSpeed; }
    }

    public bool IsMoving
    {
        get { return isMoving; }
    }

    public EventInstance PlayerFootsteps
    {
        get { return playerFootsteps; }
        set { playerFootsteps = value; }
    }

    private void Start()
    {
        playerCamera = transform.GetComponentInChildren<Camera>();
        spawnPos = transform.position;
        playerFootsteps = AudioManager.instance.CreateEventInstance(FMODEvents.instance.walkingPlayer);
    }

    private void FixedUpdate()
    {
        PlayerIsMoving();
        MovePlayer();
        UpdateSound();
    }

    private void LateUpdate()
    {
        MouseLook();
    }

    /// <summary>
    /// Translate the player by keyboard input. Multiply by walk speed.
    /// </summary>
    private void MovePlayer()
    {
        if (isMoving)
        {
            playerNewPos.x = Input.GetAxis(xKeyboardName) * walkSpeed;
            playerNewPos.z = Input.GetAxis(zKeyboardName) * walkSpeed;

            transform.Translate(playerNewPos * Time.deltaTime);

            CheckOutboundPos();
        }
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

    public void PlayerIsMoving()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            isMoving = true;
        else
            isMoving = false;
    }

    public void ChangeVelocity(float velocity)
    {
        walkSpeed = velocity;
    }

    public void UpdateSound()
    {
        if (isMoving)
        {
            playerFootsteps.getPlaybackState(out PLAYBACK_STATE playerbackState);

            if (playerbackState.Equals(PLAYBACK_STATE.STOPPED))
                playerFootsteps.start();
        }
        else
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}
