using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectangleController : MonoBehaviour {

    public ScrollRect scrollRect;
    public Vector2 rectValues;
    public float value;
    public float moveBy;
    public List<string> shortDescriptions;
    public List<string> fullDescriptions;
    public bool hasDescription;
    public List<float> intValue;
    public float currentDifference;
    public float currentNearest;
    public TextMeshProUGUI shortDescript;
    public TextMeshProUGUI fullDescript;
    public int elementNumber;
    public List<Sprite> sprites;
    public List<Image> images;
    public float imagePos;
    public float moveTo = 0;

    void Start ()
    {
        

        if (GetComponent<ScrollRect>()!= null)
        {
            scrollRect = GetComponent<ScrollRect>();

            if (hasDescription == true)
            {
                /*
                value = 1;
                float width = scrollRect.content.sizeDelta.x;
                moveBy = value / (shortDescriptions.Count +1);
                float tempValue = moveBy; 
                for (int i = 0; i < shortDescriptions.Count +1; i++)
                {
                    var imagePos = images[i].transform.localPosition.x;
                    if (imagePos < 0)
                        imagePos = (width/2) + imagePos;
                    else
                        imagePos = width/2 + imagePos;
                    tempValue = imagePos/width * 1;
                    intValue.Add(tempValue);
                    
                }
               */
            }
          
        }

        else
            Debug.LogError("This game Object does not have the Scroll Rect component");
    }
    private void Update()
    {
        value = scrollRect.horizontal == true ? value = scrollRect.horizontalNormalizedPosition : value = scrollRect.verticalNormalizedPosition;

        if (value > 1)
            value = 1;
        if (value < 0)
            value = 0;
        if (hasDescription == true)
        {
            currentNearest = intValue[0];
            currentDifference = Math.Abs(currentNearest - value);
            // sort for nearest
            for (int i = 0; i < intValue.Count; i++)
            {
                float diff = Math.Abs(intValue[i] - value);
                if (diff < currentDifference)
                {
                    currentDifference = diff;
                    currentNearest = intValue[i];
                    elementNumber = i;
                   
                }
            }
            if (intValue.Count > 1 && currentNearest < intValue[1])
                elementNumber = 0;
            shortDescript.text = shortDescriptions[elementNumber];
            fullDescript.text = fullDescriptions[elementNumber];
        }
      
    }

       
    
    // Update is called once per frame
    public void MoveUp (float upPlus = 0.1f )
    {
        if(hasDescription == true)
        {
            // downPlus = moveBy/2;
            moveTo = intValue[elementNumber + 1];
        }
        if (value >= 0 && value <= 1)
        {
            value += upPlus;
            scrollRect.verticalNormalizedPosition = value;
            rectValues = scrollRect.velocity;
        }
       
    }
    public void MoveDown(float downPlus= 0.1f)
    {
        if (hasDescription == true)
        {
            // downPlus = moveBy/2;
           moveTo = intValue[elementNumber - 1];
        }
        if (value <= 1 && value >= 0)
        {
            value -= downPlus;
            scrollRect.verticalNormalizedPosition = moveTo;
            rectValues = scrollRect.velocity;
        }
          
    }
    public void MoveRight(float leftPlus = 0.1f)
    {
        if(hasDescription == true)
        {
            // downPlus = moveBy/2;
           moveTo = intValue[elementNumber + 1];
        }
        if (value <= 1 && value >= 0)
        {
            value += leftPlus;
            scrollRect.horizontalNormalizedPosition = moveTo;
            rectValues = scrollRect.velocity;
        }
       
    }
    public void MoveLeft(float rightPlus = 0.1f)
    {
        
        if (hasDescription == true)
        {
            // downPlus = moveBy/2;
            moveTo = intValue[elementNumber - 1];
        }
        if (value >= 0 && value <= 1)
        {
            //value -= rightPlus;
            scrollRect.horizontalNormalizedPosition = moveTo;
            rectValues = scrollRect.velocity;
        }
        
    }

    public void AddIttemToScrollView(int panelNumber, string shortDescrip, string fullDescrip)
    {
        shortDescriptions[panelNumber] = shortDescrip;
        fullDescriptions[panelNumber] = fullDescrip;
        images[panelNumber].sprite = sprites[panelNumber];

    }
    
}
