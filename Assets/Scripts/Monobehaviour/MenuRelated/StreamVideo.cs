using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class StreamVideo : MonoBehaviour
{
    public RawImage image;
    //public VideoClip videoToPlay;

    //private VideoPlayer videoPlayer;
    private VideoSource videoSource;
    public VideoPlayer videoPlayer;

    private AudioSource audioSource;
    public bool videoFinished;

    // Use this for initialization
    void Start()
    {
        videoFinished = false;
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {
        
        image.color = new Vector4(0,0,0,1);
        audioSource = videoPlayer.GetComponent<AudioSource>();
        
        videoPlayer.Prepare();
        
        WaitForSeconds waitTime = new WaitForSeconds(5);
        while (!videoPlayer.isPrepared)
        {
            //Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }
        image.texture = videoPlayer.texture;
        image.color = new Vector4(1, 1, 1, 1);
        //Play Video
        audioSource.Play();
        videoPlayer.Play();
        
        while (videoPlayer.isPlaying)
        {
            if (Input.GetKey(KeyCode.X)) {videoPlayer.Stop();}
            //Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        videoFinished = true;
    }
}