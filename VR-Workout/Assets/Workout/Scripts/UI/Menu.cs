using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//stores all sceneManager load operations
public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStoryGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    public void LoadBlockingGame()
    {
        SceneManager.LoadScene("Punching");
    }

    public void LoadChoppingGame()
    {
        SceneManager.LoadScene("Slicing");
    }

    public void LoadMeditationScene()
    {
        SceneManager.LoadScene("Meditation");
    }

    public void LoadCoolDownScene()
    {
        SceneManager.LoadScene("CoolDown");
    }

    public void LoadSingleMeditation()
    {
        SceneManager.LoadScene("MeditationOnly");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
