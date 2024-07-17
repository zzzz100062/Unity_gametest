using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform originalParent;
    public Vector3 originalPosition;
    public Inventory myBag;
    public Medium medium;
    public int currentItemID; //當前物品ID
    public int slotID;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //紀錄原本的父級(slot級)
        originalParent = gameObject.transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID; //currentID = slotID
        medium.currentID = originalParent.GetComponent<Slot>().slotID;
        originalPosition = originalParent.position;
        //把transform設為parent的parent，到slot階級下
        transform.SetParent(transform.parent.parent.parent);
        //item位置等於滑鼠位置
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        medium.Introduce_show = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //記錄托移物品的Item
        medium.kamiItem = originalParent.GetComponent<Slot>().slotItem;
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage")
        {
            //當前的item變成slot階級
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            //跟被指向物體位置保持一致
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

            //kamiList物品儲存位置改變
            var temp = myBag.kamiList[currentItemID];
            myBag.kamiList[currentItemID] = myBag.kamiList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
            myBag.kamiList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


            //被指向的物品等於交換的父級(slot)
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            //裝回slot 內
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryManeger.RefreshItem();
            medium.Introduce_show = true;
            return;
        }

        if (eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)")
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

            //kamiList物品儲存位置改變
            myBag.kamiList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.kamiList[currentItemID];
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
            {
                myBag.kamiList[currentItemID] = null;
            }

            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryManeger.RefreshItem();
            medium.Introduce_show = true;
            return;
        }

        if (eventData.pointerCurrentRaycast.gameObject.name == "Kami(Clone)" && eventData.pointerCurrentRaycast.gameObject.GetComponent<Kami>().slotID == medium.kamiItem.data.itemGuid)
        {
            Debug.Log(currentItemID);
            show();
            transform.SetParent(originalParent);
            transform.position = originalParent.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            InventoryManeger.RefreshItem();
            medium.Introduce_show = true;
            return;
        }

        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        InventoryManeger.RefreshItem();

        medium.Introduce_show = true;



    }

    public void show()
    {        
        medium.Kamishow = true;
    }

    public void AddItem()
    {
        //一般部分
        if (medium.kamiItem.data.type == "A_equid")
        {
            medium.choseitem.listdata.kami_A_List.Clear();
            medium.choseitem.listdata.kami_A_List.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_A_List[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "B_equid")
        {
            medium.choseitem.listdata.kami_B_List.Clear();
            medium.choseitem.listdata.kami_B_List.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_B_List[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "C_equid")
        {
            medium.choseitem.listdata.kami_C_List.Clear();
            medium.choseitem.listdata.kami_C_List.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_C_List[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "D_equid")
        {
            medium.choseitem.listdata.kami_D_List.Clear();
            medium.choseitem.listdata.kami_D_List.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_D_List[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }

        //技能部分

        else if (medium.kamiItem.data.type == "A_skill")
        {
            medium.choseitem.listdata.kami_A_skillList.Clear();
            medium.choseitem.listdata.kami_A_skillList.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[4] = medium.choseitem.listdata.kami_A_skillList[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "B_skill")
        {
            medium.choseitem.listdata.kami_B_skillList.Clear();
            medium.choseitem.listdata.kami_B_skillList.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_B_skillList[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "C_skill")
        {
            medium.choseitem.listdata.kami_C_skillList.Clear();
            medium.choseitem.listdata.kami_C_skillList.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_C_skillList[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }
        else if (medium.kamiItem.data.type == "D_skill")
        {
            medium.choseitem.listdata.kami_D_skillList.Clear();
            medium.choseitem.listdata.kami_D_skillList.Add(medium.kamiItem);
            medium.choseitem.mosaiclist[medium.kamiItem.data.itemGuid] = medium.choseitem.listdata.kami_D_skillList[0];
            KamiManeger.RefreshItem();
            DeleteItem();
        }


    }

    public void DeleteItem()
    {
        myBag.kamiList.RemoveAt(medium.currentID);
        myBag.kamiList.Insert(medium.currentID, null);
        InventoryManeger.RefreshItem();
    }

    
}
