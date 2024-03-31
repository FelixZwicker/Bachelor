using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseMenu;

    // oculus integrated pause button
    private const OVRInput.Button start = OVRInput.Button.Start;
    private bool menuOpen = false;

    private void Update()
    {
        if(OVRInput.GetDown(start) && !menuOpen)
        {
            menuOpen = true;
            PauseGame();
        }
        else if(OVRInput.GetDown(start) && menuOpen)
        {
            menuOpen = false;
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
