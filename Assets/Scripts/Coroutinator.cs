using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coroutinator : MonoBehaviour
{
    public Coroutine DoCoroutine(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }
}
