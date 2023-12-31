﻿using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public bool animationActivated = false;

    Inventory inventory;
    InventorySlot[] slots;

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        anim = GetComponentInChildren<Animator>();
        inventory.setUpInventory();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void changeInventoryState()
    {
        if (!animationActivated)
        {
            anim.SetBool("IsOpen", true);
            animationActivated = true;
        }
        else
        {
            anim.SetBool("IsOpen", false);
            animationActivated = false;
            transform.GetChild(0).Find("description").gameObject.GetComponentInChildren<Text>().text = "No has seleccionado ningún objeto";
        }
    }
}
