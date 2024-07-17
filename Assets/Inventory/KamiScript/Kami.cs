using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kami : MonoBehaviour
{
    public int slotID; //空格ID 等於 物品ID
    public KamiItem kamiItem;
    public Image kamiImage;
    public Text kamiNum;

    public GameObject itemInSlot;

    public void SetupSlot(KamiItem item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        else
        {
            kamiItem = item;
            kamiImage.sprite = item.data.itemImage;
            //slotNum.text = item.data.itemHeld.ToString(); 
        }

    }

    
}
