//script for random object detection detection
//description: Detect if all the enemies are dead

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkRandomObject : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject victoryScreen; //victory screen
    public GameObject hiddenDoor; //hidden door
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
     void Start()
    {
        hiddenDoor.SetActive(true);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("randomObj").Length == 0) {

            hiddenDoor.SetActive(false);
        }
            if (GameObject.FindGameObjectsWithTag("randomObj").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            victoryScreen.SetActive(true);
        }
    }
    //------------------------------------------------------------------------------------------
}
