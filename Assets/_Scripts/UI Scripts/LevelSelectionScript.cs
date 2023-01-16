using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionScript : MonoBehaviour
{
    //-------------------------------------Class Variables--------------------------------------
    public GameObject MainMenu;
    public Button[] levelButtons;

    public static bool[] isButtonUnlocked;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Script Lifecycle-------------------------------------

    //Setup
    void Start()
    {
        //Initializes variables
        if (isButtonUnlocked == null)
        {
            isButtonUnlocked = new bool[levelButtons.Length];
        }
        isButtonUnlocked[0] = true;
        levelButtons[0].interactable = true;

        //loads and unlocks levels
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("LevelKey" + i) == 1)
            {
                isButtonUnlocked[i] = true;
                levelButtons[i].interactable = true;
            }
            else
            {
                isButtonUnlocked[i] = false;
                levelButtons[i].interactable = false;
            }
        }
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Button Actions---------------------------------------
    //Loads tutorial scene
    public void Tutorial()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        Loader.Load(Loader.Scenes.TutorialScene);
    }
    //Loads level1 scene
    public void Level1()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        Loader.Load(Loader.Scenes.Level1Scene);
    }

    //Loads level2 scene
    public void Level2()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        Loader.Load(Loader.Scenes.Level2Scene);
    }

    //Loads level3 scene
    public void Level3()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        Loader.Load(Loader.Scenes.Level3Scene);
    }

    //Activates MainMenu
    public void Back()
    {
        FindObjectOfType<AudioManagerScript>().Play("Click Sound");
        FindObjectOfType<LevelSelectionScript>().gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
    //------------------------------------------------------------------------------------------
}
