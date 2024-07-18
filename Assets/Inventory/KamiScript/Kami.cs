using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kami : MonoBehaviour
{
    public int slotID; //�Ů�ID ���� ���~ID
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
