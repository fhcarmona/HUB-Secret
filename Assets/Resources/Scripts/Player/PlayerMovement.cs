using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 3.0f;
    [SerializeField]
    private float xMouseSensibility = 50.0f;
    [SerializeField]
    private float zMouseSensibility = 50.0f;
    private float maxDistance = 2.0f;

    private Camera playerCamera;

    // Constant
    const string xKeyboardName = "Horizontal";
    const string zKeyboardName = "Vertical";

    const string xMouseName = "Mouse X";
    const string yMouseName = "Mouse Y";

    private void Start()
    {
        playerCamera = transform.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        Look();
        CheckOutboundPos();
        InteractiveRay();
    }

    // Player movement
    private void MovePlayer()
    {
        float xMovement = Input.GetAxis(xKeyboardName);
        float zMovement = Input.GetAxis(zKeyboardName);

        Vector3 newPos = new Vector3(xMovement, 0, zMovement);

        transform.Translate(newPos * walkSpeed * Time.deltaTime);
    }

    // Player look
    private void Look()
    {
        float xMouse = Input.GetAxis(xMouseName) * xMouseSensibility;
        float yMouse = Input.GetAxis(yMouseName) * zMouseSensibility;

        playerCamera.transform.eulerAngles += new Vector3(-yMouse, xMouse, 0) * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, xMouse, 0) * Time.deltaTime;
    }

    // Interactive range
    private void InteractiveRay()
    {
        Vector3 drawRayDistance = Vector3.forward * maxDistance;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        int ignoredLayer = ~LayerMask.GetMask("Player");

        Debug.DrawRay(playerCamera.transform.position, drawRayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, maxDistance, ignoredLayer))
        {
            
        }
    }

    // Outbound check
    private void CheckOutboundPos()
    {
        if (transform.position.y < -5)
            transform.position = Vector3.zero;
    }
}
