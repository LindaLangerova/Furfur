using UnityEngine;

public class portUp : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        player.GetComponent<Transform>().SetPositionAndRotation(new Vector3(431, 215, 0), Quaternion.identity);
        enabled = false;

        var terminator = GameObject.Find("NullTerminator");
        if (terminator != null) terminator.GetComponent<BossFightC>().enabled = true;
    }
}