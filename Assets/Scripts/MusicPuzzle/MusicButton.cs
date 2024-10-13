using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    private Music musicManager;
    
    private int musicNumber;

    private bool state = false;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] sprites;

    private void Start() {

        musicNumber = gameObject.name[0] - '0';

        musicManager.Restart.AddListener(UnPressButton); // Подписываемся на событие

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    
    }


    private void OnMouseDown()
    {
        if (!state)
        {
            //Когда появяться звуки, раскоментить
            // AudioManager.Instance.PlaySFX($"Music Puzzle {musicNumber}");
            // gameObject.GetComponent<SpriteRenderer>().sprite = musicManager.sprites[1];
            state = true;

            Debug.Log(musicNumber);

            spriteRenderer.sprite = sprites[1];

            musicManager.CheckHand(musicNumber);
            // spriteRenderer.enabled = false;
        }
    }

    private void UnPressButton()
    {
        state = false;

        spriteRenderer.sprite = sprites[0];

        //Звук с неудачным вводом
        // AudioManager.Instance.PlaySFX("");
        // gameObject.GetComponent<SpriteRenderer>().sprite = musicManager.sprites[0];
    }

}
