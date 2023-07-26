using UnityEngine;

namespace RMS
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _newGame;
        [SerializeField]
        private GameObject _options;
        [SerializeField]
        private GameObject _quit;

        public void OnClickNewGame()
        {
            ClearWindows();
            _newGame.SetActive(!_newGame.activeSelf);
        }

        public void OnClickOptions()
        {
            ClearWindows();
            _options.SetActive(!_options.activeSelf);
        }        
        
        public void OnClickQuit()
        {
            ClearWindows();
            _quit.SetActive(!_quit.activeSelf);
        }

        private void ClearWindows()
        {
            _newGame.SetActive(false);
            _options.SetActive(false);
            _quit.SetActive(false);
        }
    }
}
