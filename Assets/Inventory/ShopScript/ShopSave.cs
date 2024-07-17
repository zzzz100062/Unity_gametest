using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class ShopSave : MonoBehaviour
{
    public Inventory myshop;

    [System.Serializable]
    public class Shopdata
    {
        public string itemName;
        public Sprite itemImage;
        public int itemHeld;
        [TextArea]
        public string itemInfo;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) 
        {
            Shopsave();
        }
        
    }

    public void Shopsave()
    {
        //法二:用寫入檔案的方式
        Debug.Log(Application.persistentDataPath);

        if (!Directory.Exists(Application.persistentDataPath + "/shop_Savedata"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/shop_Savedata");
        }

        BinaryFormatter formatter = new BinaryFormatter();//二進制轉換
        FileStream file = File.Create(Application.persistentDataPath + "/shop_Savedata/inventory.shop.txt");
        var json = JsonUtility.ToJson(myshop);

        formatter.Serialize(file, json);
        file.Close();

        BinaryFormatter formatternum = new BinaryFormatter();//二進制轉換
        FileStream filenum = File.Create(Application.persistentDataPath + "/shop_Savedata/inventory.shopitem.txt");

        for (int i = 0; i < myshop.itemList.Count; i++)
        {
            Shopdata Num = new Shopdata();
            //BinaryFormatter formatternum = new BinaryFormatter();//二進制轉換
            //FileStream filenum = File.Create(Application.persistentDataPath + "/shop_Savedata/inventory.shopitem.txt" );

            Num.itemName = myshop.itemList[i].data.itemName;
            Num.itemHeld = myshop.itemList[i].data.itemHeld;
            Num.itemImage = myshop.itemList[i].data.itemImage;
            Num.itemInfo = myshop.itemList[i].data.itemInfo;

            var jsonnum = JsonUtility.ToJson(Num);
            formatternum.Serialize(filenum, jsonnum);  
        }

        filenum.Close();


    }
}
