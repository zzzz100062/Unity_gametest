using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class ShopSlot : MonoBehaviour
{
    public int slotID; //空格ID 等於 物品ID
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public Text coinNum;
    private int cost;
    public coinItem mywallet;
    public Inventory mybag;

    public GameObject itemInSlot;
    private GameObject Sure;
    public Medium boolsure;
    public GameObject button;

    public void ItemOnclicked()
    {
        //InventoryManager.UpdateIteminfo(slotItem.iteminfo);

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
            slotNum.text = item.data.itemRemain.ToString(); 
            coinNum.text = "$"+item.data.itemcost.ToString();
            cost = item.data.itemcost;
        }

    }



    public void BuyOnClick()
    {
        boolsure.show = true;
        boolsure.buyitem = slotItem;
        boolsure.cost = cost;
        boolsure.money = mywallet.MyMoney;
        boolsure.discription = slotItem.data.itemInfo;
        ShopManeger.showInfo();
    }


    public void ReadyBuy()
    {
        if (boolsure.money - boolsure.cost >= 0)
        {

            var money = boolsure.money - boolsure.cost;
            mywallet.MyMoney = money;
            boolsure.buyitem.data.itemRemain -= 1;
            ShopManeger.RefreshItem();            
            boolsure.show = false;            
            AddNewItem();

        }

    }



    public void AddNewItem()
    {


        if (!mybag.itemList.Contains(boolsure.buyitem))
        {
            //playerInventory.itemList.Add(thisItem);
            //InventoryManeger.CreateNewItem(thisItem);

            for (int i = 0; i < mybag.itemList.Count; i++)
            {
                if (mybag.itemList[i] == null)
                {
                    mybag.itemList[i] = boolsure.buyitem;
                    break;
                }
            }
        }
        else
        {
            boolsure.buyitem.data.itemHeld += 1;
        }
        InventoryManeger.RefreshItem();

    }
}
