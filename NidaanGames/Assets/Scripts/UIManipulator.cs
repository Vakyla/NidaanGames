using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManipulator : MonoBehaviour
{
    public UIController uiController;
    public Image cooldown;
    public bool coolingDown;
    public float waitTime = 30.0f;
    public bool checkData;
    
    public Text location;
    public Image bar;
    public Text barProgress;
    public Text prosDescription;
    public Image checkMark;
    public Image issuImage;
 
    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            cooldown.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if(checkData == true)
        {
            CreateUi();
            checkData = false;
        }
    }

    void CreateUi()
    {
        var roomNumber = uiController.roomNumber;
        location.text = uiController.RoomList[roomNumber].roomName;
        BarProgress();
    }

    void BarProgress()
    {
        var activeMarks = uiController.totalActiveCheckMarks;
        int totalMarks = uiController.totalProAndCons;
        barProgress.text = activeMarks.ToString() + "/" + totalMarks.ToString();
    }
    

}
