using UnityEngine;

namespace RMS
{
    public class OptionsController : MonoBehaviour
    {
        [Header("OptionsMenu")]
        [SerializeField]
        private GameObject _graphicsOptions;
        [SerializeField]
        private GameObject _audioOptions;
        [SerializeField]
        private GameObject _controllerOptions;
        [SerializeField]
        private GameObject _accessibilityOptions;

        private void DeactivateOptions(GameObject activeOption)
        {
            if (_graphicsOptions.name != activeOption.name)
                _graphicsOptions.SetActive(false);

            if (_audioOptions.name != activeOption.name)
                _audioOptions.SetActive(false);

            if (_controllerOptions.name != activeOption.name)
                _controllerOptions.SetActive(false);

            if (_accessibilityOptions.name != activeOption.name)
                _accessibilityOptions.SetActive(false);
        }

        public void OnClickGraphics()
        {
            DeactivateOptions(_graphicsOptions);

            _graphicsOptions.SetActive(true);
        }

        public void OnClickAudio()
        {
            DeactivateOptions(_audioOptions);

            _audioOptions.SetActive(true);
        }

        public void OnClickController()
        {
            DeactivateOptions(_controllerOptions);

            _controllerOptions.SetActive(true);
        }

        public void OnClickAccessibility()
        {
            DeactivateOptions(_accessibilityOptions);

            _accessibilityOptions.SetActive(true);
        }
    }
}