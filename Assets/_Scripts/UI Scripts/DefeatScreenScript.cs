using UnityEngine;
using TMPro;

public class DefeatScreenScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public TMP_Text victoryCoinAmount;
    
    public static bool isDefeat = false;
    private int amountMoney;
    private string amountKey = "amountKey";
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    //Setup
    void Start()
    {
        //Defeat on
        isDefeat = true;

        //Get and display coin amount from game
        victoryCoinAmount.text = CoinUI.CurrentCoinQuantity.ToString();

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Game BGM");
        FindObjectOfType<AudioManagerScript>().Play("Defeat BGM");

        //Stop time
        Time.timeScale = 0f;
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    //Reload current level
    public void Restart()
    {
        //Defeat off
        isDefeat = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Defeat BGM");
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Load and save
        GetSavedCoinAmount();
        AddCoin();
        SaveNewCoinAmount();

        //Reset (remove)
        CoinUI.CurrentCoinQuantity = 0;

        //Speed normal
        Time.timeScale = 1f;

        //Load current level
        Loader.LoadCurrentScene();
    }

    //Load MainMenu Scene
    public void MainMenu()
    {
        //Defeat off
        isDefeat = false;

        //Sound
        FindObjectOfType<AudioManagerScript>().Stop("Defeat BGM");
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");

        //Load and save
        GetSavedCoinAmount();
        AddCoin();
        SaveNewCoinAmount();

        //Reset(remove)
        CoinUI.CurrentCoinQuantity = 0;

        //Speed normal
        Time.timeScale = 1f;

        //Load MainMenuScene
        Loader.Load(Loader.Scenes.MainMenuScene);
       
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Other Methods----------------------------------------
    //Returns the saved coin amount
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
