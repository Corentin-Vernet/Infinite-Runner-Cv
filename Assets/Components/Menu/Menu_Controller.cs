using UnityEngine;

public class Menu_Controller : MonoBehaviour
{
    // Main Menu: ---------------------------
    public void ButtomStart()
    {
        Scene_Loader_Service.LoadGame();
    }
    

    public void ButtomQuitGame()
    {
        #if !UNITY_EDITOR
        Application.Quit();

        #else
        UnityEditor.EditorApplication.isPlaying = false;

        #endif
    }

    public void ButtonRestart()
    {
        Scene_Loader_Service.LoadGame();
    }

    // Menu: Pause -------------------------

    // Menu: Game Over ---------------------
    public void ReturnMainMenu()
    {
        Scene_Loader_Service.LoadMainMenu();
    }
}