using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public UnityEvent Restart; // Событие для изменения состояния кнопок

    private int[] winningHand = new int[] {4, 2, 3, 1, 5};
    private int[] currentHand = new int[] {0, 0, 0, 0, 0};
    private int currentHandCounter = 0;

    [SerializeField]
    private BoxCollider2D card;

    [SerializeField]
    private BoxCollider2D slot1;
    [SerializeField]
    private BoxCollider2D slot2;
    [SerializeField]
    private BoxCollider2D slot3;
    [SerializeField]
    private BoxCollider2D slot4;
    [SerializeField]
    private BoxCollider2D slot5;


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
                ShowCard();
                UnableButtons();
            }
            else
            {
                Restart.Invoke();
            }
        }

    }

    private void ShowCard()
    {
        card.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    public void DeShowCard()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
		//SceneManager.LoadScene("Ending", LoadSceneMode.Single);
	}

    private void UnableButtons()
    {
        slot1.enabled = false;
        slot2.enabled = false;
        slot3.enabled = false;
        slot4.enabled = false;
        slot5.enabled = false;

    }
}
