using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MixerRotate : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI angleGauge;

    private int mixerNumber;

    private float angle = 0;

    private void Start() {

        mixerNumber = gameObject.name[0] - '0';
    }


    public int GetAngle()
    {
        return (int)angle;
    }

    private void OnMouseDown()
    {
            // Вращаем спрайт на 15 градусов
            transform.Rotate(0, 0, -15f);

            // Обновляем угол
            angle += 15f;

            if (angle > 359 )
            {
                angle = 0;
            }

            angleGauge.text = angle.ToString();
    }

}
