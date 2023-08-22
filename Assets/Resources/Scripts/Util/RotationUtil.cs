using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RotationUtil
{
    private const Space defaultSpace = Space.World;

    private const int defaultSpeed = 1;
    private const bool defaultX = true;
    private const bool defaultY = true;
    private const bool defaultZ = true;

    public static void IncrementalRotate(GameObject obj, Space relativeTo, float velocity, bool rotateX, bool rotateY, bool rotateZ)
    {
        Vector3 newRotation = Vector3.one;

        if (!rotateX)
            newRotation.x = 0;

        if (!rotateY)
            newRotation.y = 0;

        if (!rotateZ)
            newRotation.z = 0;

        if(obj != null)
            obj.transform.Rotate(newRotation * velocity, relativeTo);
    }

    public static void IncrementalRotate(GameObject obj, bool rotateX = defaultX, bool rotateY = defaultY, bool rotateZ = defaultZ)
    {
        IncrementalRotate(obj, defaultSpace, defaultSpeed, rotateX, rotateY, rotateZ);
    }

    public static void IncrementalRotate(GameObject obj, Space relativeTo)
    {
        IncrementalRotate(obj, relativeTo, defaultSpeed, defaultX, defaultY, defaultZ);
    }

    public static void IncrementalRotate(GameObject obj, float velocity)
    {
        IncrementalRotate(obj, defaultSpace, velocity, defaultX, defaultY, defaultZ);
    }
}
