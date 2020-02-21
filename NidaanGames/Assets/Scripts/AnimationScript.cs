using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public Animator anim;
    public List<string> setTrigger;
    public int currentString;
	
    public void PlayEffect(int stringNumber)
    {
        anim.SetTrigger(setTrigger[stringNumber]);
        this.GetComponent<Collider>().enabled = true;
    }
    public void PlayNextEffect(int playOneBy)
    {
        if (currentString > 0 && currentString < setTrigger.Count)
        {
            PlayEffect(currentString);
            currentString += playOneBy;
        }
        else
        {
            PlayEffect(0);
            currentString = 1;
        }
       
    }
}
