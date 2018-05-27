using System.Linq;
using UnityEngine;

public class terminal : MonoBehaviour
{
    private Inventory _inventory;
    private TextManager _textManager;

    // Use this for initialization
    private void Start()
    {
        _textManager = FindObjectOfType<TextManager>();
        _inventory = FindObjectOfType<Inventory>();
        enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inventory.items.Count(item => item != null) >= 6)
        {
            _textManager.instructions.RemoveAt(0);
            _textManager.DisplayMessage("Inventory full", new Color(0.2f, 0.2f, 0.2f), 0);
            enabled = false;
        }
    }
}