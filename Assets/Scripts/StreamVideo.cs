using System.Collections;
using System.Collections.Generic;
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
        
        image.color = new Vector4(1,1,1,1);
        audioSource = videoPlayer.GetComponent<AudioSource>();
        //Add VideoPlayer to the GameObject
        //videoPlayer = gameObject.AddComponent<VideoPlayer>();

        //Add AudioSource
        //audioSource = gameObject.AddComponent<AudioSource>();

        //Disable Play on Awake for both Video and Audio
        //videoPlayer.playOnAwake = false;
        //audioSource.playOnAwake = false;
        //audioSource.Pause();

        //Set Audio Output to AudioSource
        //videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        //Assign the Audio from Video to AudioSource to be played
        //videoPlayer.EnableAudioTrack(0, true);
        //videoPlayer.SetTargetAudioSource(0, audioSource);
        //We want to play from video clip not from url
        //videoPlayer.source = VideoSource.Url;



        //Set video To Play then prepare Audio to prevent Buffering
        /**videoPlayer.url = "https://www.fi.muni.cz/~xlanger3/Furfur/intro.mp4";**/



        //audioSource = videoPlayer.GetComponent<AudioSource>();
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(5);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            //Prepare/Wait for 5 sceonds only
            yield return waitTime;
            //Break out of the while loop after 5 seconds wait
            break;
        }

        

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        audioSource.Play();
        videoPlayer.Play();

        //Play Sound
        //Debug.Log(audioSource.clip);
        //audioSource.Play();
        
        while (videoPlayer.isPlaying)
        {
            Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
            yield return null;
        }

        videoFinished = true;
    }
}