using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLocationFloorPlan : MonoBehaviour {


    public List<RectTransform> locations;
    public RectTransform playerLocation;

    public void ChangePlayerLocMap(int location)
    {
        playerLocation.localPosition = locations[location].localPosition;
    }
}
