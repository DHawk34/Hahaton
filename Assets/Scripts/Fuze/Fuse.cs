using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField]
    private InteractableGetItemFromInventory slot1;

    [SerializeField]
    private InteractableGetItemFromInventory slot2;

    [SerializeField]
    private InteractableGetItemFromInventory slot3;
    [SerializeField]
    private InteractableGetItemFromInventory slot4;

    private int[] winningHand = new int[] {2, 1, 3, 4}; //B A C D
    private int[] currentHand = new int[] {0, 0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        slot1.actionInt.AddListener(SetFuse1);
        slot2.actionInt.AddListener(SetFuse2);
        slot3.actionInt.AddListener(SetFuse3);
        slot4.actionInt.AddListener(SetFuse4);

    }

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

        Debug.Log(currentHand[0]);
        Debug.Log(currentHand[1]);
        Debug.Log(currentHand[2]);
        Debug.Log(currentHand[3]);


    }

}
