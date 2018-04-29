using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JSSceneManager : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if (AllConditions.Instance.conditions.First(x => x.description == "JSFinish").satisfied)
	    {
	        SceneManager.LoadScene("Menu");
	        SceneManager.UnloadSceneAsync("JS");
	        enabled = false;
	    }
	}
}
