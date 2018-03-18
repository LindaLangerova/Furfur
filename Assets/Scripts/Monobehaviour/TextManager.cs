using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Tizen;

public class TextManager : MonoBehaviour
{
    public struct Instruction
    {
        public string message;
        public Color textColor;
        public float startTime;
    }

    public bool isWriting;
    public Text text;
    public float displayTimePerCharacter = 0.1f;
    public float additionalDisplayTime = 1f;


    private List<Instruction> instructions = new List<Instruction> ();
    private float clearTime;


    private void Update ()
    {
        if (instructions.Count > 0 && Time.time >= instructions[0].startTime)
        {
            //text.text = instructions[0].message;
            text.color = instructions[0].textColor;
            if (text.text.Length < instructions[0].message.Length)
            {
                isWriting = true;
                WriteDialog(instructions[0]);
            }
            else instructions.RemoveAt(0);
        }
        else if (Time.time >= clearTime)
        {
            isWriting = false;
            text.text = string.Empty;
        }
    }


    public void DisplayMessage (string message, Color textColor, float delay)
    {
        float startTime = Time.time + delay;
        float displayDuration = message.Length * displayTimePerCharacter + additionalDisplayTime;
        float newClearTime = startTime + displayDuration;

        if (newClearTime > clearTime)
            clearTime = newClearTime;

        Instruction newInstruction = new Instruction
        {
            message = message,
            textColor = textColor,
            startTime = startTime
        };

        instructions.Add (newInstruction);

        SortInstructions ();
    }

    private void WriteDialog(Instruction instruction)
    {
        var letterCount = (int) Math.Ceiling((Time.time - instruction.startTime) / displayTimePerCharacter);

        text.text = 
            letterCount <= instruction.message.Length ?
                instruction.message.Substring(0, letterCount) : 
                instruction.message;
    }

    private void SortInstructions ()
    {
        for (int i = 0; i < instructions.Count; i++)
        {
            bool swapped = false;

            for (int j = 0; j < instructions.Count; j++)
            {
                if (instructions[i].startTime > instructions[j].startTime)
                {
                    Instruction temp = instructions[i];
                    instructions[i] = instructions[j];
                    instructions[j] = temp;

                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }
}

