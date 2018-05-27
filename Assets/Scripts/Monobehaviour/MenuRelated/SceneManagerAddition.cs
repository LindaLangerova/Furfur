using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerAddition : MonoBehaviour
{
    public GameObject Skip;

    public StreamVideo streamVideo;

    public void LoadC()
    {
        Skip.SetActive(true);
        GameObject.Find("Sounds").GetComponent<AudioSource>().Stop();
        streamVideo.enabled = true;
    }

    private void Update()
    {
        if (streamVideo.videoFinished) SceneManager.LoadScene("C", LoadSceneMode.Single);
    }
}