using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateInteractionPoint : MonoBehaviour
{
    public float currScale = 0.1f;
    public float margine = 0.1f;
    public Vector3 scaleVec;
    public float maxIncrease;
    public float minDicrease;
    public bool reachMax;
    private void Start()
    {
        scaleVec = gameObject.transform.localScale;
        currScale = scaleVec.x;
        maxIncrease = currScale + maxIncrease;
        minDicrease = currScale - minDicrease;
    }
    private void Update()
    {
        if (currScale <= maxIncrease && reachMax == false)
        {
            currScale += (Time.deltaTime * 0.5f);
            scaleVec.x = scaleVec.y = scaleVec.z = currScale;
            gameObject.transform.localScale = scaleVec;
        }
        else if(currScale >= minDicrease && reachMax == true)
        {
            currScale -= (Time.deltaTime * 0.5f);
            scaleVec.x = scaleVec.y = scaleVec.z = currScale;
            gameObject.transform.localScale = scaleVec;
        }
        else if (currScale > maxIncrease - margine)
        {
            reachMax = true;
        }
        else if (currScale < minDicrease + margine)
        {
            reachMax = false;
        }
    }
}
