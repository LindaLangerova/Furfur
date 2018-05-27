using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FallManager : MonoBehaviour
{

    public GameObject Player;
    private GameObject _UItext;
    private Text _text;

    private float _number;
    
	// Use this for initialization
	void Start ()
	{
	    _UItext = GameObject.Find("UIText");
        _text = _UItext.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Player.transform.position.y < 150)
	    {
	        _UItext.GetComponent<TextManager>().enabled = false;
            onUnderflow();
	    }

	    if (_number < -50000)
	    {
	        SoundManager.PlayPickSound();

            Player.transform.position = new Vector3(416, 210, 0);
            Player.GetComponent<Rigidbody2D>().velocity.Set(0,0);
	        _number = 0;
	        _text.text = "";
	        _UItext.GetComponent<TextManager>().enabled = true;
            _UItext.GetComponent<TextManager>().DisplayMessage("UNDERFLOW", new Color(0.2f, 0.2f, 0.2f), 1);
        }
    }

    void onUnderflow()
    {
        _number = (Player.transform.position.y - 150) * 100;
        _text.text = _number.ToString(CultureInfo.CurrentCulture);
    }
}
