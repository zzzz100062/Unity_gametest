using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SureClose : MonoBehaviour
{
    public GameObject Sure;
    public GameObject KamiSure;

    public Medium boolsure;
    void Start()
    {
        boolsure.show = false;
        boolsure.Kamishow = false; 
        boolsure.Introduce_show = true; 
    }

    void Update() 
    {
        Sure.SetActive(boolsure.show);
        KamiSure.SetActive(boolsure.Kamishow);

    }
    
    public void Yes()
    {
        boolsure.show = false;
        boolsure.Kamishow = false;
    }

    public void No()
    {
        boolsure.show = false;
        boolsure.Kamishow = false;
    }
}
