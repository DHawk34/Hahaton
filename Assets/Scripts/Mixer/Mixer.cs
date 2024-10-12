using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    [SerializeField]
    private MixerRotate mixer1;
    [SerializeField]
    private MixerRotate mixer2;
    [SerializeField]
    private MixerRotate mixer3;

    private int[] winningHand = new int[] {300, 75, 45};


    public void checkIfWin()
    {
        if (mixer1.GetAngle() == winningHand[0] && mixer2.GetAngle() == winningHand[1] && mixer3.GetAngle() == winningHand[2])
        {
            Debug.Log("WinNNER");
        }
    }
}
