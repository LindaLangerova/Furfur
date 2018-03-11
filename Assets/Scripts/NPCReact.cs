using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCReact : MonoBehaviour {

    public Rigidbody2D Player;
    private GameObject NPC;

	// Use this for initialization
	void Start () {
        NPC = GameObject.Find("Tux");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
            if ((NPC.GetComponent<Rigidbody2D>().position - Player.position).magnitude < 0.5)
            {
                ShowDialog();
            }
           
        }

    void ShowDialog()
    {
        GameObject dialog = GameObject.Find("DialogPicture");
        dialog.transform.position = NPC.transform.position + new Vector3(-0.5f,1f,0f);
        SpriteRenderer sprite = dialog.GetComponent<SpriteRenderer>();
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
    }
	
}
