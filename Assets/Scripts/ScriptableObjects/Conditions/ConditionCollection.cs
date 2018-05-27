using UnityEngine;

public class ConditionCollection : ScriptableObject
{
    public string description;
    public ReactionCollection reactionCollection;
    public Condition[] requiredConditions = new Condition[0];


    public bool CheckAndReact()
    {
        for (var i = 0; i < requiredConditions.Length; i++)
            if (!AllConditions.CheckCondition(requiredConditions[i]))
                return false;

        if (reactionCollection)
            reactionCollection.React();

        return true;
    }
}