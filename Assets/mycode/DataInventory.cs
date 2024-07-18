using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInventory : MonoBehaviour
{
    [System.Serializable]
    public class itemdata
    {
        public string itemGuid;
        public string itemName;
        public Sprite itemImage;
        public int itemHeld;
        [TextArea]
        public string itemInfo;
        public bool equip;
    }


    public List<itemdata> dataList;
}
