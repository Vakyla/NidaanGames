using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWithDelay : MonoBehaviour
{
    public GameObject obj;
    bool active;

    public void ActivateWithDelay(float seconds)
    {
        active = true;
        StartCoroutine(ActivateAfterSomeTime(seconds));
    }
    public void DeactivateWithDelay(float seconds)
    {
        active = false;
        StartCoroutine(ActivateAfterSomeTime(seconds));
    }
    IEnumerator ActivateAfterSomeTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(active);
    }
}
