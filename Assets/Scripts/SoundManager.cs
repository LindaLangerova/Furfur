using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static AudioSource _walkSound;
    private static AudioSource _jumpSound;
    private static AudioSource _pickSound;
    private static AudioSource _errorPickSound;
    private static AudioSource _shootSound;


    private Animator _playerAnimator;

    private float _velocityX;
    private float _velocityY;
    
    private bool _grounded;
    
    void Start ()
    {
        _walkSound = GameObject.Find("WalkSound").GetComponent<AudioSource>();
        _jumpSound = GameObject.Find("JumpSound").GetComponent<AudioSource>();
        _pickSound = GameObject.Find("PickSound").GetComponent<AudioSource>();
        _errorPickSound = GameObject.Find("ErrorPickSound").GetComponent<AudioSource>();
        _shootSound = GameObject.Find("ShootSound").GetComponent<AudioSource>();

        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }
	
	void Update ()
	{
	    _velocityX = _playerAnimator.GetFloat("velocityX");
        _velocityY = _playerAnimator.GetFloat("velocityY");
	    _grounded = _playerAnimator.GetBool("grounded");

	    _walkSound.enabled = _grounded && _velocityX >= 0.3;
	    _jumpSound.enabled = _jumpSound.isPlaying && _jumpSound.enabled || _velocityY > 0;


        _errorPickSound.enabled = _errorPickSound.isPlaying;
        _pickSound.enabled = _pickSound.isPlaying;
	    _shootSound.enabled = _shootSound.isPlaying;

	}

    public static void PlayPickSound()
    {
        _pickSound.enabled = true;
    }

    public static void PlayErrorPickSound(int numberOfInstructions)
    {
        if(numberOfInstructions == 0)
        _errorPickSound.enabled = !_pickSound.enabled;
        else _errorPickSound.enabled = false;
    }

    public static void PlayShootSound()
    {
        _shootSound.enabled = true;
    }
}
