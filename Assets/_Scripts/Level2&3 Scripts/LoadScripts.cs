using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScripts : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject NextLevelCanvas;
    public bool nextLevel;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        nextLevel = false;
    }

    void Update()
    {
        if (nextLevel == true) {
            NextLevelCanvas.SetActive(true); 
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Player")
        {
            nextLevel = true;
        }
    }
    //------------------------------------------------------------------------------------------
}
