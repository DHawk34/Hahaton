using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Music : MonoBehaviour
{
    public UnityEvent Restart; // Событие для изменения состояния кнопок

    private int[] winningHand = new int[] {4, 2, 3, 1, 5};
    private int[] currentHand = new int[] {0, 0, 0, 0, 0};
    private int currentHandCounter = 0;

    [SerializeField]
    public Sprite[] sprites; // Массив спрайтов

    private void Start() {

        if (Restart == null)
            Restart = new UnityEvent();
        
    
    }

    public void CheckHand(int buttonId) {

        currentHand[currentHandCounter] = buttonId;

        currentHandCounter += 1;

        if (currentHandCounter == 5)
        {
            currentHandCounter = 0;

            if (Enumerable.SequenceEqual(winningHand, currentHand))
            {
                Debug.Log("Winner");
            }
            else
            {
                Restart.Invoke();
            }
        }

    }
}
