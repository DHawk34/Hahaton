using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsPanel; 
    [SerializeField]
    private GameObject mainMenuButtons; //Строго должны быть только кнопки
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ToggleSettings()
    {
        //Как выглядит аудиоменджер
        AudioManager.Instance.PlaySFX("TestClickSound");
        
        optionsPanel.SetActive(!optionsPanel.activeSelf);

        Button[] buttons = mainMenuButtons.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = !button.interactable;
        }
    }
}
