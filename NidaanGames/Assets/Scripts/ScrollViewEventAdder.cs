using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewEventAdder : MonoBehaviour {

    public ScrollRectangleController scrollRectContr;
    public int panelNumberRef;
    public string shortDescriptionRef;
    public string fullDescriptionRef;

    public void ScrollRectContrAddEvent()
    {
        scrollRectContr.AddIttemToScrollView(panelNumberRef, shortDescriptionRef, fullDescriptionRef);
    }
}
