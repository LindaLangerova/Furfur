using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MethodReaction))]
public class MethodReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Method Reaction";
    }
}