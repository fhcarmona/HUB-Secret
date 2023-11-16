using RMS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject endingScreen;
    public PlayerMovement playerScript;

    public void OnTriggerEnter()
    {
        if (QuestModel.route[0] && QuestModel.route[1] && QuestModel.route[2] && QuestModel.route[3] && QuestModel.route[4] && QuestModel.route[5])
            StartCoroutine(DemoComplete());
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
