using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public Transform player; 
    public bool isFlipped = false;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    // change direction to face the player
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (player != null)
        {
            //boss is on the right side of the player 
            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            // boss is on the left side of the player
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }
   //------------------------------------------------------------------------------------------
}
