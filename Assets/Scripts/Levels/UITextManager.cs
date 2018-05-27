using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    public Text text { get; set; }
    public bool coroutineRunning { get; set; }

// Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(WriteDialog(""));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public IEnumerator WriteDialog(string dialog)
    {
        coroutineRunning = true;
        text.text = "";

        for (var i = 0; i < dialog.Length; i++)
        {
            text.text += dialog[i];
            yield return new WaitForSeconds(0.1f);
        }

        if (text.text == dialog)
        {
            StopAllCoroutines();
            coroutineRunning = false;
        }
    }
}