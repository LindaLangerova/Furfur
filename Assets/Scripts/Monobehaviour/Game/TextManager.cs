using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public float additionalDisplayTime = 1f;
    private float clearTime;
    public float displayTimePerCharacter = 0.1f;


    public List<Instruction> instructions = new List<Instruction>();
    public Text text;

    public bool waitForKey;


    private void Update()
    {
        if (text.text == "" && instructions.Count == 0)
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        else
            GameObject.Find("Player").GetComponent<PlayerMovement>().Stop();

        if (instructions.Count > 0 && Time.time >= instructions[0].startTime)
        {
            text.color = instructions[0].textColor;

            if (text.text.Length < instructions[0].message.Length)
            {
                if (Input.GetKeyDown(KeyCode.X) && waitForKey)
                {
                    text.text = instructions[0].message;
                    clearTime = Time.time + additionalDisplayTime;
                }
                else
                {
                    waitForKey = true;
                    WriteDialog(instructions[0]);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.X) && waitForKey)
                {
                    clearTime = Time.time;
                    instructions.RemoveAt(0);
                    if (instructions.Count > 0)
                    {
                        text.text = "";
                        instructions.First().startTime = Time.time;
                        clearTime = Time.time + instructions.First().message.Length * displayTimePerCharacter +
                                    additionalDisplayTime;
                    }
                }
            }
        }
        else if (Time.time >= clearTime)
        {
            clearTime = Time.time;
            waitForKey = false;
            text.text = string.Empty;
        }
    }

    public void DisplayMessage(string message, Color textColor, float delay)
    {
        var startTime = Time.time + delay;
        var displayDuration = message.Length * displayTimePerCharacter + additionalDisplayTime;
        var newClearTime = startTime + displayDuration;

        if (newClearTime > clearTime)
            clearTime = newClearTime;

        var words = message.Split(' ').ToList();

        var newInstruction = new Instruction {message = "", textColor = textColor, startTime = startTime};

        while (words.Count > 0)
            if ((newInstruction.message + " " + words.First()).Length <= 160)
            {
                if (newInstruction.message != "") newInstruction.message += " ";
                newInstruction.message += words.First();

                words.RemoveAt(0);
            }
            else
            {
                instructions.Add(newInstruction);
                newInstruction = new Instruction {message = "", textColor = textColor, startTime = startTime};
            }

        instructions.Add(newInstruction);

        SortInstructions();
    }

    private void WriteDialog(Instruction instruction)
    {
        var letterCount = (int) Math.Ceiling((Time.time - instruction.startTime) / displayTimePerCharacter);

        text.text =
            letterCount <= instruction.message.Length
                ? instruction.message.Substring(0, letterCount)
                : instruction.message;
    }

    private void SortInstructions()
    {
        for (var i = 0; i < instructions.Count; i++)
        {
            var swapped = false;

            for (var j = 0; j < instructions.Count; j++)
                if (instructions[i].startTime > instructions[j].startTime)
                {
                    var temp = instructions[i];
                    instructions[i] = instructions[j];
                    instructions[j] = temp;

                    swapped = true;
                }

            if (!swapped)
                break;
        }
    }

    public class Instruction
    {
        public string message { get; set; }
        public Color textColor { get; set; }
        public float startTime { get; set; }
        public GameObject player { get; set; }
    }
}