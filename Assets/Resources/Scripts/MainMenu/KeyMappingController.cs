using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RMS
{
    public class KeyMapping : MonoBehaviour
    {
        [Header("GameObject List")]
        public GameObject title;
        public GameObject primary;
        public GameObject secondary;

        private GameObject _currentObject;
        private IEnumerable<KeyCode> _keyList;

        public void Start()
        {
            _keyList = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        }

        public void Update()
        {
            if (_currentObject != null)
                WaitForKeyPress();
        }
        public void OnClickPrimaryKeyBind()
        {
            SetCurrentObject(primary);
        }

        public void OnClickSecondaryBind()
        {
            SetCurrentObject(secondary);
        }

        private void SetCurrentObject(GameObject currentObject)
        {
            Button currentButton = currentObject.GetComponentInChildren<Button>();
            TextMeshProUGUI currentTMP = currentObject.GetComponentInChildren<TextMeshProUGUI>();

            currentTMP.text = $">> {currentTMP.text} <<";
            currentButton.enabled = false;

            _currentObject = currentObject;
        }

        private void WaitForKeyPress()
        {
            foreach (KeyCode key in _keyList)
                if (Input.GetKeyDown(key))
                {
                    _currentObject.GetComponentInChildren<TextMeshProUGUI>().text = key.ToString();
                    _currentObject.GetComponentInChildren<Button>().enabled = true;
                    _currentObject = null;
                }
        }
    }
}