using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Animator))]
public class ClawMachineController : MonoBehaviour
{
    public Vector3 resetPosition;
    
    public bool cpuMove = false;
    public bool isScaling = false;
    private Transform clawParent;

    public bool hasGrabbed;
    public GameObject clawSupport;
    public GameObject armature;    
    public PlayerMovement playerMovement;

    public Vector3 GetClawParentLocalPos
    {
        get { return clawParent.localPosition; }
    }

    enum MoveType
    {
        Down = 5,
        Back = 8,
        Left = 4,
        Forward = 2,
        Right = 6
    }

    public void Awake()
    {
        clawParent = clawSupport.transform.parent;
        resetPosition = clawParent.localPosition;
    }

    public void Update()
    {
        if (playerMovement.isPaused)
            return;

        if(Input.GetKeyDown(KeyCode.G))
            playerMovement.enabled = !playerMovement.isActiveAndEnabled;

        if (!playerMovement.isActiveAndEnabled && !cpuMove && !isScaling)
        {
            // Pickup
            if (Input.GetKeyDown(KeyCode.Space) && !hasGrabbed)
            {
                StartCoroutine(MoveClawUpDown());
            }
            // Left
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
            {
                StartCoroutine(MoveClawLeftRight(true));
            }
            // Right
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
            {
                StartCoroutine(MoveClawLeftRight(false));
            }
            // Forward
            else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
            {
                StartCoroutine(MoveClawBackForward(false));
            }
            // Back
            else if (((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))))
            {
                StartCoroutine(MoveClawBackForward(true));
            }
        }
    }

    public IEnumerator MoveClawLeftRight(bool isLeft = false, UnityAction<bool> onCompleted = default)
    {
        float speed = isLeft ? -0.01f : 0.01f;

        // Parent Position
        Vector2 minMaxPos = new Vector2(-0.1f, 0.4f);
        Vector3 clawLocalPosition = new Vector3(clawParent.localPosition.x, clawParent.localPosition.y, clawParent.localPosition.z);

        if (isLeft && clawLocalPosition.x == minMaxPos.x || !isLeft && clawLocalPosition.x == minMaxPos.y)
            yield break;
        clawLocalPosition.x = clawParent.localPosition.x + speed;
        clawLocalPosition.x = Mathf.Clamp(clawLocalPosition.x, minMaxPos.x, minMaxPos.y);

        clawParent.localPosition = clawLocalPosition;

        yield return new WaitForEndOfFrame();
    }

    public IEnumerator MoveClawBackForward(bool isBack = false)
    {
        float speed = isBack ? -0.01f : 0.01f;

        // Parent Position
        Vector2 minMaxPos = new Vector2(-0.3f, 0.1f);
        Vector3 clawLocalPosition = new Vector3(clawParent.localPosition.x, clawParent.localPosition.y, clawParent.localPosition.z);

        if (isBack && clawLocalPosition.z == minMaxPos.x || !isBack && clawLocalPosition.z == minMaxPos.y)
            yield break;

        clawLocalPosition.z = clawParent.localPosition.z + speed;
        clawLocalPosition.z = Mathf.Clamp(clawLocalPosition.z, minMaxPos.x, minMaxPos.y);

        clawParent.localPosition = clawLocalPosition;

        yield return new WaitForEndOfFrame();
    }

    public IEnumerator MoveClawUpDown(bool inverted = false)
    {
        float clawScaleSpeed = inverted ? -10f : 10f;
        float armatureHeightSpeed = inverted ? 0.01f : -0.01f;

        isScaling = true;

        // Support Scale
        Vector2 minMaxScale = new Vector2(100, 800);
        Vector3 clawVector = new Vector3(clawSupport.transform.localScale.x, clawSupport.transform.localScale.y, clawSupport.transform.localScale.z);

        // Claw position
        Vector2 minMaxPos = new Vector2(0.08f, 0.80f);
        Vector3 armatureVector = new Vector3(armature.transform.localPosition.x, armature.transform.localPosition.y, armature.transform.localPosition.z);

        do
        {
            clawVector.z = clawSupport.transform.localScale.z + clawScaleSpeed;
            clawVector.z = Mathf.Clamp(clawVector.z, minMaxScale.x, minMaxScale.y);

            clawSupport.transform.localScale = clawVector;

            armatureVector.y = armature.transform.localPosition.y + armatureHeightSpeed;
            armatureVector.y = Mathf.Clamp(armatureVector.y, minMaxPos.x, minMaxPos.y);

            armature.transform.localPosition = armatureVector;

            yield return new WaitForEndOfFrame();

        } while (clawVector.z != minMaxScale.x && clawVector.z != minMaxScale.y);

        if (inverted)
        {
            isScaling = false;
            yield break;
        }

        // Inverse movement
        StartCoroutine(MoveClawUpDown(true));
    }

    public IEnumerator MoveClawTo(Vector3 localPosition = default)
    {
        if (localPosition.Equals(default))
            localPosition = resetPosition;

        clawParent.localPosition = Vector3.MoveTowards(clawParent.localPosition, localPosition, 0.01f);
        yield return new WaitForEndOfFrame();
    }
}
