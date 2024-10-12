using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ApplyMixerButton : MonoBehaviour
{
    [SerializeField]
    private Mixer MixerManager; 

    private void OnMouseDown()
    {
        MixerManager.checkIfWin();
    }
}
