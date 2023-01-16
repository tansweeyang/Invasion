//script for health bar canvas
//description: The health bar displays a bar indicates the ratio of the
//             enemy's current hp to max hp. The health bar will not be
//             displayed when the character is in full health. The health bar
//             will change its color from green to red as the character's
//             hp decreases.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    //-------------------------------------Class Variables-------------------------------------------------------
    public Slider slider; //slider canvas
    public Color low, high; //color of low hp and high hp
    public Vector3 offset; //position of the hp bar
    //-----------------------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle------------------------------------------------------
    //update hp bar
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    //----------------------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods--------------------------------------------------------
    //function to read and display the character's health
    public void SetHealth(float hp, float maxHp)
    {
        slider.gameObject.SetActive(hp < maxHp);
        slider.value = hp;
        slider.maxValue = maxHp;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    //------------------------------------------------------------------------------------------
}
