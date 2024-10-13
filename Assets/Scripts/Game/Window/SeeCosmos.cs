using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeCosmos : MonoBehaviour
{
    [SerializeField]
    private GameObject Cosmos;

    [SerializeField]
    private GameObject ReturnButton;

    private void OnMouseDown()
    {
        Cosmos.SetActive(true);
        ReturnButton.SetActive(true);
    }
}
