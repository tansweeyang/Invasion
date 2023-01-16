using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour 
{ 
    //-------------------------------------Class Variables--------------------------------------
    public AudioMixer audioMixer;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Settings Method----------------------------------------
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("changed screen mode");
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions----------------------------------------
    public void BackToGame()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        GameScript.isPause = false;
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMainMenu()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    //------------------------------------------------------------------------------------------
}
