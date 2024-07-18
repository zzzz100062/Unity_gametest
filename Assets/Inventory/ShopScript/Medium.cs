using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item", menuName = "ShopInventory/New SureItem")]
public class Medium : ScriptableObject
{
    public bool show;
    public bool Kamishow;
    public bool Introduce_show;
    public Item buyitem;
    public Item choseitem;
    public KamiItem kamiItem;
    public int cost;
    public int money;
    public int currentID;
    public GameObject introduce_item;
    [TextArea]
    public string discription;
}
