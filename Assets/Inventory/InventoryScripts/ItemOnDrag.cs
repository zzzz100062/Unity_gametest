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
    public int currentItemID; //��e���~ID
    public int slotID;


    public void OnBeginDrag(PointerEventData eventData)
    {
        //�����쥻������(slot��)
        originalParent = gameObject.transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID; //currentID = slotID
        medium.currentID = originalParent.GetComponent<Slot>().slotID;
        originalPosition = originalParent.position;
        //��transform�]��parent��parent�A��slot���ŤU
        transform.SetParent(transform.parent.parent.parent);
        //item��m����ƹ���m
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        medium.Introduce_show = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //�O���������~��Item
        medium.kamiItem = originalParent.GetComponent<Slot>().slotItem;
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage")
        {
            //��e��item�ܦ�slot����
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            //��Q���V�����m�O���@�P
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

            //kamiList���~�x�s��m����
            var temp = myBag.kamiList[currentItemID];
            myBag.kamiList[currentItemID] = myBag.kamiList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
            myBag.kamiList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;


            //�Q���V�����~����洫������(slot)
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            //�˦^slot ��
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

            //kamiList���~�x�s��m����
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
        //�@�볡��
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

        //�ޯೡ��

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
