using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexureEffects : MonoBehaviour {

    public Renderer rend;
    public float rotationOffsetY;
    public float rotationOffsetX;
    public float scaleOffsetY;
    public float scaleOffsetX;
    public Vector2 direction;
    public bool activate;
    public Vector2 metamorphoses;


    public float fixedFramerate = 20.0f;

    IEnumerator Start()
    {
        while (Application.isPlaying)
        {
            CustomFixedUpdate();
            yield return new WaitForSeconds(1.0f / fixedFramerate);
        }
    }
    public void ChangeScale()
    {
        metamorphoses = new Vector2(scaleOffsetX, scaleOffsetY);
        rend.material.SetTextureScale("_MainTex", metamorphoses);
    }
    private void CustomFixedUpdate()
    {
        if (activate)
        {
            direction = new Vector2(rotationOffsetX*Time.time, rotationOffsetY * Time.time);
            rend.material.SetTextureOffset("_MainTex", direction);
           
        }
        else 
        {
            metamorphoses = new Vector2(1, 1);
            rend.material.SetTextureScale("_MainTex", metamorphoses);
        }
    }

}
