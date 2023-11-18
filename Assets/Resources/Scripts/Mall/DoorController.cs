using FMODUnity;
using RMS;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public DoorSound doorType;
    public bool isAutomatic;

    private const string isDoorOpenName = "isDoorOpen";
    private const string doorTypeParameter = "DoorStatus";

    public void ChangeDoorAnimation()
    {
        bool[] route = DataPersistenceSystem.playerModel.quest.route;

        if (gameObject.name == "Door.040" && !route[0])
            return;

        if (TryGetComponent(out Animator animator))
        {
            bool isOpen = !animator.GetBool(isDoorOpenName);

            animator.SetBool(isDoorOpenName, isOpen);

            GetDoorSound(out EventReference reference);

            AudioManager.instance.PlayOneShot(reference, transform.position, doorTypeParameter, isOpen ? 1 : 0);

            if(isAutomatic)
                StartCoroutine(CloseDoorAutomatic(animator, isOpen));
        }
    }

    private IEnumerator CloseDoorAutomatic(Animator animator, bool isOpen)
    {
        yield return new WaitForSeconds(3);

        animator.SetBool(isDoorOpenName, !isOpen);

        GetDoorSound(out EventReference reference);

        AudioManager.instance.PlayOneShot(reference, transform.position, doorTypeParameter, isOpen ? 1 : 0);
    }

    private void GetDoorSound(out EventReference eventReference)
    {
        switch (doorType)
        {
            case DoorSound.GLASS:
                eventReference = FMODEvents.instance.glassDoor;
                break;
            case DoorSound.METAL:
                eventReference = FMODEvents.instance.metalDoor;
                break;
            case DoorSound.STEEL:
                eventReference = FMODEvents.instance.steelDoor;
                break;            
            default:
                eventReference = FMODEvents.instance.commonDoor;
                break;
        }
    }
}
