using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    // Create singleton for easy reference.
    public static PauseManager instance;

    [SerializeField] private GameObject pauseMenu;

    public bool isPaused { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        UserInput.playerInput.SwitchCurrentActionMap("UI");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        UserInput.playerInput.SwitchCurrentActionMap("Player");
    }
}
