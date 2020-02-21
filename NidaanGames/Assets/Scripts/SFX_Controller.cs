using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Controller : MonoBehaviour {

    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    public void PlayClick()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    public void PlayTeleportation()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }
    public void PlayShutterSound()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }
    public void PlayHiddenInteraction()
    {
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }
}
