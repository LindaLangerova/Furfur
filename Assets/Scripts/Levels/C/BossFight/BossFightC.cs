using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class BossFightC : MonoBehaviour {

    private GameObject _player;
    private GameObject _boss;

    private BoxCollider2D _playerBoxCollider;
    private BoxCollider2D _bossBoxCollider;

    private Rigidbody2D _bossRigidbody;

    private const int BOSS_LIVES = 20;
    

    private Inventory _inventory;
    public Sprite BulletSprite;

    private Slider _slider;

    private Animator BossAnimator;

    public BulletCreator _bulletCreator;
    public float BossMovement = -0.5f;
    public bool _stopped = true;

    

    // Use this for initialization
    void Start ()
	{
	    _player = GameObject.Find("Player");
        _boss = GameObject.Find("NullTerminator");
        BossAnimator = _boss.GetComponent<Animator>();

        _playerBoxCollider = _player.GetComponent<BoxCollider2D>();
	    _bossBoxCollider = _boss.GetComponent<BoxCollider2D>();
	    _bossRigidbody = _boss.GetComponent<Rigidbody2D>();

	    

        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

	    _slider = GameObject.Find("Slider").GetComponent<Slider>();
	    _slider.maxValue = BOSS_LIVES;
	    _slider.value = BOSS_LIVES;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    BossAnimator.SetFloat("velocity", BossMovement);

	    if (_player.transform.position.y < 212 && !_stopped)
            OnLost();

        if (_bossBoxCollider.IsTouching(_playerBoxCollider))
	        OnCollision();
	    if (Input.GetKeyDown(KeyCode.C))
	        OnShot();
	    if (_slider.value <= 0)
	        OnWin();
	    if (_stopped) BossMovement = 0;
	        else BossMovement = -0.5f;
	    if (_player.transform.position.y > 213 && _player.transform.position.x > 436 && _stopped)
	        OnBossFightStart();
	    if (_boss.transform.position.x < 65)
	        OnLost();
    }

    void OnBossFightStart()
    {
        _stopped = false;
    }

    void OnCollision()
    {
        PlayerMovement movement = _player.GetComponent<PlayerMovement>();
        movement.pushed = true;
        movement.PushAway(new Vector2(-4,15));
    }

    void OnShot()
    {
        if (_inventory.ContainsItems())
        {
            _inventory.RemoveLast();
            _bulletCreator.SetBullet(_player.transform.position, _playerBoxCollider);
        }
    }

    void FixedUpdate()
    {
        _bossRigidbody.velocity = new Vector3(BossMovement, 0, 0);
    }
    
    void OnWin()
    {
        GameObject.Find("WinReaction").GetComponent<ReactionCollection>().React();
        _stopped = true;
        BossMovement = 0;
        Destroy(_boss, 9.5f);
        enabled = false;
    }

    void OnLost()
    {
        GameObject.Find("LoseReaction").GetComponent<ReactionCollection>().React();
        _boss.GetComponent<Rigidbody2D>().position = new Vector2(439,215);
        _stopped = true;
        BossAnimator.SetFloat("velocity", 0);
        _slider.value = BOSS_LIVES;
        enabled = false;
    }

}

