using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public float parallaxFactor;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        transform.localPosition = newPos;
    }
    //------------------------------------------------------------------------------------------
}
    
