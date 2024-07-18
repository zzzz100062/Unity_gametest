using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;






[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]

public class Item : ScriptableObject
{
    
    public itemdata data;
    public shopdata sdata;
    public KamiList listdata;

    [System.Serializable]
    public class itemdata
    {
        public string itemGuid;
        public string itemName;
        public Sprite itemImage;
        public int itemHeld;
        public int itemRemain;
        public int itemcost;
        [TextArea]
        public string itemInfo;
        public string equip;
    }


    [System.Serializable]
    public class shopdata
    {
        public string itemName;
        public Sprite itemImage;
        public int itemHeld;
        [TextArea]
        public string itemInfo;
    }

    [System.Serializable]
    public class KamiList
    {
        //A�ݩ�
        public List<KamiItem> kami_A_List;
        public List<KamiItem> kami_A_skillList;
        //B�ݩ�
        public List<KamiItem> kami_B_List;
        public List<KamiItem> kami_B_skillList;
        //C�ݩ�
        public List<KamiItem> kami_C_List;
        public List<KamiItem> kami_C_skillList;
        //D�ݩ�
        public List<KamiItem> kami_D_List;
        public List<KamiItem> kami_D_skillList;
    }

    public List<KamiItem> mosaiclist;

    public void  QQ()
    {
        Debug.Log("1");
    }


}

    
    


