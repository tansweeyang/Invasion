using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject pauseMenu;
    public GameObject game;
    public GameObject optionsMenu;
    public GameObject victoryScreen;
    public GameObject defeatScreen;
    public static bool isPause = false;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------
    private void Start()
    {
        FindObjectOfType<AudioManagerScript>().Stop("Main Menu BGM");
        FindObjectOfType<AudioManagerScript>().Play("Game BGM");
    }
    
    public void Update()
    {
        if (!isPause && !VictoryScreenScript.isVictory && !DefeatScreenScript.isDefeat && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Win or Lose Game-------------------------------------
    public void WinGame()
    {
        victoryScreen.SetActive(true);
    }

    public void LoseGame()
    {
        defeatScreen.SetActive(true);
    }
    //------------------------------------------------------------------------------------------
}
