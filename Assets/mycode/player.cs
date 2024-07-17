using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public GameObject mybag;
    private bagUIopenclose group;
    // Start is called before the first frame update
    void Start()
    {
        group = mybag.GetComponent<bagUIopenclose> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            group.control();
            InventoryManeger.RefreshItem();
            KamiManeger.RefreshItem();

        }

    }
}
