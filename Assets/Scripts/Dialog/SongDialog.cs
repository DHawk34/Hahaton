using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class SongDialog : MonoBehaviour
{
    [SerializeField]
    private LocalizedStringTable stringTableSilence;

    [SerializeField]
    private LocalizedStringTable stringTablenotSilence;

    [SerializeField]
    private DialogueSystem dialogueSystem;

    private void OnMouseDown()
    {
        if (AudioManager.Instance.overallVolume == 0)
        {
            dialogueSystem.StartDialogue(stringTableSilence);
        }
        else
        {
            dialogueSystem.StartDialogue(stringTablenotSilence);
        }
    }
}
