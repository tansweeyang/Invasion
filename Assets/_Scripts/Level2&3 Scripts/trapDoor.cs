using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapDoor : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject tDoor;
    public GameObject Boss;
    public GameObject detectDoor;
    public GameObject player;
    public bool Bos;
    public bool door;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        tDoor.SetActive(false);
        door = false;
        Boss.SetActive(false);
        Bos = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (door == true)
        {
            tDoor.SetActive(true);      
          
        }
        if (Boss != null)
        {
            if (Bos == true)
            {
         
                Boss.SetActive(true);
                Destroy(detectDoor);
            }
        }
       
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door = true;
            Bos = true;

     
            FindObjectOfType<AudioManagerScript>().Stop("Game BGM");
          
            FindObjectOfType<AudioManagerScript>().Play("Boss BGM");

        }
    }
    //------------------------------------------------------------------------------------------
}
