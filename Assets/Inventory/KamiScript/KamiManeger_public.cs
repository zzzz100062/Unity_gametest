using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KamiManeger_public : MonoBehaviour
{
    public Inventory myBag;
    public GameObject slotGrid;
    public GameObject slotskillGrid;
    public GameObject emptySlot;
    public Text itemInformation;
    public Medium medium;

    public List<GameObject> kamis = new List<GameObject>();
    public List<GameObject> kamiskills = new List<GameObject>();
}
