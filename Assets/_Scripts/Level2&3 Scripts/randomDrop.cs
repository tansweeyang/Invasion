using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDrop : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject[] gos;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    public void RandomGen()
    {
        Vector2 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        Destroy(gameObject);
    }
    //------------------------------------------------------------------------------------------
}
