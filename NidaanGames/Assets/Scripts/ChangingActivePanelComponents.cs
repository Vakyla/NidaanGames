using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingActivePanelComponents : MonoBehaviour {

    public int currentIndex;
    public GameObject active;
    public List<GameObject> listOfComponents;
    public int value;
    public int lastElement;
    public bool doNotActivateFirstComponent;

    private void Start()
    {
        if(doNotActivateFirstComponent == false)
        {
            StartCoroutine(Timer());
        }
        
        lastElement = listOfComponents.Count - 1;
    }

    public void ChangeActivePanel(int component)
    {
        active = listOfComponents[component];
        foreach(GameObject obj in listOfComponents)
        {
            obj.SetActive(false);
        }
        active.SetActive(true);
    }
    public void NextPanelRight(bool right)
    {
        value = right == true ? value = 1: value = -1;
        
        for (int i = 0; i < listOfComponents.Count; i++)
        {
            if (listOfComponents[i] == active)
                currentIndex = i;
        }

        currentIndex += value;

        if (currentIndex > lastElement)
            currentIndex = lastElement;
        if (currentIndex < 0)
            currentIndex = 0;

        ChangeActivePanel(currentIndex);
    
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        ChangeActivePanel(0);
    }
}
