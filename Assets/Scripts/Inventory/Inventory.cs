﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    public void Awake()
    {
        if( instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        } 
        instance = this;
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallBack;

    public int space = 8;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Mensaje alerta espacio");
            return false;
        }
        items.Add(item);
        
        if(onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}