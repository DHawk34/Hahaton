using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private bool haveScrewdriver = false;

    [SerializeField] private GameObject drawer;


    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite firstState;
    [SerializeField] private Sprite secondState;

    private void Awake()
    {
        spriteRenderer = drawer.GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        if (haveScrewdriver)
        {
            spriteRenderer.sprite = secondState;
        }
        else
        {
            spriteRenderer.sprite = firstState;
        }
    }
}
