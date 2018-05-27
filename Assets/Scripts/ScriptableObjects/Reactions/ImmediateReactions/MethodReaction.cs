using UnityEngine.Events;

public class MethodReaction : DelayedReaction
{
    public UnityEvent theMethod;

    protected override void ImmediateReaction()
    {
        theMethod.Invoke();
    }
}
