using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTrigger : MonoBehaviour
{
    private BoxCollider2D _npcCollider;
    private BoxCollider2D _playerCollider;

    private Interactable _interactable;
    private string _text;

	// Use this for initialization
	void Start ()
    {
        _npcCollider = gameObject.GetComponent<BoxCollider2D>();
        var player = GameObject.Find("Player");
        _playerCollider = player.GetComponent<BoxCollider2D>();

        _text = FindObjectOfType<TextManager>().text.text;

        _interactable = gameObject.GetComponent<Interactable>();
    }
	
	// Update is called once per frame
	void Update () {
	    _text = FindObjectOfType<TextManager>().text.text;
        if (Input.GetKeyDown(KeyCode.X) && _text.Length == 0)
	    {
	        if (_playerCollider.IsTouching(_npcCollider))
	        {
	            _interactable.Interact();
            }
        } 
	}
}
