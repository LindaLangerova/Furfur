using UnityEngine;

public class NodeGod : MonoBehaviour
{
    public Animator Animator;
    public Dragon DragonScript;

    public GameObject Player;

    private bool shouldTrigger;

    // Use this for initialization
    private void Start()
    {
        shouldTrigger = true;
        enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
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