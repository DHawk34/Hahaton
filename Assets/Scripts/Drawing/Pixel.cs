using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    [SerializeField]
    private Drawing drawManager;

    private bool state = false;

    [SerializeField]
    private int points;


    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = drawManager.sprites[!state ? 1 : 0];

        drawManager.PressedPixel(!state ? points : -points);

        state = !state;
        
    }
}
