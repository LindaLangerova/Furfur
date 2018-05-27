using UnityEngine;
using UnityEngine.SceneManagement;

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
