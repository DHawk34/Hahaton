using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField]
    private Music musicManager;
    
    private int musicNumber;

    private bool state = false;



    private void Start() {

        musicNumber = gameObject.name[0] - '0';

        musicManager.Restart.AddListener(UnPressButton); // Подписываемся на событие
    
    }

    private void UnPressButton()
    {
        state = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = musicManager.sprites[0];
    }

    private void OnMouseDown()
    {
        if (!state)
        {
            //Когда появяться звуки, раскоментить
            // AudioManager.Instance.PlaySFX($"Music Puzzle {musicNumber}");
            gameObject.GetComponent<SpriteRenderer>().sprite = musicManager.sprites[1];
            state = true;

            Debug.Log(musicNumber);

            musicManager.CheckHand(musicNumber);
        }
    }

}
