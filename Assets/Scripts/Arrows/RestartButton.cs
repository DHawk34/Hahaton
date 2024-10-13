using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Arrows arrowsManager;

    [SerializeField]
    private Sprite[] sprites; // Массив спрайтов для замены

    private void OnMouseDown()
    {
        arrowsManager.Restart();
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    
}
