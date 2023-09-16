using RMS;
using UnityEngine;

public class MallManager : MonoBehaviour
{
    private PlayerManager playerManager;

    public void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    public void Start()
    {
        DataPersistenceSystem.LoadGame();
        SetLoadedPlayerData();
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
