using RMS;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SecurityRoutineQuest : MonoBehaviour
{
    public int buttonIndex;

    public void Start()
    {
        if(DataPersistenceSystem.playerModel != null)
            if (DataPersistenceSystem.playerModel.quest.route != null)
                for (int index = 0; index < DataPersistenceSystem.playerModel.quest.route?.Length; index++)
                {
                    if (DataPersistenceSystem.playerModel.quest.route[index])
                    {
                        foreach (Light light in transform.GetComponentsInChildren<Light>())
                            if(index == buttonIndex)
                                light.color = new Color(0, 0.5f, 0);
                    }
                }
    }

    /// <summary>
    /// Complete a item of the route
    /// </summary>
    public void OnPressRoutineButton()
    {
        bool[] route = DataPersistenceSystem.playerModel.quest.route;

        if (buttonIndex < 0 || buttonIndex >= route.Length)
        {
            Debug.LogWarning($"[SecurityRoutineQuest] OnPressRoutineButton - index: {buttonIndex}");
        }
        else if (route[buttonIndex])
        {
            return;
        }
        else
        {
            route[buttonIndex] = true;

            AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, transform.position);
        }
    }
}
