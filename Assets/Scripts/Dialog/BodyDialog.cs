using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class BodyDialog : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable stringTable;

    [SerializeField]
    private DialogueSystem dialogueSystem;

    private void OnMouseDown()
    {
        dialogueSystem.StartDialogue(stringTable);
    }
}
