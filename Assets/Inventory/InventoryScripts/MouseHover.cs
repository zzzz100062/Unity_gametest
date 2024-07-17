using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject myPrefab;
    public GameObject my_newPrefab;  
    public GameObject myFather;  
    public Medium medium;

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.gameObject.name == "ItemImage" && medium.Introduce_show != false)
        {
            Vector3 vector3 = new Vector3 (120,80,0);
            my_newPrefab = Instantiate(myPrefab, eventData.pointerEnter.gameObject.transform.position - vector3, Quaternion.identity);
            my_newPrefab.transform.SetParent(eventData.pointerEnter.gameObject.transform.parent.parent.parent.parent.parent);
            medium.discription = eventData.pointerEnter.gameObject.GetComponentInParent<Slot>().slotItem.data.itemInfo;
   
            //medium.introduce_item = eventData.pointerEnter.gameObject;
        }
        else if (eventData.pointerEnter.gameObject.name == "KamiImage" && medium.Introduce_show != false )
        {
            Vector3 vector3 = new Vector3(120, 80, 0);
            my_newPrefab = Instantiate(myPrefab, eventData.pointerEnter.gameObject.transform.position - vector3, Quaternion.identity);
            my_newPrefab.transform.SetParent(eventData.pointerEnter.gameObject.transform.parent.parent.parent.parent.parent.parent);
            medium.discription = eventData.pointerEnter.gameObject.GetComponentInParent<Kami>().kamiItem.data.itemInfo;
            //medium.introduce_item = eventData.pointerEnter.gameObject;
        }
        else if (eventData.pointerEnter.gameObject.name == "Item_Image" && medium.Introduce_show != false)
        {
            Vector3 vector3 = new Vector3(120, 80, 0);
            my_newPrefab = Instantiate(myPrefab, eventData.pointerEnter.gameObject.transform.position - vector3, Quaternion.identity);
            my_newPrefab.transform.SetParent(eventData.pointerEnter.gameObject.transform.parent.parent.parent.parent.parent);
            medium.discription = eventData.pointerEnter.gameObject.GetComponentInParent<ItemSlot>().slotItem.data.itemInfo;
            //medium.introduce_item = eventData.pointerEnter.gameObject;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(my_newPrefab);

        Debug.Log("66");
    }


    public void Delete()
    {
        Destroy(my_newPrefab);
    }




}