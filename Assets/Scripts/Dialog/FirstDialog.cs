using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class FirstDialog : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable stringTable;

    [SerializeField]
    private DialogueSystem dialogueSys;
    // Start is called before the first frame update
    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dialogueSys.StartDialogue(stringTable);
    }


    // called when the game is terminated
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
