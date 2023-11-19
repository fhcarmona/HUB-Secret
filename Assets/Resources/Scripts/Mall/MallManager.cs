using FMOD.Studio;
using RMS;
using UnityEngine;

public class MallManager : MonoBehaviour
{
    public PlayerManager playerManager;
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
        }
    }

    public void SetLoadedMallData()
    {

    }
}
