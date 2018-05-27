using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ReactionCollection))]
public class ReactionCollectionEditor : EditorWithSubEditors<ReactionEditor, Reaction>
{
    private const float dropAreaHeight = 50f;
    private const float controlSpacing = 5f;
    private const string reactionsPropName = "reactions";


    private readonly float verticalSpacing = EditorGUIUtility.standardVerticalSpacing;
    private ReactionCollection reactionCollection;
    private SerializedProperty reactionsProperty;
    private string[] reactionTypeNames;

    private Type[] reactionTypes;
    private int selectedIndex;


    private void OnEnable()
    {
        reactionCollection = (ReactionCollection) target;

        reactionsProperty = serializedObject.FindProperty(reactionsPropName);

        CheckAndCreateSubEditors(reactionCollection.reactions);

        SetReactionNamesArray();
    }


    private void OnDisable()
    {
        CleanupEditors();
    }


    protected override void SubEditorSetup(ReactionEditor editor)
    {
        editor.reactionsProperty = reactionsProperty;
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CheckAndCreateSubEditors(reactionCollection.reactions);

        for (var i = 0; i < subEditors.Length; i++) subEditors[i].OnInspectorGUI();

        if (reactionCollection.reactions.Length > 0)
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        var fullWidthRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none,
            GUILayout.Height(dropAreaHeight + verticalSpacing));

        var leftAreaRect = fullWidthRect;
        leftAreaRect.y += verticalSpacing * 0.5f;
        leftAreaRect.width *= 0.5f;
        leftAreaRect.width -= controlSpacing * 0.5f;
        leftAreaRect.height = dropAreaHeight;

        var rightAreaRect = leftAreaRect;
        rightAreaRect.x += rightAreaRect.width + controlSpacing;

        TypeSelectionGUI(leftAreaRect);
        DragAndDropAreaGUI(rightAreaRect);

        DraggingAndDropping(rightAreaRect, this);

        serializedObject.ApplyModifiedProperties();
    }


    private void TypeSelectionGUI(Rect containingRect)
    {
        var topHalf = containingRect;
        topHalf.height *= 0.5f;

        var bottomHalf = topHalf;
        bottomHalf.y += bottomHalf.height;

        selectedIndex = EditorGUI.Popup(topHalf, selectedIndex, reactionTypeNames);

        if (GUI.Button(bottomHalf, "Add Selected Reaction"))
        {
            var reactionType = reactionTypes[selectedIndex];
            var newReaction = ReactionEditor.CreateReaction(reactionType);
            reactionsProperty.AddToObjectArray(newReaction);
        }
    }


    private static void DragAndDropAreaGUI(Rect containingRect)
    {
        var centredStyle = GUI.skin.box;
        centredStyle.alignment = TextAnchor.MiddleCenter;
        centredStyle.normal.textColor = GUI.skin.button.normal.textColor;

        GUI.Box(containingRect, "Drop new Reactions here", centredStyle);
    }


    private static void DraggingAndDropping(Rect dropArea, ReactionCollectionEditor editor)
    {
        var currentEvent = Event.current;

        if (!dropArea.Contains(currentEvent.mousePosition))
            return;

        switch (currentEvent.type)
        {
            case EventType.DragUpdated:

                DragAndDrop.visualMode = IsDragValid() ? DragAndDropVisualMode.Link : DragAndDropVisualMode.Rejected;
                currentEvent.Use();

                break;
            case EventType.DragPerform:

                DragAndDrop.AcceptDrag();

                for (var i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    var script = DragAndDrop.objectReferences[i] as MonoScript;

                    var reactionType = script.GetClass();

                    var newReaction = ReactionEditor.CreateReaction(reactionType);
                    editor.reactionsProperty.AddToObjectArray(newReaction);
                }

                currentEvent.Use();

                break;
        }
    }


    private static bool IsDragValid()
    {
        for (var i = 0; i < DragAndDrop.objectReferences.Length; i++)
        {
            if (DragAndDrop.objectReferences[i].GetType() != typeof(MonoScript))
                return false;

            var script = DragAndDrop.objectReferences[i] as MonoScript;
            var scriptType = script.GetClass();

            if (!scriptType.IsSubclassOf(typeof(Reaction)))
                return false;

            if (scriptType.IsAbstract)
                return false;
        }

        return true;
    }


    private void SetReactionNamesArray()
    {
        var reactionType = typeof(Reaction);

        var allTypes = reactionType.Assembly.GetTypes();

        var reactionSubTypeList = new List<Type>();

        for (var i = 0; i < allTypes.Length; i++)
            if (allTypes[i].IsSubclassOf(reactionType) && !allTypes[i].IsAbstract)
                reactionSubTypeList.Add(allTypes[i]);

        reactionTypes = reactionSubTypeList.ToArray();

        var reactionTypeNameList = new List<string>();

        for (var i = 0; i < reactionTypes.Length; i++) reactionTypeNameList.Add(reactionTypes[i].Name);

        reactionTypeNames = reactionTypeNameList.ToArray();
    }
}