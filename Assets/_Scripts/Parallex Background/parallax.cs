using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public Transform mainCam;
    [Header("layer1")]
    public Transform middleBG;
    public Transform sideBG;
    [Header("layer2")]
    public Transform middleBG1;
    public Transform sideBG1;
    [Header("layer3")]
    public Transform middleBG2;
    public Transform sideBG2;
    public float length = 29.95f;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    // Update is called once per frame
    void Update()
    {
        //detect the main cam position
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right*length;
    
        if(mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left*length;

        if (mainCam.position.x > middleBG1.position.x)
            sideBG1.position = middleBG1.position + Vector3.right * length;

        if (mainCam.position.x < middleBG1.position.x)
            sideBG1.position = middleBG1.position + Vector3.left * length;

        if (mainCam.position.x > middleBG2.position.x)
            sideBG2.position = middleBG2.position + Vector3.right * length;

        if (mainCam.position.x < middleBG2.position.x)
            sideBG2.position = middleBG2.position + Vector3.left * length;

        //use to detect the side of the  main cam position and side bg  (left backgorund and right background)

        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x){
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z; 
        }

        if (mainCam.position.x > sideBG1.position.x || mainCam.position.x < sideBG1.position.x)
        {
            Transform z = middleBG1;
            middleBG1 = sideBG1;
            sideBG1 = z;
        }

        if (mainCam.position.x > sideBG2.position.x || mainCam.position.x < sideBG2.position.x)
        {
            Transform z = middleBG2;
            middleBG2 = sideBG2;
            sideBG2 = z;
        }
    }
    //------------------------------------------------------------------------------------------
}
