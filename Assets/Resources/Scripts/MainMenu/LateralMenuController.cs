using UnityEngine;

namespace RMS
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("GameObject List")]
        public GameObject newGame;
        public GameObject options;
        public GameObject quit;

        public void OnClickNewGame()
        {
            ClearWindows();
            newGame.SetActive(!newGame.activeSelf);
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
