﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMap : MonoBehaviour
{
    [SerializeField] private GameObject nextLocation;
    public int locations;

    private void OnMouseDown()
    {
        for (int i = 0; i < locations; i++)
        {
            // Desactivamos la ubicación actual
            GameObject actualLocation = GameObject.Find("Map Locations").transform.GetChild(i).gameObject;
            Map mapScript = GameObject.Find("InteractiveMap").GetComponent<Map>();
            actualLocation.SetActive(false);

            // Activamos la ubicación a la que queremos viajar
            mapScript.dialogueCanvas.SetActive(true);
            nextLocation.SetActive(true);
        }
    }
}
