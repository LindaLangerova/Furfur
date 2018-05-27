using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    private static AudioSource _pickSound;

    private static AudioSource _localMucis;
    
    private bool _soundEnabled;

    void Start()
    {
        _localMucis = GetComponent<AudioSource>();
        _pickSound = GameObject.Find("PickSound").GetComponent<AudioSource>();
        _soundEnabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _soundEnabled = !_soundEnabled;
            _localMucis.mute = !_soundEnabled;
        }
        if(_pickSound) _pickSound.enabled = _pickSound.isPlaying && _soundEnabled;
    }

    public static void PlayPickSound()
    {
        _pickSound.enabled = true;
    }
}
