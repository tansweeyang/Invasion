using System;
using UnityEngine;
using TMPro;

public class VictoryScreenScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public TMP_Text victoryCoinAmount;
    public static bool isVictory = false;

    private int amountMoney;
    private string amountKey = "amountKey";

    public static int levelsUnlocked = 0;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //Setup
    void Start()
    {
        //Indicate victory on
        isVictory = true;

        //Get and display coin amount from game
        victoryCoinAmount.text = CoinUI.CurrentCoinQuantity.ToString();

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Game BGM");
        FindObjectOfType<AudioManagerScript>().Stop("MachineGun Fire");
        FindObjectOfType<AudioManagerScript>().Play("Victory BGM");

        //Stop time
        Time.timeScale = 0f;
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    //Load next level
    public void NextLevel()
    {
        //Indicate victory off
        isVictory = false;

        //Stop Victory BGM
        FindObjectOfType<AudioManagerScript>().Stop("Victory BGM");
        //Play click sound
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Unlock, load and save 
        if (!Loader.IsLastScene())
        {
            UnlockLevelButtons();
            SaveLevelsUnlocked();
        }
        GetSavedCoinAmount();
        AddCoin();
        SaveNewCoinAmount();

        //Reset Current Coin
        //Test if can remove after add coin to level
        CoinUI.CurrentCoinQuantity = 0;

        //Game speed normal
        Time.timeScale = 1f;

        //Load Next level
        Loader.LoadNextScene();
    }


    //Reload current level
    public void Restart()
    {
        //Victory off
        isVictory = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Victory BGM");
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Unlock, load and save 
        if (!Loader.IsLastScene())
        {
            UnlockLevelButtons();
            SaveLevelsUnlocked();
        }
        GetSavedCoinAmount();
        AddCoin();
        SaveNewCoinAmount();

        //Reset coin(remove)
        CoinUI.CurrentCoinQuantity = 0;

        //Game speed normal
        Time.timeScale = 1f;

        //Reload current scene
        Loader.LoadCurrentScene();
    }

    //Load MainMenu Scene
    public void MainMenu()
    {
        //Indicate victory off
        isVictory = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Victory BGM");
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Unlock, load and save 
        if (!Loader.IsLastScene())
        {
            UnlockLevelButtons();
            SaveLevelsUnlocked();
        }
        GetSavedCoinAmount();
        AddCoin();
        SaveNewCoinAmount();

        //Reset coin(remove)
        CoinUI.CurrentCoinQuantity = 0;

        //Game speed normal
        Time.timeScale = 1f;

        //Load MainMenu Scene
        Loader.Load(Loader.Scenes.MainMenuScene);
        
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //Unlocks the next level's button
    private void UnlockLevelButtons()
    {
        int levelsUnlocked = Loader.GetCurrentSceneIndex() + 1;
        LevelSelectionScript.isButtonUnlocked[levelsUnlocked - 1] = true;
    }

    //Saves the levels unlocked
    private void SaveLevelsUnlocked()
    {
        for (int i = 1; i < LevelSelectionScript.isButtonUnlocked.Length; i++)
            PlayerPrefs.SetInt("LevelKey" + i, Convert.ToInt32(LevelSelectionScript.isButtonUnlocked[i]));
    }

    //Gets the saved coin amount
    private void GetSavedCoinAmount()
    {
        amountMoney = PlayerPrefs.GetInt(amountKey, amountMoney);
    }

    //Adds the coin earned in to the saved coin amount
    private void AddCoin()
    {
        amountMoney += CoinUI.getFinalCoinQuantity();
    }

    //Saves the new coin amount
    private void SaveNewCoinAmount()
    {
        PlayerPrefs.SetInt(amountKey, amountMoney);
    }
    //------------------------------------------------------------------------------------------
}
