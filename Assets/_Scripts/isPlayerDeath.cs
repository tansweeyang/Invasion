//script for enemy detection
//description: Detect if all the enemies are dead

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerDeath : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject DefeatScreen; //victory screen
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //check if there are any objects with "Enemy" tag
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {

            FindObjectOfType<AudioManagerScript>().Stop("MachineGun Fire"); 
            FindObjectOfType<AudioManagerScript>().Stop("Boss BGM");

            DefeatScreen.SetActive(true);
        }
    }
    //------------------------------------------------------------------------------------------
}

