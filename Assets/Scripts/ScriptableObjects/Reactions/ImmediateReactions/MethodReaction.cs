using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MethodReaction : DelayedReaction
{
    public UnityEvent theMethod;

    protected override void ImmediateReaction()
    {
        theMethod.Invoke();
    }
}
