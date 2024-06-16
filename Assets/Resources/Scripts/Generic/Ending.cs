using RMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject endingScreen;
    public PlayerMovement playerScript;
    public DoorController doorController;

    public void OnTriggerEnter()
    {
        bool[] route = DataPersistenceSystem.playerModel.quest.route;
        bool artifact = DataPersistenceSystem.playerModel.inventory.hasArtifact;
        QuestModel artifactQuest = DataPersistenceSystem.playerModel.quest;

        Debug.Log($"{route[0]} && {route[1]} && {route[2]} && {route[3]} && {route[4]} && {route[5]} && {artifact}");

        if (route[0] && route[1] && route[2] && route[3] && route[4] && route[5])
        {
            if (artifact)
            {
                StartCoroutine(DemoComplete());
            }
            else
            {
                if (!artifactQuest.artifactNotification)
                {
                    doorController.isLocked = false;
                    doorController.ChangeDoorAnimation();
                }

                artifactQuest.artifactNotification = true;
                DataPersistenceSystem.playerModel.quest = artifactQuest;
            }
        }
    }

    IEnumerator DemoComplete()
    {
        endingScreen.SetActive(true);
        playerScript.enabled = false;
        AudioManager.instance.CleanUp();        

        yield return new WaitForSeconds(5);

        Application.Quit();
    }
}
