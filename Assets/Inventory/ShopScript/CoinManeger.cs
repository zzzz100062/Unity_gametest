using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class CoinManeger : MonoBehaviour
{
    public coinItem MyWallet;
    public Text coin;

    void Update () 
    {
        coin.text = MyWallet.MyMoney.ToString();
    }

}
