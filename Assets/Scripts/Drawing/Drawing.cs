using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites; // Массив спрайтов

    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PressedPixel(int points)
    {
        this.points += points;
        checkIfWin();
    }

    public void checkIfWin()
    {
        if (points == 18)
        {
            Debug.Log("WinNNER");
        }
    }
}
