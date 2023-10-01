using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairModifier : MonoBehaviour
{
    private const float slowDownVelocity = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            player.ChangeVelocity(slowDownVelocity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            player.ChangeVelocity(player.DefaultSpeed);
        }
    }
}
