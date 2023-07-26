using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyMapping : MonoBehaviour
{
    public GameObject _titleObject;
    public GameObject _primaryObject;
    public GameObject _secondaryObject;

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
        SetCurrentObject(_primaryObject);
    }

    public void OnClickSecondaryBind()
    {
        SetCurrentObject(_secondaryObject);
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
