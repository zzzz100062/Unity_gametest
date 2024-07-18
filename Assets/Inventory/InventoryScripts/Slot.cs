using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID; //空格ID 等於 物品ID
    public KamiItem slotItem;
    public Image slotImage;
    public Text slotNum;
    public Medium medium;

    public GameObject itemInSlot;

    public void ItemOnclicked()
    {
        //medium.kamiItem = slotItem;
        KamiManeger.RefreshItem();
    }

    public void SetupSlot(KamiItem item)
    {
        if(item ==  null )
        {
            itemInSlot.SetActive(false);
            return;
        }
        else
        {
            slotItem = item;
            slotImage.sprite = item.data.itemImage;
            slotNum.text = item.data.itemHeld.ToString(); ;
        }

    }

    public void YesOnClick()
    {
        itemInSlot.GetComponent<ItemOnDrag>().AddItem();
    }
}
