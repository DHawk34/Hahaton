using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{

    [SerializeField] private GameObject puzzle;

    [SerializeField] private GameObject secondPuzzle;

    [SerializeField] private GameObject exitButton;

    public bool state = false;
    public bool firstClear = false;



    private void OnMouseDown()
    {
        if (state)
        {
            return;
        }

        if (!firstClear)
        {
            puzzle.SetActive(true);
        }
        else
        {
            secondPuzzle.SetActive(true);
        }
        exitButton.SetActive(true);

    }

    public void exitWindow()
    {
        puzzle.SetActive(false);
        exitButton.SetActive(false);
    }
}
