using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JavaSceneManager : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if (AllConditions.Instance.conditions.First(x => x.description == "JavaFinish").satisfied)
	    {
	        SceneManager.LoadScene("JS");
	        SceneManager.UnloadSceneAsync("Java");
            enabled = false;
	    }
	}
}
