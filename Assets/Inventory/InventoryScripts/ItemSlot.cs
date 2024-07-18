using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public int slotID; //空格ID 等於 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public Medium medium;

    public GameObject itemInSlot;

    public void ItemOnclicked()
    {
        medium.choseitem = slotItem;
        KamiManeger.RefreshItem();
        InventoryManeger.RefreshItem();
    }

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        else
        {
            slotItem = item;
            slotImage.sprite = item.data.itemImage;
            //slotNum.text = item.data.itemHeld.ToString(); ;
        }

    }

}
