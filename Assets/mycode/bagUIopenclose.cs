using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagUIopenclose : MonoBehaviour
{
    private CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void control ()
    {
        if (canvas.alpha == 1)
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;

        }

        else
        {
            canvas.alpha = 1;
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }
    }

  
}
