using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsOnworld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddNewItem()
    {

            if (!playerInventory.itemList.Contains(thisItem))
            {
                //playerInventory.itemList.Add(thisItem);
                //InventoryManeger.CreateNewItem(thisItem);

                for (int i = 0; i < playerInventory.itemList.Count; i++)
                {
                    if (playerInventory.itemList[i] == null)
                    {
                        playerInventory.itemList[i] = thisItem;
                        break;
                    }
                }
            }
            else
            {
                thisItem.data.itemHeld += 1;
            }
            InventoryManeger.RefreshItem();
        
    }
}
