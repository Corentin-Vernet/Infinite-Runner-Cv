using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scene_Loader_Service
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
}
