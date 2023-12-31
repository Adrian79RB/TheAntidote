﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject miniMapIcon;
    public GameObject inventoryIcon;
    public GameObject inventoryUI;
    public GameObject dialogManager;
    public GameObject mapLocations;
    public GameObject closeCross;
    public bool normalPuzle = false;

    InventoryUI inventory;
    Transform currentLoc;

    private void Awake()
    {
        inventory = inventoryUI.GetComponent<InventoryUI>();
    }

    private void Update()
    {
        closeCross.GetComponent<InventoryControl>().normalPuzle = normalPuzle;
        if (!dialogManager.GetComponent<DialogueManager>().InConvo && !mapLocations.GetComponent<sceneManager>().getPuzleState())
        {
            if(miniMapIcon != null)
                miniMapIcon.SetActive(true);
        }
        else
        {
            if(miniMapIcon != null)
                miniMapIcon.SetActive(false);
        }

        if (dialogManager.GetComponent<DialogueManager>().InConvo || mapLocations.GetComponent<sceneManager>().getPuzleState() && !mapLocations.GetComponent<sceneManager>().getObjectPuzleState())
        {
            inventoryIcon.SetActive(false);
        }
        else
        {
            inventoryIcon.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if(!dialogManager.GetComponent<DialogueManager>().InConvo)
            activateInventoryChanging();
    }

    public void activateInventoryChanging()
    {
        inventory.changeInventoryState();

        if (inventory.animationActivated)
        {
            inventoryIcon.SetActive(false);
            for (int i = 0; i < mapLocations.transform.childCount; i++)
            {
                if (mapLocations.transform.GetChild(i).gameObject.activeSelf)
                {
                    currentLoc = mapLocations.transform.GetChild(i).transform;
                    currentLoc.Find("InteractiveBackground").gameObject.SetActive(false);
                    closeCross.GetComponent<InventoryControl>().currentLoc = currentLoc;
                    closeCross.GetComponent<InventoryControl>().normalPuzle = normalPuzle;
                }
            }
        }

        else
        {
            inventoryIcon.SetActive(true);
            if (normalPuzle)
                currentLoc.Find("BackgroundMapGrey").gameObject.SetActive(true);
            else
                currentLoc.Find("InteractiveBackground").gameObject.SetActive(true);
        }
    }
}
