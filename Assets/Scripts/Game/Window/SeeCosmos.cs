using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class SeeCosmos : MonoBehaviour
{
    [SerializeField]
    private GameObject Cosmos;

    [SerializeField]
    private GameObject ReturnButton;

    [SerializeField]
    private LocalizedStringTable textTable;

    [SerializeField]
    private DialogueSystem dialogueSystem;

    private void OnMouseDown()
    {
        Cosmos.SetActive(true);
        ReturnButton.SetActive(true);

        dialogueSystem.StartDialogue(textTable);
        AudioManager.Instance.PlaySFX("ShipWindowStars");
    }
}
