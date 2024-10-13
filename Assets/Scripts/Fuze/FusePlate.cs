using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusePlate : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private int nailsCount = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MinusNail()
    {
        nailsCount -= 1;

        if (nailsCount == 0)
        {
            animator.SetTrigger("DropPlate");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
