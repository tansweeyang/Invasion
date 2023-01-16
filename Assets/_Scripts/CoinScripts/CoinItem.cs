using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    // if collide with the coins, thec coin will be collected and added automatically
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            CoinUI.CurrentCoinQuantity += 50;
            //ShopScript.moneyAmountText1 += CoinUI.CoinQuantity;

            Destroy(gameObject);
        }
    }
}