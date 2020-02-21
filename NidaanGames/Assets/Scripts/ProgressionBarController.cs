using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressionBarController : MonoBehaviour {

    public RectTransform bar;
    public float maxWidth;
    public float minWidth;
    public float currentHight;
    public int divedBy = 1;
    public float pixelValueOfOne;
    public int currentValue = 0;
    public float currentPixel;
    public Text totalValueProgressBarr;

    void Start ()
    {
        maxWidth = bar.sizeDelta.x;
        currentHight = bar.sizeDelta.y;
        pixelValueOfOne = maxWidth / divedBy;
        addValue(currentValue);
        ChangeTotalValue(currentValue);
	}

    public void addValue(int value)
    {
        currentValue += value;
        currentPixel = pixelValueOfOne * currentValue;
        if (currentValue < maxWidth && currentValue >= minWidth)
        {
            bar.sizeDelta = new Vector2(currentPixel, currentHight);
        }
        else
        {
            Debug.Log("You reached max with can not add more");
        }
        ChangeTotalValue(currentValue);
    }
    public void ChangeTotalValue(int total)
    {
        totalValueProgressBarr.text = total.ToString() + "/" + divedBy.ToString();
    }
 
}

