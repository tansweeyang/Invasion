using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject MainMenu;
    public GameObject ShopMenu;
    public GameObject OptionsMenu;
    public GameObject LevelSelectionMenu;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //Setup
    private void Start()
    {
        FindObjectOfType<AudioManagerScript>().Play("Main Menu BGM");
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    //Activates LevelSelectionMenu
    public void Play()
    {
        //Pause off
        GameScript.isPause = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Activates LevelSelectionMenu
        LevelSelectionMenu.SetActive(true);
        MainMenu.SetActive(false);
        
        //Speed normal
        Time.timeScale = 1f;
    }

    //Activates ShopMenu
    public void Store()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Activates ShopMenu
        ShopMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    //Activates OptionsMenu
    public void Options()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Activates OptionsMenu
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    //Quits Game
    public void QuitGame()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Quits Game
        Application.Quit();
    }
    //------------------------------------------------------------------------------------------
}
