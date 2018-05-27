using UnityEngine;

public class NodeGod : MonoBehaviour
{

    public GameObject Player;
    public Dragon DragonScript;
    public Animator Animator;

    private bool shouldTrigger;

    // Use this for initialization
    void Start ()
    {
        shouldTrigger = true;
        enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (shouldTrigger)
	    {
	        Animator.SetTrigger("GodComming");
	        shouldTrigger = false;
	    }

	    if (Player.transform.position.y < 206 && Player.transform.position.x > 438.5)
	    {
            DragonScript.MountDragon = true;
	        enabled = false;
	    }

    }
}
