using FMOD.Studio;
using RMS;
using UnityEngine;

public class MallManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject keyCard;
    public GameObject radio;
    private EventInstance cityBackgroundSound;

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
        }
    }

    public void SetLoadedMallData()
    {

    }
}
