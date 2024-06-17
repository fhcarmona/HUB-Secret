using System.Collections;
using UnityEngine;

public class ClawGrabber : MonoBehaviour
{
    public Transform originPosition;
    public ClawMachineController clawMachineController;

    private Transform grabbedObject;
    private Rigidbody rb;
    private Collider clawCollider;
    private Vector3 finalPos;

    public void Start()
    {
        clawCollider = GetComponent<Collider>();
        finalPos = new Vector3(-0.1f, 0f, -0.4f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (grabbedObject != null)
            return;

        grabbedObject = other.transform;
        grabbedObject.position = originPosition.position;

        clawMachineController.hasGrabbed = true;

        if (grabbedObject.TryGetComponent(out rb))
            rb.isKinematic = true;

        grabbedObject.SetParent(transform);
        clawCollider.enabled = false;

        StartCoroutine(MoveClawToFinal());
    }

    public IEnumerator ResetCollider()
    {
        grabbedObject.parent = null;
        rb.isKinematic = false;
        clawMachineController.hasGrabbed = false;

        yield return new WaitForSecondsRealtime(1);
        
        grabbedObject = null;
        clawCollider.enabled = true;
    }

    public IEnumerator MoveClawToFinal()
    {
        clawMachineController.cpuMove = true;
        yield return new WaitUntil(() => !clawMachineController.isScaling);

        while (clawMachineController.GetClawParentLocalPos != finalPos)
        {            
            StartCoroutine(clawMachineController.MoveClawTo(finalPos));
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(ResetCollider());

        while (clawMachineController.GetClawParentLocalPos != clawMachineController.resetPosition)
        {
            StartCoroutine(clawMachineController.MoveClawTo());
            yield return new WaitForEndOfFrame();
        }

        clawMachineController.cpuMove = false;
        clawMachineController.ChangeCamera();
    }
}
