using UnityEngine;

public class AudioReaction : Reaction
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float delay;


    protected override void ImmediateReaction()
    {
        audioSource.clip = audioClip;
        audioSource.PlayDelayed(delay);
    }
}