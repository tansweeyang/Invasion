using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpike : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    private PlayerBehaviour pb;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        pb = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&& collision.GetType().ToString()== "UnityEngine.EdgeCollider2D") { 
            
            pb.TakeHitByGroundSpite(10);
        }
    }
    //------------------------------------------------------------------------------------------
}
