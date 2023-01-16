using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectDead : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject defeatScreen;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            defeatScreen.SetActive(true);

        }
    }
    //------------------------------------------------------------------------------------------
}
