using UnityEngine;

public class TextReaction : Reaction
{
    public float delay;
    public string message;
    public Color textColor = new Color(0.184f, 0.184f, 0.184f, 1f);


    private TextManager textManager;


    protected override void SpecificInit()
    {
        textManager = FindObjectOfType<TextManager>();
    }


    protected override void ImmediateReaction()
    {
        if (!textManager.waitForKey) textManager.DisplayMessage(message, textColor, delay);
    }
}