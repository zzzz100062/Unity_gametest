using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManeger : MonoBehaviour
{
    static InventoryManeger instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public GameObject ItemslotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public GameObject Item_emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject> ();
    public List<GameObject> Itemslots = new List<GameObject>();
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    

    public void OnEnable() 
    {
        RefreshItem();
    }


    public static void RefreshItem()
    {
        for (int i = 0; i< instance.slotGrid.transform.childCount; i++) 
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            else 
            {
                Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
                instance.slots.Clear();
            }
        }

        
        for (int i = 0; i < instance.myBag.kamiList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            //讓slotID等於背包順序
            instance.slots[i].GetComponent<Slot>().slotID = i;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.kamiList[i]);
            
        }

        for (int i = 0; i < instance.ItemslotGrid.transform.childCount; i++)
        {
            if (instance.ItemslotGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.ItemslotGrid.transform.GetChild(i).gameObject);
                instance.Itemslots.Clear();
            }
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.Itemslots.Add(Instantiate(instance.Item_emptySlot));
            instance.Itemslots[i].transform.SetParent(instance.ItemslotGrid.transform);
            //讓slotID等於背包順序
            instance.Itemslots[i].GetComponent<ItemSlot>().slotID = i;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.Itemslots[i].GetComponent<ItemSlot>().SetupSlot(instance.myBag.itemList[i]);

        }

    }
}
