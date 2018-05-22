using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class SceneManagerAddition : MonoBehaviour
{

    public StreamVideo streamVideo;
    public AllConditions conditions;

    public void LoadC()
    {
        streamVideo.enabled = true;
    }

    void Update()
    {
        if (streamVideo.videoFinished)
        {
            SceneManager.LoadScene("C");
        }
    }
}
