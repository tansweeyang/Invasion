using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieDie : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float dieTime;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        StartCoroutine(Timer());
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(dieTime);
        
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
