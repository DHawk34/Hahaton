using System.Collections;
using UnityEngine;

public class WaitState : StateMachineBehaviour
{
    const int minDelay = 3;
    const int maxDelay = 10;

    private Coroutinator coroutinator;
    private readonly System.Random rand = new();

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        coroutinator = animator.GetComponent<Coroutinator>();
        coroutinator.DoCoroutine(WaitUntil(animator));
    }

    IEnumerator WaitUntil(Animator animator)
    {
        var seconds = rand.Next(minDelay, maxDelay);
        yield return new WaitForSeconds(seconds);

        bool isSmall = rand.NextDouble() > 0.1f;
        animator.SetTrigger(isSmall ? "Small glitch" : "Big glitch");
    }
}
