using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuButtons : MonoBehaviour
{
    private UIDocument document;

    private List<Button> pauseButtons;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        pauseButtons = document.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnAllButtonsClick(ClickEvent click)
    {
        Button clickedButton = click.target as Button;

        string buttonName = clickedButton.name;

        switch (buttonName)
        {
            case "ResumeButton":
                ResumeClicked();
                break;
            case "SettingsButton":
                SettingsClicked();
                break;
            case "QuitButton":
                QuitClicked();
                break;
            default:
                Debug.Log($"Nothing set up for {buttonName}!");
                break;
        }
    }

    private void ResumeClicked()
    {
        PauseManager.instance.ResumeGame();
    }

    private void SettingsClicked()
    {
        Debug.Log("Settings menu!");
    }

    private void QuitClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
