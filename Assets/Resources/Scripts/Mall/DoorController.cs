using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private const string isDoorOpenName = "isDoorOpen";

    public void ChangeDoorAnimation()
    {
        if (TryGetComponent(out Animator animator))
            animator.SetBool(isDoorOpenName, !animator.GetBool(isDoorOpenName));
    }
}
