using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    [SerializeField]
    private InOutItemInteractable slot1;

    [SerializeField]
    private InOutItemInteractable slot2;

    [SerializeField]
    private InOutItemInteractable slot3;
    [SerializeField]
    private InOutItemInteractable slot4;

    [SerializeField]
    private BoxCollider2D slotCollider1;
    [SerializeField]
    private BoxCollider2D slotCollider2;
    [SerializeField]
    private BoxCollider2D slotCollider3;
    [SerializeField]
    private BoxCollider2D slotCollider4;

    private int[] winningHand = new int[] {3, 2, 1}; //C B A
    private int[] currentHand = new int[] {0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        slot1.actionInt.AddListener(SetFuse1);
        slot2.actionInt.AddListener(SetFuse2);
        slot3.actionInt.AddListener(SetFuse3);

        slot1.actionRemoveInt.AddListener(UnSetFuse1);
        slot2.actionRemoveInt.AddListener(UnSetFuse2);
        slot3.actionRemoveInt.AddListener(UnSetFuse3);

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

    public void UnSetFuse1(int id)
    {
        currentHand[0] = 0;
        CheckHand();
    }

    public void UnSetFuse2(int id)
    {
        currentHand[1] = 0;
        CheckHand();
    }

    public void UnSetFuse3(int id)
    {
        currentHand[2] = 0;
        CheckHand();
    }

    private void CheckHand() {

        if (Enumerable.SequenceEqual(winningHand, currentHand))
        {
            Debug.Log("Winner");
            slotCollider1.enabled = false;
            slotCollider2.enabled = false;
            slotCollider3.enabled = false;
            slotCollider4.enabled = false;

            return;
        }


        Debug.Log(currentHand[0]);
        Debug.Log(currentHand[1]);
        Debug.Log(currentHand[2]);

    }

}
