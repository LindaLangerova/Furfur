using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsControl : MonoBehaviour
{

    public ChangeScene changeScene;
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Z))
	    {
	        changeScene.ChangeToScene("MainMenu");
	    }
	    if (Input.GetKeyDown(KeyCode.Alpha1))
	    {
	        changeScene.ChangeToScene("C");
	    }
	    if (Input.GetKeyDown(KeyCode.Alpha2))
	    {
	        changeScene.ChangeToScene("Java");
	    }
	    if (Input.GetKeyDown(KeyCode.Alpha3))
	    {
	        changeScene.ChangeToScene("JS");
	    }
    }
}
