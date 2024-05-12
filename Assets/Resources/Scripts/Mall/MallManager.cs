using FMOD.Studio;
using RMS;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class MallManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerManager playerManager;
    public GameObject keyCard;
    public GameObject radio;
    public GameObject[] introScreens;

    private EventInstance cityBackgroundSound;
    private int steps = 0;

    public void Start()
    {
        cityBackgroundSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.cityBackgroundAmbience);
        cityBackgroundSound.start();
        DataPersistenceSystem.LoadGame();
        SetLoadedPlayerData();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void SetLoadedPlayerData()
    {
        if (DataPersistenceSystem.playerModel != null)
        {
            playerManager.SetPlayerPosition(DataPersistenceSystem.playerModel.xPosition, DataPersistenceSystem.playerModel.yPosition, DataPersistenceSystem.playerModel.zPosition);
            playerManager.SetPlayerRotation(DataPersistenceSystem.playerModel.xPosition, DataPersistenceSystem.playerModel.yPosition, DataPersistenceSystem.playerModel.zPosition, DataPersistenceSystem.playerModel.wRotation);

            if (DataPersistenceSystem.playerModel.inventory.hasKeyCard)
                keyCard.SetActive(false);

            if (DataPersistenceSystem.playerModel.inventory.hasRadio)
                radio.SetActive(false);

            if (DataPersistenceSystem.playerModel.isNewGame)
            {
                playerMovement.enabled = false;
                introScreens[0].transform.parent.gameObject.SetActive(true);
                StartCoroutine(MallIntro());
            }
        }
    }

    public void SetLoadedMallData()
    {

    }

    public IEnumerator MallIntro()
    {
        ShowCurrentStep();

        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKeyDown(KeyCode.Mouse1));        

        steps++;
        StartCoroutine(MallIntro());
    }

    private void ShowCurrentStep()
    {
        if (steps > introScreens.Length)
            return;

        if (steps == introScreens.Length)
        {
            DataPersistenceSystem.playerModel.isNewGame = false;
            DataPersistenceSystem.SaveGame();
            introScreens[0].transform.parent.gameObject.SetActive(false);
            playerMovement.enabled = true;
        }

        for (int index = 0; index < introScreens.Length; index++)
            introScreens[index].SetActive(index == steps);
    }
}
