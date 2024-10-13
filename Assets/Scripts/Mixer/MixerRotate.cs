using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MixerRotate : MonoBehaviour
{

    [SerializeField]
    private Mixer mixerManager;

    [SerializeField]
    private TextMeshProUGUI angleGauge;

    private int mixerNumber;

    private float angle = 0;

    [SerializeField]
    private Sprite[] sprites; // Массив спрайтов для замены

    private SpriteRenderer spriteRenderer;

    int spriteCounter = 1;

    private void Start()
    {

        mixerNumber = gameObject.name[0] - '0';
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    public int GetAngle()
    {
        return (int)angle;
    }

    private void OnMouseDown()
    {
        // Вращаем спрайт на 15 градусов
        // transform.Rotate(0, 0, -45f);

        // Обновляем угол
        angle += 45f;

        if (angle > 359)
        {
            angle = 0;
        }

        spriteRenderer.sprite = sprites[spriteCounter];

        spriteCounter += 1;

        if (spriteCounter == 8)
        {
            spriteCounter = 0;
        }

        angleGauge.text = angle.ToString();

        mixerManager.checkIfWin();

        AudioManager.Instance.PlaySFX("SpiningWheel");
    }

}
