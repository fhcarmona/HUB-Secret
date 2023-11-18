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
    }

    void Update()
    {
        InventoryChanger();
        ChangeDoorStatus();
    }

    public void InventoryChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventoryItems[1].SetActive(false);
            inventoryItems[2].SetActive(false);
            inventoryItems[0].SetActive(!inventoryItems[0].activeSelf);
            DataPersistenceSystem.playerModel.inventory.hasClipboard = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventoryItems[0].SetActive(false);
            inventoryItems[2].SetActive(false);
            inventoryItems[1].SetActive(!inventoryItems[1].activeSelf);
            DataPersistenceSystem.playerModel.inventory.hasKeyCard = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventoryItems[0].SetActive(false);
            inventoryItems[1].SetActive(false);
            inventoryItems[2].SetActive(!inventoryItems[2].activeSelf);
            DataPersistenceSystem.playerModel.inventory.hasRadio = true;
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
