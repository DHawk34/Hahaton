using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public int ending;
    [SerializeField] private AddCard card;
    // Start is called before the first frame update

    void Awake()
    {
        card.action.AddListener(EnableButton);
    }

    private void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        //LoadScene(ending) Бла бла
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    private void EnableButton()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
