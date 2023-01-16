using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddendoor : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    private bool isOpen;
    public GameObject door;
    private bool isappear;
    public GameObject enemyActiveDetect;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
        isOpen = false;
        enemyActiveDetect.SetActive(false);
        isappear = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true) {
            door.SetActive(false);
        }
        if (enemyActiveDetect!=null && isappear == true)
        {
            enemyActiveDetect.SetActive(true);
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
            isappear = true;


        }
    }
    //------------------------------------------------------------------------------------------
}
