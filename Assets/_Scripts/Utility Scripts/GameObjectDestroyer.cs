//script for GameObject destroyer
//description: The GameObject will be destroyed after its lifetime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float dieTime; //lifetime
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //starts a Coroutine
    void Start()
    {
        StartCoroutine(Timer());
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //destroy the GameObject after its lifetime
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
