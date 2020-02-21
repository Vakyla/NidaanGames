using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Implement interfaces...
public class ObjectHighlightSelection : MonoBehaviour
{
    public GameObject buttonHighlight;
    public Button button;
    public bool exit;
    public bool testButtton;
    public SFX_Controller musicController;
    public bool clickSound = true;
    // Handle event
    private void Start()
    {
        buttonHighlight.SetActive(false);
        exit = true;
        button = GetComponent<Button>();
        musicController = GameObject.Find("TeleportRigUserPreference").GetComponent<SFX_Controller>();
    }

    public void OnGazeEnter()
    {
        if (exit == true)
        {
            exit = false;
            buttonHighlight.SetActive(true);
        }

    }
    public void OnGazeExit()
    {
        if (exit == false)
        {
            exit = true;
            buttonHighlight.SetActive(false);
        }

    }
    public void Click()
    {
        button.onClick.Invoke();

        if (clickSound == true)
        {
            musicController.PlayClick();
        }
    }
    private void Update()
    {
        if (testButtton == true)
        {
            testButtton = false;
            Click();
        }
    }
}
