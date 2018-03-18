using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelC : MonoBehaviour {
    /**
    private string[] _levelPhrases;
    private UITextManager _UITextManager;
    private PlayerMovement _playerMovement;

	// Use this for initialization
	void Start () {
        _UITextManager = (UITextManager) GameObject.Find("UIText").GetComponent("UITextManager");
        _playerMovement = GetComponent<PlayerMovement>(); 
        _levelPhrases = new string[]{
            "Heyheyy blabla ja jsem tucnak olala", //Tux 1
            "Heyheyy blabla uz jsi se mnou mluvil...", //Tux 2
            "strrriiiing",
            "strrriiiing2"
            };
        
    }

    // Update is called once per frame
    void Update() {
        if (_UITextManager.text.text != "")
        {
            _playerMovement.enabled = false;
        }else
        {
            _playerMovement.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (collision.gameObject.name == "Tux" && !_UITextManager.coroutineRunning)
            {
                if (_UITextManager.text.text == _levelPhrases[0])
                {
                    _UITextManager.text.text = "";
                }
                else StartCoroutine(_UITextManager.WriteDialog(_levelPhrases[0]));
            }

        }
    }**/

}
