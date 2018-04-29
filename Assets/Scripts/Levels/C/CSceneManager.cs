using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
	    if (AllConditions.Instance.conditions.First(x => x.description == "FinishC").satisfied)
	    {
	        SceneManager.LoadScene("Java");
	        SceneManager.UnloadSceneAsync("C");
            enabled = false;
	    }
	}
}
