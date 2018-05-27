using UnityEngine;

public class ReactionCollection : MonoBehaviour
{
    public Reaction[] reactions = new Reaction[0];


    private void Start()
    {
        for (var i = 0; i < reactions.Length; i++)
        {
            var delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.Init();
            else
                reactions[i].Init();
        }
    }


    public void React()
    {
        for (var i = 0; i < reactions.Length; i++)
        {
            var delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.React(this);
            else
                reactions[i].React(this);
        }
    }
}