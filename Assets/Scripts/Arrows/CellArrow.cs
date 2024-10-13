using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CellArrow : MonoBehaviour
{
    [SerializeField]
    private Arrows arrowsManager;

    public enum ArrowCellState
    {
        Up,
        Down,
        None
    }

    // Текущее состояние игры
    public ArrowCellState currentState;
    private int cellNumber;

    private void Start() {
        cellNumber = gameObject.name[0] - '0';
    }

    private void OnMouseDown()
    {
        if (currentState != ArrowCellState.None)
        {
            AudioManager.Instance.PlaySFX("TestClickSound");
            arrowsManager.SpriteClicker(cellNumber);
        }
    }

}
