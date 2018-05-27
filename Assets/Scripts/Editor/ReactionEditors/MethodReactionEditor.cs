using UnityEditor;


[CustomEditor(typeof(MethodReaction))]
public class MethodReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Method Reaction";
    }
}