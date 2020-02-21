using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int levelNumber;
    public PlayerInfo playerInfo;
    public Teleport teleport;
    public List<Animator> panelAnimators;

    // Update is called once per frame
    private void Start()
    {
        if (teleport == null)
        {
            Debug.LogError("Drag and Drop Teleport in this scrtipt");
        }
        playerInfo.levelNumber = levelNumber;
        ActivateAndDisableMenu();
    }
    void Update ()
    {
        
        if(teleport.levenNumber != levelNumber)
        {
            teleport.levenNumber = levelNumber;
            ActivateAndDisableMenu();
        }
	}

    void ActivateAndDisableMenu()
    {
        
        switch (levelNumber)
        {
            case 0:
                    panelAnimators[1].SetTrigger("close");
                    panelAnimators[0].SetTrigger("open");

                break;
            case 1:
                    panelAnimators[0].SetTrigger("close");
                    teleport.menuOpen = false;
                break;
            default:
                Debug.Log("Please Add Animator looks like one is missing");
                break;
        }
           
    }
    public void ChangeLevel(int level)
    {
        levelNumber = level;
    }
}
