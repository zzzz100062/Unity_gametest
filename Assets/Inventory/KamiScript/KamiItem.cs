using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New KamiStone", menuName = "Inventory/New Kami")]
public class KamiItem : ScriptableObject
{
    public kamidata data;

    [System.Serializable]
    public class kamidata
    {
        public int itemGuid;
        public string itemName;
        public Sprite itemImage;
        public int itemHeld;
        [TextArea]
        public string itemInfo;
        public string type;
        public bool isskilled;
    }
}
