using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTutorialAudio : MonoBehaviour {

    public AudioClip tutorialClip;
    public AudioSource obj;
    public bool test;

    private void Update()
    {
        if (test)
        {
            PlayTutorial();
            test = false;
        }
    }
    public void PlayTutorial()
    {
        if (this.gameObject.GetComponent<AudioSource>() != null)
        {
            obj = gameObject.GetComponent<AudioSource>();
            obj.clip = tutorialClip;
            obj.Play();
            StartCoroutine(WaitAndSelfDestroy());
        }
        else
        {
            gameObject.AddComponent<AudioSource>();
            PlayTutorial();
        }
            
    }

    IEnumerator WaitAndSelfDestroy()
    {
        yield return new WaitWhile(() => obj.isPlaying);
        var comp = GetComponent<PlayTutorialAudio>();
        Destroy(comp);
        Destroy(obj);
    }
}
