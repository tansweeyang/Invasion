//script for enemy detection
//description: Detect if all the enemies are dead

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreEnemiesDead : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject victoryScreen; //victory screen
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //check if there are any objects with "Enemy" tag
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            victoryScreen.SetActive(true);
        }
    }
    //------------------------------------------------------------------------------------------
}
