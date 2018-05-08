using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRunSound : StateMachineBehaviour
{
    public string nameOfSoundObject;
    private GameObject runSound;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //runSound = GameObject.Find(nameOfSoundObject);
        //runSound.GetComponent<AudioSource>().enabled = true;
        //runSound.GetComponent<AudioSource>().Play();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //runSound.GetComponent<AudioSource>().enabled = false;
    }
}
