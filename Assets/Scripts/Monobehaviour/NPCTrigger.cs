using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private BoxCollider2D _npcCollider;
    private BoxCollider2D _playerCollider;

    private Interactable _interactable;

	// Use this for initialization
	void Start ()
    {
        _npcCollider = gameObject.GetComponent<BoxCollider2D>();
        var player = GameObject.Find("Player");
        _playerCollider = player.GetComponent<BoxCollider2D>();

        _interactable = gameObject.GetComponent<Interactable>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.X))
	    {
	        if (_playerCollider.IsTouching(_npcCollider))
	        {
	            _interactable.Interact();
            }
        } 
	}
}
