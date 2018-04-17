using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightC : MonoBehaviour {

    private GameObject _player;
    private GameObject _boss;

    private BoxCollider2D _playerBoxCollider;
    private BoxCollider2D _bossBoxCollider;

    private const int BOSS_LIVES = 20;
    private const int PLAYER_LIVES = 3;

	// Use this for initialization
	void Start ()
	{
	    _player = GameObject.Find("Player");
        _boss = GameObject.Find("NullTerminator");

	    _playerBoxCollider = _player.GetComponent<BoxCollider2D>();
	    _bossBoxCollider = _boss.GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (_bossBoxCollider.IsTouching(_playerBoxCollider))
	        OnCollision();


	}

    void OnCollision()
    {
        PlayerMovement movement = _player.GetComponent<PlayerMovement>();

        movement.pushed = true;
        movement.velocity.x = -10;
        movement.velocity.y = 10;
    }

}
