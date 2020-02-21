using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WishListController : MonoBehaviour
{
    public TextMeshProUGUI listValue;
    public int valueOf;
    public int ofValue;

    private void Start()
    {
        listValue.text = valueOf.ToString() + " of " + ofValue.ToString();
    }


    public void AddValueToList()
    {
        if(valueOf < ofValue)
        {
            valueOf++;
        }
       
        listValue.text = valueOf.ToString() + " of " + ofValue.ToString();
    }
}
