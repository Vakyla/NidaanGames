using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ClickManapulator : MonoBehaviour
{
    public GameObject button;
    public float delayTimer;

    public void Click ()
    {

        StartCoroutine(AutoClick(delayTimer));
       
    }
	
	IEnumerator AutoClick(float time)
    {
        yield return new WaitForSeconds(time);
        button.GetComponent<Button>().onClick.Invoke();
       
    }

}
