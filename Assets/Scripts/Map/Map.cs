﻿#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public float speed;

    [SerializeField] private GameObject interactiveBackground;
    public GameObject dialogueCanvas;
    [SerializeField] private GameObject startConvoButton;
    private Animator mapAnimator;

    private void Start()
    {
        mapAnimator = GetComponent<Animator>();
    }

    /*private void Update()
    {
        if (Input.GetKey(KeyCode.M) && mapAnimator.GetBool("isShowing") == false)
        {
            mapAnimator.SetBool("isShowing", true);
            background.SetActive(false);
            startConvoButton.SetActive(false);
            dialogueCanvas.SetActive(false);
        }

        if (Input.GetKey(KeyCode.N) && mapAnimator.GetBool("isShowing") == true)
        {
            mapAnimator.SetBool("isShowing", false);
            background.SetActive(true);
            startConvoButton.SetActive(true);
            dialogueCanvas.SetActive(true);
        }
    }*/

    public void openMap()
    {
        mapAnimator.SetBool("isShowing", true);
        interactiveBackground.SetActive(false);
        dialogueCanvas.SetActive(false);

        if(startConvoButton != null)
            startConvoButton.SetActive(false);
    }

   public void closeMap()
   {
        mapAnimator.SetBool("isShowing", false);
        interactiveBackground.SetActive(true);
        dialogueCanvas.SetActive(true);

        if (startConvoButton != null)
            startConvoButton.SetActive(true);
   }
}
