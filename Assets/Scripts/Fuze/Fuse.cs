using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField]
    private InteractableGetItemFromInventory interactable1;
    [SerializeField]
    private InteractableGetItemFromInventory interactable2;
    [SerializeField]
    private InteractableGetItemFromInventory interactable3;
    [SerializeField]
    private InteractableGetItemFromInventory interactable4;

    private int[] winningHand = new int[] {2, 1, 3, 4}; //B A C D
    private int[] currentHand = new int[] {0, 0, 0, 0};


    public void SetFuse1(int id)
    {
        currentHand[0] = id;
        CheckHand();
    }

    public void SetFuse2(int id)
    {
        currentHand[1] = id;
        CheckHand();
    }

    public void SetFuse3(int id)
    {
        currentHand[2] = id;
        CheckHand();
    }

    public void SetFuse4(int id)
    {
        currentHand[3] = id;
        CheckHand();
        
    }

    private void CheckHand() {

        if (Enumerable.SequenceEqual(winningHand, currentHand))
        {
            Debug.Log("Winner");
        }

    }

}
