using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drawing : MonoBehaviour
{
    [SerializeField]
    public Sprite[] sprites; // Массив спрайтов

    private int points = 0;

    [SerializeField]
    public PolygonCollider2D beated;


    [SerializeField]
    public GameObject blur;

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
            beated.enabled = true;
            blur.SetActive(true);
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            Debug.Log("WinNNER");
        }
    }
}
