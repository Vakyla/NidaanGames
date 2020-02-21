using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFreguency : MonoBehaviour
{

    public ProceduralAudio playFreguency;

    public float waveLengthInSeconds = 1.0f;

    private void Start()
    {
        playFreguency.waveLengthInSeconds = waveLengthInSeconds; 
    }
    public void VolumeDown(float volume)
    {
        if (playFreguency.gain > 0)
            playFreguency.gain -= volume;
    }
    public void adioPlay()
    {
        playFreguency.enabled = true;
        StartCoroutine(PlaySoundFor(waveLengthInSeconds));
    }
    public void adioStop()
    {
        playFreguency.enabled = false;
    }
    public void PlayAdio(bool play)
    {
       // playSound = play;
    }

    public void SetFrequensy(float frequency)
    {
        playFreguency.frequency = frequency;
    }

    public void SetSampleRate(float dB)
    {
        playFreguency.gain = dB/10;
    }
    public void SetSecondsUP(float seconds)
    {
        waveLengthInSeconds += seconds;
        playFreguency.waveLengthInSeconds = waveLengthInSeconds;
    }
    public void SetSecondsDown(float seconds)
    {
        waveLengthInSeconds -= seconds;
        playFreguency.waveLengthInSeconds = waveLengthInSeconds;
    }

    public void SetSampleRateUp(float rate)
    {
        playFreguency.noiseRatio += rate;
    }
    public void SetSampleRateDown(float rate)
    {
        playFreguency.noiseRatio -= rate;
    }
    IEnumerator PlaySoundFor(float time)
    {
        yield return new WaitForSeconds(time);
        adioStop();
    }
   
}

