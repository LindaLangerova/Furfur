using UnityEngine;

public class GameObjectReaction : DelayedReaction
{
    public bool activeState;
    public GameObject gameObject;


    protected override void ImmediateReaction()
    {
        gameObject.SetActive(activeState);
    }
}