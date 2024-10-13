using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class Mixer : MonoBehaviour
{
    [SerializeField]
    private MixerRotate mixer1;
    [SerializeField]
    private MixerRotate mixer2;
    [SerializeField]
    private MixerRotate mixer3;

    [SerializeField]
    private LocalizedStringTable stringTable;

    [SerializeField]
    private DialogueSystem dialogueSystem;

    [SerializeField]
    private RoomControls roomControls;

    [SerializeField]
    private Transform newRoom;

    private int[] winningHand = new int[] {315, 90, 225};


    public void checkIfWin()
    {
        if (mixer1.GetAngle() == winningHand[0] && mixer2.GetAngle() == winningHand[1] && mixer3.GetAngle() == winningHand[2])
        {
            dialogueSystem.StartDialogue(stringTable);
            roomControls.goToRoom(newRoom);
            AudioManager.Instance.PlaySFX("electricSound");
            Debug.Log("WinNNER");
        }
    }
}
