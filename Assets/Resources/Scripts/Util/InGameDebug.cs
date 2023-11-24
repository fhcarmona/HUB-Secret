using RMS;
using RMS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDebug : MonoBehaviour
{
    public GameObject[] inventoryItems;

    private new GameObject camera;
    private InteractiveObjects interactiveClass;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");

        if (camera.TryGetComponent(out interactiveClass))
            Debug.Log("Classe encontrada");

        DataPersistenceSystem.playerModel.inventory.hasClipboard = true;
    }

    void Update()
    {
        InventoryChanger();
    }

    public void InventoryChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && DataPersistenceSystem.playerModel.inventory.hasClipboard)
        {
            inventoryItems[1].SetActive(false);
            inventoryItems[2].SetActive(false);
            inventoryItems[0].SetActive(!inventoryItems[0].activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && DataPersistenceSystem.playerModel.inventory.hasKeyCard)
        {
            inventoryItems[0].SetActive(false);
            inventoryItems[2].SetActive(false);
            inventoryItems[1].SetActive(!inventoryItems[1].activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && DataPersistenceSystem.playerModel.inventory.hasRadio)
        {
            inventoryItems[0].SetActive(false);
            inventoryItems[1].SetActive(false);
            inventoryItems[2].SetActive(!inventoryItems[2].activeSelf);
        }
    }

    public void ChangeDoorStatus()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            interactiveClass.GetRaycastObject(out RaycastHit hit);

            if (hit.transform != null)
            {
                hit.transform.gameObject.SetActive(false);

                Debug.Log($"Objeto {hit.transform.name} desabilitado");
            }
        }
    }
}
