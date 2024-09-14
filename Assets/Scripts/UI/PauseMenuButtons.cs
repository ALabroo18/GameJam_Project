using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuButtons : MonoBehaviour
{
    private UIDocument document;

    private Button button;

    private List<Button> pauseButtons;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Q("ResumeButton") as Button;
        button.RegisterCallback<ClickEvent>(OnResumeClick);

        pauseButtons = document.rootVisualElement.Query<Button>().ToList();

        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnResumeClick); 
        
        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnEnable()
    {
        button.RegisterCallback<ClickEvent>(OnResumeClick);

        for (int i = 0; i < pauseButtons.Count; i++)
        {
            pauseButtons[i].RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    private void OnResumeClick(ClickEvent click)
    {
        PauseManager.instance.ResumeGame();
    }

    private void OnAllButtonsClick(ClickEvent click)
    {
        
    }
}
