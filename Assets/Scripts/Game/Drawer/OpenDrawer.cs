using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    [SerializeField] private bool haveScrewdriver = true;

    [SerializeField] private GameObject drawer;


    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite firstState;
    [SerializeField] private Sprite secondState;

    [SerializeField] private GameObject exitButton;


    private void Awake()
    {
        spriteRenderer = drawer.GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        drawer.SetActive(true);
        exitButton.SetActive(true);

        if (!haveScrewdriver)
        {
            spriteRenderer.sprite = secondState;
        }
        else
        {
            spriteRenderer.sprite = firstState;
        }
    }

    public void ChangeSprite()
    {
        spriteRenderer.sprite = secondState;
        haveScrewdriver = false;
    }

    public void exitWindow()
    {
        drawer.SetActive(false);
        exitButton.SetActive(false);
    }
}
