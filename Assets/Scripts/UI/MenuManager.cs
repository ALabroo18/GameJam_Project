using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        // If pause button is pressed and the game isn't paused, pause the game.
        if (UserInput.instance.pauseInput && !PauseManager.instance.isPaused)
        {
            Pause();
        }

        // If the resume input is pressed and the game is paused, resume the game.
        else if (UserInput.instance.resumeInputUI && PauseManager.instance.isPaused)
        {
            Resume();
        }
    }

    public void Pause()
    {
        PauseManager.instance.PauseGame();
    }

    public void Resume()
    {
        PauseManager.instance.ResumeGame();
    }
}
