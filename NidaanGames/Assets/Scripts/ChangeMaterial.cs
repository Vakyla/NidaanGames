using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour {

    public Material defaultMaterial;
    public Material newMaterial;
    public List<MeshRenderer> swapObj;

    private void Start()
    {
        foreach (MeshRenderer obj in swapObj)
        {
            defaultMaterial = obj.material;
        }
        
    }

    public void SwapMaterial(bool swap)
    {
        foreach(Renderer obj in swapObj)
        {
            obj.material = newMaterial;
        }
    }
}
