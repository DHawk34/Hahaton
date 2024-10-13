using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    
    [SerializeField] private GameObject puzzle;



    [SerializeField] private GameObject exitButton;

    private void OnMouseDown()
    {
        puzzle.SetActive(true);
        exitButton.SetActive(true);

    }

    public void exitWindow()
    {
        puzzle.SetActive(false);
        exitButton.SetActive(false);
    }
}
