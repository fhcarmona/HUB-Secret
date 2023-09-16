using RMS;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }

    public Quaternion GetPlayerRotation()
    {
        return player.transform.rotation;
    }

    public void SetPlayerPosition(float xAxis, float yAxis, float zAxis)
    {
        player.transform.position = new Vector3(xAxis, yAxis, zAxis);
    }
    public void SetPlayerRotation(float xAxis, float yAxis, float zAxis, float wAxis)
    {
        player.transform.rotation = new Quaternion(xAxis, yAxis, zAxis, wAxis);
    }
}
