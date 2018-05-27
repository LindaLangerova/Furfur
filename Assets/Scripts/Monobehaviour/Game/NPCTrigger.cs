using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    private Interactable _interactable;
    private BoxCollider2D _npcCollider;
    private BoxCollider2D _playerCollider;
    private string _text;

    private GameObject _whiter;

    // Use this for initialization
    private void Start()
    {
        _npcCollider = gameObject.GetComponent<BoxCollider2D>();
        var player = GameObject.Find("Player");
        _playerCollider = player.GetComponent<BoxCollider2D>();

        _text = FindObjectOfType<TextManager>().text.text;

        _interactable = gameObject.GetComponent<Interactable>();
    }

    // Update is called once per frame
    private void Update()
    {
        _text = FindObjectOfType<TextManager>().text.text;
        _whiter = GameObject.Find("Whiter");

        if (_whiter) return;
        if (Input.GetKeyDown(KeyCode.X) && _text.Length == 0)
            if (_playerCollider.IsTouching(_npcCollider))
            {
                SoundManager.PlayPickSound();
                _interactable.Interact();
            }
            else
            {
                SoundManager.PlayErrorPickSound(FindObjectOfType<TextManager>().instructions.Count);
            }
    }
}