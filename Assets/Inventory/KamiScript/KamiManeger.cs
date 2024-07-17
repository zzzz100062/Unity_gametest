using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KamiManeger : MonoBehaviour
{
    public Inventory myBag;
    public GameObject emptySlot;
    public Text itemInformation;
    public Medium medium;

    public GameObject slot_A_Grid;
    public GameObject slot_B_Grid;
    public GameObject slot_C_Grid;
    public GameObject slot_D_Grid;
    public GameObject slot_A_skillGrid;
    public GameObject slot_B_skillGrid;
    public GameObject slot_C_skillGrid;
    public GameObject slot_D_skillGrid;

    public List<GameObject> kamis_A = new List<GameObject>();
    public List<GameObject> kamis_B = new List<GameObject>();
    public List<GameObject> kamis_C = new List<GameObject>();
    public List<GameObject> kamis_D = new List<GameObject>();
    public List<GameObject> kamiskills_A = new List<GameObject>();
    public List<GameObject> kamiskills_B = new List<GameObject>();
    public List<GameObject> kamiskills_C = new List<GameObject>();
    public List<GameObject> kamiskills_D = new List<GameObject>();

    static KamiManeger instance;

    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    public void OnEnable()
    {
        RefreshItem();
    }


    public enum order_of_kamiStone
    {
        Kami_A_normal = 0,
        Kami_B_normal,
        Kami_C_normal,
        Kami_D_normal,

        Kami_A_skill,
        Kami_B_skill,
        Kami_C_skill,
        Kami_D_skill
    }


    public static void RefreshItem()
    {
     
        //Kami A 一般類型
        for (int i = 0; i < instance.slot_A_Grid.transform.childCount; i++)
        {
            if (instance.slot_A_Grid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_A_Grid.transform.GetChild(i).gameObject);
                instance.kamis_A.Clear();
            }
        }  

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_A_List.Count; i++)
        {
            
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamis_A.Add(Instantiate(instance.emptySlot));
            instance.kamis_A[i].transform.SetParent(instance.slot_A_Grid.transform);
            //讓slotID等於背包順序
            //instance.kamis_A[i].GetComponent<Kami>().slotID = i; 
            instance.kamis_A[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_A_normal;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamis_A[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_A_List[i]);

        }


        //Kami B 一般類型
        for (int i = 0; i < instance.slot_B_Grid.transform.childCount; i++)
        {
            if (instance.slot_B_Grid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_B_Grid.transform.GetChild(i).gameObject);
                instance.kamis_B.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_B_List.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamis_B.Add(Instantiate(instance.emptySlot));
            instance.kamis_B[i].transform.SetParent(instance.slot_B_Grid.transform);
            //讓slotID等於背包順序
            //instance.kamis_B[i].GetComponent<Kami>().slotID = i+1;
            instance.kamis_B[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_B_normal;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamis_B[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_B_List[i]);

        }

        //Kami C 一般類型
        for (int i = 0; i < instance.slot_C_Grid.transform.childCount; i++)
        {
            if (instance.slot_C_Grid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_C_Grid.transform.GetChild(i).gameObject);
                instance.kamis_C.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_C_List.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamis_C.Add(Instantiate(instance.emptySlot));
            instance.kamis_C[i].transform.SetParent(instance.slot_C_Grid.transform);
            //讓slotID等於背包順序
            //instance.kamis_C[i].GetComponent<Kami>().slotID = i+2;
            instance.kamis_C[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_C_normal;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamis_C[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_C_List[i]);

        }


        //Kami D 一般類型
        for (int i = 0; i < instance.slot_D_Grid.transform.childCount; i++)
        {
            if (instance.slot_D_Grid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_D_Grid.transform.GetChild(i).gameObject);
                instance.kamis_D.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_D_List.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamis_D.Add(Instantiate(instance.emptySlot));
            instance.kamis_D[i].transform.SetParent(instance.slot_D_Grid.transform);
            //讓slotID等於背包順序
            //instance.kamis_D[i].GetComponent<Kami>().slotID = i+3;
            instance.kamis_D[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_D_normal;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamis_D[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_D_List[i]);

        }






        //Kami A 技能類型
        for (int i = 0; i < instance.slot_A_skillGrid.transform.childCount; i++)
        {
            if (instance.slot_B_skillGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_A_skillGrid.transform.GetChild(i).gameObject);
                instance.kamiskills_A.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_B_skillList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamiskills_A.Add(Instantiate(instance.emptySlot));
            instance.kamiskills_A[i].transform.SetParent(instance.slot_A_skillGrid.transform);
            //讓slotID等於背包順序
            //instance.kamiskills_A[i].GetComponent<Kami>().slotID = i + 4;
            instance.kamiskills_A[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_A_skill;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamiskills_A[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_A_skillList[i]);
        }

        //Kami B 技能類型
        for (int i = 0; i < instance.slot_B_skillGrid.transform.childCount; i++)
        {
            if (instance.slot_B_skillGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_B_skillGrid.transform.GetChild(i).gameObject);
                instance.kamiskills_B.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_B_skillList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamiskills_B.Add(Instantiate(instance.emptySlot));
            instance.kamiskills_B[i].transform.SetParent(instance.slot_B_skillGrid.transform);
            //讓slotID等於背包順序
            //instance.kamiskills_B[i].GetComponent<Kami>().slotID = i+5;
            instance.kamiskills_B[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_B_skill;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamiskills_B[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_B_skillList[i]);
        }



        //Kami C 技能類型
        for (int i = 0; i < instance.slot_C_skillGrid.transform.childCount; i++)
        {
            if (instance.slot_C_skillGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_C_skillGrid.transform.GetChild(i).gameObject);
                instance.kamiskills_C.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_C_skillList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamiskills_C.Add(Instantiate(instance.emptySlot));
            instance.kamiskills_C[i].transform.SetParent(instance.slot_C_skillGrid.transform);
            //讓slotID等於背包順序
            //instance.kamiskills_C[i].GetComponent<Kami>().slotID = i + 6;
            instance.kamiskills_C[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_C_skill;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamiskills_C[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_C_skillList[i]);
        }



        //Kami D 技能類型
        for (int i = 0; i < instance.slot_D_skillGrid.transform.childCount; i++)
        {
            if (instance.slot_D_skillGrid.transform.childCount == 0)
            {
                break;
            }
            else
            {
                Destroy(instance.slot_D_skillGrid.transform.GetChild(i).gameObject);
                instance.kamiskills_D.Clear();
            }
        }

        for (int i = 0; i < instance.medium.choseitem.listdata.kami_D_skillList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.kamiskills_D.Add(Instantiate(instance.emptySlot));
            instance.kamiskills_D[i].transform.SetParent(instance.slot_D_skillGrid.transform);
            //讓slotID等於背包順序
            //instance.kamiskills_D[i].GetComponent<Kami>().slotID = i + 7 ;
            instance.kamiskills_D[i].GetComponent<Kami>().slotID = (int)order_of_kamiStone.Kami_D_skill ;
            // instance.slotp[i]獲得myBag中對應的Item
            instance.kamiskills_D[i].GetComponent<Kami>().SetupSlot(instance.medium.choseitem.listdata.kami_D_skillList[i]);
        }




    }
}
