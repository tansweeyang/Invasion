using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public Transform pos1, pos2;    //use these two object to set the platform moving range
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position) 
        {
            nextPos = pos2.position;

        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;

        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    private void OnDrawGizmos()
        //draw line
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
    //------------------------------------------------------------------------------------------
}
