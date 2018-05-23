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
    public GameObject Skip;

    public void LoadC()
    {
        Skip.SetActive(true);
        GameObject.Find("Sounds").GetComponent<AudioSource>().Stop();
        streamVideo.enabled = true;
    }

    void Update()
    {
        if (streamVideo.videoFinished)
        {
            SceneManager.LoadScene("C", LoadSceneMode.Single);
        }
    }
}
