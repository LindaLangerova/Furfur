using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portUp : MonoBehaviour
{

    public GameObject player;

	// Use this for initialization
	void Start ()
	{
	    enabled = false;
	}

    void Update()
    {
        player.GetComponent<Transform>().SetPositionAndRotation(new Vector3(431,215,0), Quaternion.identity);
        enabled = false;
    }

}
