using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float followSpeed, yPosition;
    private Transform player;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 targetPosition = player.position;
            Vector2 smoothPos = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothPos.x, smoothPos.y + yPosition, -15f);
        }
    }
    //------------------------------------------------------------------------------------------
}
