using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;



public class ShopManeger : MonoBehaviour
{
    static ShopManeger instance;

    public Inventory myshop;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;
    public Medium medium;

    public List<GameObject> slots = new List<GameObject>();
    //單利模式
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
        instance.itemInformation.text = "";
    }

    public static void showInfo()
    {
        instance.itemInformation.text = instance.medium.discription;
    }
    


    /*public static void CreateNewItem(Item item)
    {
        if (item.data.itemHeld != 0)
        {
            Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity); ;
            newItem.transform.SetParent(instance.slotGrid.transform);
            newItem.slotItem = item;
            newItem.slotImage.sprite = item.data.itemImage;
            newItem.slotNum.text = item.data.itemHeld.ToString();
        }
    }*/
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
                instance.slots.Clear();
            }
        }


        for (int i = 0; i < instance.myshop.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            //讓slotID等於背包順序
            instance.slots[i].GetComponent<ShopSlot>().slotID = i;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.slots[i].GetComponent<ShopSlot>().SetupSlot(instance.myshop.itemList[i]);

        }        
        
    }
}
