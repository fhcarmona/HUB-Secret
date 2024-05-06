using RMS;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject managers;
    public GameObject menuOptions;
    public GameObject inventory;
    public GameObject keyCardInventory;
    public GameObject radioInventory;
    public GameObject clipboardInventory;

    private const string MainMenuSceneName = "MainMenu";
    private const string MallSceneName = "Mall";

    private PlayerManager playerManager;

    public void Awake()
    {
        playerManager = managers.GetComponentInChildren<PlayerManager>();
    }

    public void Update()
    {
        OpenInGameMenu();
    }

    public void OpenInGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;

            menuOptions.gameObject.SetActive(!menuOptions.gameObject.activeSelf);
            inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
            playerMovement.isPaused = menuOptions.activeSelf;

            UpdateInventoryImages(DataPersistenceSystem.playerModel.inventory);
        }
    }

    public void OnClickSaveGame()
    {   
        Vector3 playerPosition = playerManager.GetPlayerPosition();
        Quaternion playerRotation = playerManager.GetPlayerRotation();

        DataPersistenceSystem.playerModel.xPosition = playerPosition.x;
        DataPersistenceSystem.playerModel.yPosition = playerPosition.y;
        DataPersistenceSystem.playerModel.zPosition = playerPosition.z;

        DataPersistenceSystem.playerModel.xRotation = playerRotation.x;
        DataPersistenceSystem.playerModel.yRotation = playerRotation.y;
        DataPersistenceSystem.playerModel.zRotation = playerRotation.z;
        DataPersistenceSystem.playerModel.wRotation = playerRotation.w;

        DataPersistenceSystem.SaveGame();
    }

    public void OnClickLoadGame()
    {
        LoadingPersistence.LoadScene(MallSceneName);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }

    public void OnClickQuitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Application.Quit();
    }

    public void UpdateInventoryImages(InventoryModel inventory)
    {
        keyCardInventory.SetActive(inventory.hasKeyCard);
        radioInventory.SetActive(inventory.hasRadio);
        clipboardInventory.SetActive(inventory.hasClipboard);
    }
}
