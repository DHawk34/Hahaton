using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spriteObjects; // Массив объектов со спрайтами

    [SerializeField]
    private Sprite[] sprites; // Массив спрайтов для замены

    private CellArrow[] spriteCellArrow =  new CellArrow[7];

    [SerializeField]
    private GameObject mixer;

    [SerializeField]
    private OpenPuzzle openPuzzle;

    private void Start() {
        for (int i = 0; i < spriteObjects.Length; i++)
        {
            spriteCellArrow[i] = spriteObjects[i].GetComponent<CellArrow>();

            // Debug.Log(spriteObjects[i]);
            // Debug.Log(spriteCellArrow[i]);

        }
    }

    public void SpriteClicker(int cellNum)
    {

        if (cellNum < 8 && cellNum > 0)
        {
            if (spriteCellArrow[cellNum - 1].currentState == CellArrow.ArrowCellState.Up)
            {
                if (cellNum < 7)
                    {         
                        if (spriteCellArrow[cellNum].currentState == CellArrow.ArrowCellState.None)
                        {
                            Sprite temp = spriteObjects[cellNum].GetComponent<SpriteRenderer>().sprite;
                            spriteObjects[cellNum].GetComponent<SpriteRenderer>().sprite = spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite;
                            spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite = temp;


                            CellArrow.ArrowCellState tempState = spriteCellArrow[cellNum].currentState;
                            spriteCellArrow[cellNum].currentState = spriteCellArrow[cellNum - 1].currentState;
                            spriteCellArrow[cellNum - 1].currentState = tempState;

                            CheckIfWin();
                            return;
                        }
                    }

                if (cellNum + 1 < 7)
                    {
                        if (spriteCellArrow[cellNum + 1].currentState == CellArrow.ArrowCellState.None)
                        {
                            Sprite temp = spriteObjects[cellNum + 1].GetComponent<SpriteRenderer>().sprite;
                            spriteObjects[cellNum + 1].GetComponent<SpriteRenderer>().sprite = spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite;
                            spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite = temp;

                            CellArrow.ArrowCellState tempState = spriteCellArrow[cellNum + 1].currentState;
                            spriteCellArrow[cellNum + 1].currentState = spriteCellArrow[cellNum - 1].currentState;
                            spriteCellArrow[cellNum - 1].currentState = tempState;

                            CheckIfWin();
                            return;
                        }
                    }
            }

            if (spriteCellArrow[cellNum - 1].currentState == CellArrow.ArrowCellState.Down)
            {
                if (cellNum - 2 > -1)
                {
                    if (spriteCellArrow[cellNum - 2].currentState == CellArrow.ArrowCellState.None)
                    {
                        Sprite temp = spriteObjects[cellNum - 2].GetComponent<SpriteRenderer>().sprite;
                        spriteObjects[cellNum - 2].GetComponent<SpriteRenderer>().sprite = spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite;
                        spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite = temp;

                        CellArrow.ArrowCellState tempState = spriteCellArrow[cellNum - 2].currentState;
                        spriteCellArrow[cellNum - 2].currentState = spriteCellArrow[cellNum - 1].currentState;
                        spriteCellArrow[cellNum - 1].currentState = tempState;

                        CheckIfWin();
                        return;
                    }
                }

                if (cellNum - 3 > -1)
                {
                    if (spriteCellArrow[cellNum - 3].currentState == CellArrow.ArrowCellState.None)
                    {
                        Sprite temp = spriteObjects[cellNum - 3].GetComponent<SpriteRenderer>().sprite;
                        spriteObjects[cellNum - 3].GetComponent<SpriteRenderer>().sprite = spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite;
                        spriteObjects[cellNum - 1].GetComponent<SpriteRenderer>().sprite = temp;

                        CellArrow.ArrowCellState tempState = spriteCellArrow[cellNum - 3].currentState;
                        spriteCellArrow[cellNum - 3].currentState = spriteCellArrow[cellNum - 1].currentState;
                        spriteCellArrow[cellNum - 1].currentState = tempState;

                        CheckIfWin();
                        return;
                    }
                }                
            }

        }
    }

    private void CheckIfWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (spriteCellArrow[i].currentState != CellArrow.ArrowCellState.Down)
            {
                return;
            }
        }

        if (spriteCellArrow[3].currentState != CellArrow.ArrowCellState.None)
        {
            return;
        }

        for (int i = 4; i < 7; i++)
        {
            if (spriteCellArrow[i].currentState != CellArrow.ArrowCellState.Up)
            {
                return;
            }
        }

        mixer.SetActive(true);
        openPuzzle.firstClear = true;

        // Debug.Log("WINNER CheckER");
    }

    public void Restart()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteCellArrow[i].currentState = CellArrow.ArrowCellState.Up;
            spriteObjects[i].GetComponent<SpriteRenderer>().sprite = sprites[0];
        }

        spriteCellArrow[3].currentState = CellArrow.ArrowCellState.None;
        spriteObjects[3].GetComponent<SpriteRenderer>().sprite = sprites[1];

        for (int i = 4; i < 7; i++)
        {
            spriteCellArrow[i].currentState = CellArrow.ArrowCellState.Down;
            spriteObjects[i].GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
    }


}
