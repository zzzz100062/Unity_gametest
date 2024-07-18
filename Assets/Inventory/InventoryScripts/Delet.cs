using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Transform objectToDelete = gameObject.transform.Find("Introduce(Clone)");
            if (objectToDelete != null)
            {
                Destroy(objectToDelete.gameObject);
                Debug.Log("жие\зR░г");
            }
        }
    }
}