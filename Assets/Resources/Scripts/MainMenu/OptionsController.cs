using UnityEngine;

namespace RMS
{
    public class OptionsController : MonoBehaviour
    {
        [Header("GameObject List")]
        public GameObject graphicsOptions;
        public GameObject audioOptions;
        public GameObject controllerOptions;
        public GameObject accessibilityOptions;       

        public void OnClickGraphics()
        {
            DeactivateOptions(graphicsOptions);

            graphicsOptions.SetActive(true);
        }

        public void OnClickAudio()
        {
            DeactivateOptions(audioOptions);

            audioOptions.SetActive(true);
        }

        public void OnClickController()
        {
            DeactivateOptions(controllerOptions);

            controllerOptions.SetActive(true);
        }

        public void OnClickAccessibility()
        {
            DeactivateOptions(accessibilityOptions);

            accessibilityOptions.SetActive(true);
        }
        private void DeactivateOptions(GameObject activeOption)
        {
            if (graphicsOptions.name != activeOption.name)
                graphicsOptions.SetActive(false);

            if (audioOptions.name != activeOption.name)
                audioOptions.SetActive(false);

            if (controllerOptions.name != activeOption.name)
                controllerOptions.SetActive(false);

            if (accessibilityOptions.name != activeOption.name)
                accessibilityOptions.SetActive(false);
        }
    }
}