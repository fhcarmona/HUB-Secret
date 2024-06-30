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
    public GameObject confirmationPopup;

    private const string MainMenuSceneName = "MainMenu";
    private const string MallSceneName = "Mall";

    private PlayerManager playerManager;
    private int confirmationType = -1;

    public void Awake()
    {
        playerManager = managers.GetComponentInChildren<PlayerManager>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DataPersistenceSystem.playerModel.isNewGame)
            OpenInGameMenu();
    }

    public void OpenInGameMenu()
    {
        menuOptions.gameObject.SetActive(!menuOptions.gameObject.activeSelf);
        inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
        playerMovement.isPaused = menuOptions.activeSelf;

        Cursor.visible = menuOptions.activeSelf;
        Cursor.lockState = menuOptions.activeSelf ? CursorLockMode.None : CursorLockMode.Confined;

        if(!menuOptions.activeSelf)
            confirmationType = -1;

        UpdateInventoryImages(DataPersistenceSystem.playerModel.inventory);
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
        menuOptions.SetActive(false);
        confirmationPopup.SetActive(true);
        confirmationType = 0;
    }

    public void OnClickMainMenu()
    {
        menuOptions.SetActive(false);
        confirmationPopup.SetActive(true);
        confirmationType = 1;
    }

    public void OnClickQuitGame()
    {
        menuOptions.SetActive(false);
        confirmationPopup.SetActive(true);
        confirmationType = 2;
    }

    public void OnClickConfirmPopup()
    {
        if (confirmationType == 0)
            LoadingPersistence.LoadScene(MallSceneName);
        else if (confirmationType == 1)
            SceneManager.LoadScene(MainMenuSceneName);
        else if (confirmationType == 2)
            Application.Quit();
    }

    public void OnClickCancelPopup()
    {
        confirmationPopup.SetActive(false);
        menuOptions.SetActive(true);
        confirmationType = -1;
    }

    public void UpdateInventoryImages(InventoryModel inventory)
    {
        keyCardInventory.SetActive(inventory.hasKeyCard);
        radioInventory.SetActive(inventory.hasRadio);
        clipboardInventory.SetActive(inventory.hasClipboard);
    }
}
