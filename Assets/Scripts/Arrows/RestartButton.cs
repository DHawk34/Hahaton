using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Arrows arrowsManager;
    private void OnMouseDown()
    {
        arrowsManager.Restart();
    }
}
