using FMODUnity;
using RMS;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public DoorSound doorType;

    private const string isDoorOpenName = "isDoorOpen";
    private const string doorTypeParameter = "DoorStatus";

    public void ChangeDoorAnimation()
    {
        if (gameObject.name == "Door.040" && !QuestModel.route[0])
            return;

        if (TryGetComponent(out Animator animator))
        {
            bool isOpen = !animator.GetBool(isDoorOpenName);
            animator.SetBool(isDoorOpenName, isOpen);

            GetDoorSound(out EventReference reference);

            AudioManager.instance.PlayOneShot(reference, transform.position, doorTypeParameter, isOpen ? 1 : 0);
        }
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
