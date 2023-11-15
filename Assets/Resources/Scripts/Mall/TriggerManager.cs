using RMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public FootstepSound floorEnum;

    private const string playerTag = "Player";
    private const string footstepParameterName = "FloorType";

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            if (other.TryGetComponent(out PlayerMovement playerScript))
            {
                playerScript.PlayerFootsteps.setParameterByName(footstepParameterName, (float)floorEnum);

                Debug.Log($"Change audio to {floorEnum}");
            }
        }
    }
}
