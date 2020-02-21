using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Implement interfaces...
public class BeingHitByRay : MonoBehaviour
{
    public GameObject buttonHighlight;
    public Button button;
    public bool exit;
    public bool testButtton;
    public Bezier bezier;
    public bool secondHighLight;
    public GameObject secondHighlight;
    public bool thirdHighLight;
    public GameObject thirdHighlight;
    public bool disableTexure;
    public GameObject disableObject;
    public SFX_Controller musicController;
    public bool ifInteractionPoint;
    public bool hiddenPoint;
    public bool clickSound = true;
    // Handle event
    private void Start()
    {
        buttonHighlight.SetActive(false);
        exit = true;
        button = GetComponent<Button>();
        bezier = GameObject.Find("BezierCurve").GetComponent<Bezier>();
        if(musicController == null)
        {
            musicController = GameObject.Find("TeleportRig").GetComponent<SFX_Controller>();
        }

    } 

    public void OnGazeEnter()
    {
        if (exit == true)
        {
            exit = false;
            buttonHighlight.SetActive(true);
            if (secondHighLight == true)
            {
                secondHighlight.SetActive(true);
            }
            if (thirdHighLight == true)
            {
                thirdHighlight.SetActive(true);
            }
            if (disableTexure == true)
            {
                disableObject.SetActive(false);
            }

        }
     
    }
    public void OnGazeExit()
    {
        if (exit ==false)
        {
            exit = true;
            buttonHighlight.SetActive(false);
            if (secondHighLight == true)
            {
                secondHighlight.SetActive(false);
            }
            if (thirdHighLight == true)
            {
                thirdHighlight.SetActive(false);
            }
            if ( disableObject == true)
            {
                disableObject.SetActive(true);
            }
        }

    }
    public void Click()
    {
        button.onClick.Invoke();

        if(clickSound == true)
        {
            musicController.PlayClick();
        }
        else if (ifInteractionPoint == true)
        {
            musicController.PlayShutterSound();
        }
        else if (hiddenPoint == true)
        {
            musicController.PlayHiddenInteraction();
        }
    }
    private void Update()
    {
        if(testButtton == true)
        {
            testButtton = false;
            Click();
        }
    }
    public void LeaveSecondHiglitActive(bool active)
    {
        secondHighLight = active;
    }
}
