using UnityEngine;
using UnityEngine.SceneManagement;

namespace RMS
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("GameObject List")]
        public GameObject newGame;
        public GameObject loadGame;
        public GameObject options;
        public GameObject quit;

        private const string newGameSceneName = "Mall";

        public void Start()
        {
            loadGame.SetActive(DataPersistenceSystem.HasSaveFile());
        }

        public void OnClickNewGame()
        {
            ClearWindows();
            newGame.SetActive(!newGame.activeSelf);

            // Create new player data
            DataPersistenceSystem.playerModel = new PlayerModel();
            DataPersistenceSystem.SavePlayer();

            LoadingPersistence.LoadScene(newGameSceneName);
        }

        public void OnClickLoadGame()
        {
            LoadingPersistence.LoadScene(newGameSceneName);
        }

        public void OnClickOptions()
        {
            ClearWindows();
            options.SetActive(!options.activeSelf);
        }        
        
        public void OnClickQuit()
        {
            ClearWindows();
            quit.SetActive(!quit.activeSelf);
        }

        private void ClearWindows()
        {
            newGame.SetActive(false);
            options.SetActive(false);
            quit.SetActive(false);
        }
    }
}
