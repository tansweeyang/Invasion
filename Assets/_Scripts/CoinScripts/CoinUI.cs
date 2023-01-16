using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinUI : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public TMP_Text CoinQuantity1;
    public static int CurrentCoinQuantity;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        CurrentCoinQuantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CoinQuantity1.text = CurrentCoinQuantity.ToString();
        //CoinQuantity.text = CoinQuantity1.text;
        //ShopScript.moneyAmountText1.text = CoinQuantity.text;

    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Getter Methods----------------------------------------
    public static int getFinalCoinQuantity()
    {
        return CurrentCoinQuantity;
    }
    //------------------------------------------------------------------------------------------
}

