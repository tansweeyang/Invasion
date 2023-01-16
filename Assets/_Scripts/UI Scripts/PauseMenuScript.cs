using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    private int amountMoney;
    private string amountKey = "amountKey";

    public GameObject optionsMenu;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    //Deactivates PauseMenu
    public void ContinueGame()
    {
        //Pause off
        GameScript.isPause = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        FindObjectOfType<PauseMenuScript>().gameObject.SetActive(false);
        
        //Speed normal
        Time.timeScale = 1.0f;
    }

    //Activates OptionsMenu
    public void Options()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Activates OptionsMenu
        FindObjectOfType<PauseMenuScript>().gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //Loads MainMenuScene
    public void MainMenu()
    {
        //Sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        FindObjectOfType<AudioManagerScript>().Stop("Game BGM");
        FindObjectOfType<AudioManagerScript>().Stop("Boss BGM");
        FindObjectOfType<AudioManagerScript>().Play("Main Menu BGM");

        //Save Coin
        amountMoney = PlayerPrefs.GetInt(amountKey, amountMoney);
        amountMoney += CoinUI.getFinalCoinQuantity();
        PlayerPrefs.SetInt(amountKey, amountMoney);

        //Load MainMenuScene
        Loader.Load(Loader.Scenes.MainMenuScene);
    }
    //------------------------------------------------------------------------------------------
}
