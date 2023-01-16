using UnityEngine.SceneManagement;
public static class Loader 
{
    //-------------------------------------Class Variables--------------------------------------
    public enum Scenes
    {
        MainMenuScene,
        TutorialScene,
        Level1Scene,
        Level2Scene,
        Level3Scene,
    }
    public static int numOfScenes = System.Enum.GetNames(typeof(Scenes)).Length-1;
    //------------------------------------------------------------------------------------------

    //-------------------------------------Load Scene-------------------------------------------
    //Load enum scene
    public static void Load(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    //Load next scene
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Reload current scene
    public static void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //------------------------------------------------------------------------------------------

    //-------------------------------------Scene Getter-----------------------------------------
    //Returns current scene
    public static int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    //Returns true if the current scene is the last scene
    public static bool IsLastScene()
    {
        return SceneManager.GetActiveScene().buildIndex == numOfScenes;
    }
    //------------------------------------------------------------------------------------------
}
