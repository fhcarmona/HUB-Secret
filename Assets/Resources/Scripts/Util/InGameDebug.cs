using RMS;
using RMS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDebug : MonoBehaviour
{
    public GameObject[] inventoryItems;
    public GameObject lantern;

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
        TurnLanternOn();
    }

    public void InventoryChanger()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventoryItems[0].SetActive(false);
            inventoryItems[1].SetActive(false);
            inventoryItems[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventoryItems[0].SetActive(true);
            DataPersistenceSystem.playerModel.inventory.hasClipboard = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventoryItems[1].SetActive(true);
            DataPersistenceSystem.playerModel.inventory.hasKeyCard = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventoryItems[2].SetActive(true);
            DataPersistenceSystem.playerModel.inventory.hasRadio = true;
        }
    }

    public void ChangeDoorStatus()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            interactiveClass.GetRaycastObject(out RaycastHit hit);

            hit.transform.gameObject.SetActive(false);

            Debug.Log($"Objeto {hit.transform.name} desabilitado");
        }
    }

    public void TurnLanternOn()
    {
        if(Input.GetKeyDown(KeyCode.F))
            lantern.SetActive(!lantern.activeSelf);
    }
}
