using RMS;
using UnityEngine;

public class SecurityRoutineQuest : MonoBehaviour
{
    public int buttonIndex;

    /// <summary>
    /// Complete a item of the route
    /// </summary>
    public void OnPressRoutineButton()
    {        
        if (buttonIndex < 0 || buttonIndex >= QuestModel.route.Length)
        {
            Debug.LogWarning($"[SecurityRoutineQuest] OnPressRoutineButton - index: {buttonIndex}");
        }
        else
        {
            QuestModel.route[buttonIndex] = true;

            AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, transform.position);
        }
    }
}
