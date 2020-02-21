using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVariables : MonoBehaviour {
    public Text reading;
    public ProceduralAudio pf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		reading.text = "dB = " + pf.gain.ToString() +"0" +" Freq = " + pf.frequency.ToString() + "\r\nSound Length in Seconds = " + pf.waveLengthInSeconds.ToString();
	}
}
