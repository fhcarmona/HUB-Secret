using System.Collections;
using System.Linq;
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

        public GameObject notImplementedWindow;

        public void OnClickGraphics()
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, default);
            DeactivateOptions(graphicsOptions);

            graphicsOptions.SetActive(true);
        }

        public void OnClickAudio()
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, default);
            DeactivateOptions(audioOptions);

            audioOptions.SetActive(true);
        }

        public void OnClickController()
        {
            StartCoroutine(NotImplementedInfo());
        }

        public void OnClickAccessibility()
        {
            StartCoroutine(NotImplementedInfo());
        }

        public void OnClickClose()
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.clickUI, default);
            gameObject.SetActive(false);
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

        private IEnumerator NotImplementedInfo()
        {
            if (notImplementedWindow.activeSelf)
                yield break;

            notImplementedWindow.SetActive(true);

            yield return new WaitForSeconds(1);

            notImplementedWindow.SetActive(false);
        }
    }
}