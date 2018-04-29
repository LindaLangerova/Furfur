using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    public GameObject Player;
    public Sprite MeteorSprite;
    public float MeteorSpeed = 0.1f;
    private PlayerMovement _movement;

    private bool _shouldCreateMeteor;
    private bool _shouldMeteorFall;
    
    private GameObject _meteor;

    public bool MountDragon;
    private float _animationTime;

    // Use this for initialization
    void Start ()
    {
        _animationTime = 0;
        MountDragon = false;

        _shouldCreateMeteor = true;
        _shouldMeteorFall = false;
        
        _meteor = GameObject.Find("Meteor");
        _meteor.transform.position = new Vector3(443, 211, 0);


        _meteor.SetActive(false);

        _movement = Player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {

	    if (MountDragon)
	    {
	        OnMountDragon();
	    }
	    else
	    {
	        if (Player.transform.position.y < 206 && Player.transform.position.x > 438.5)
	        {
	            OnMeteor();
	        }
	        if (Player.transform.position.x <= 438.5) _shouldCreateMeteor = true;
        }
    }

    void OnMeteor()
    {
        if (_shouldCreateMeteor)
        {
            GetComponent<Animator>().SetTrigger("CastMeteor");

            _meteor.SetActive(true);
            _meteor.transform.position = new Vector3(443, 211, 0);

            _shouldCreateMeteor = false;
            _shouldMeteorFall = true;
        }

        if (_shouldMeteorFall)
        {
            if (_meteor.transform.position.y < 204.5)
            {
                _movement.pushed = true;
                _movement.PushAway(new Vector2(-17, 5));
                _meteor.transform.position = new Vector3(443, 211, 0);
                 _meteor.SetActive(false);
                _shouldMeteorFall = false;
            }
            else
            {
                _meteor.transform.position += new Vector3(-MeteorSpeed, -2* MeteorSpeed, 0);
            }
        }  
    }

    void OnMountDragon()
    {
        if (_animationTime == 0)
        {
            GetComponent<Animator>().SetTrigger("GodBattle");
            _animationTime += Time.deltaTime;
        }
        else
        {
            Debug.Log(_animationTime);
            if (_animationTime > 11)
            {
                Destroy(GameObject.Find("Flufflekins"));
            }
            _animationTime += Time.deltaTime;
        }
        
    }
    
}
