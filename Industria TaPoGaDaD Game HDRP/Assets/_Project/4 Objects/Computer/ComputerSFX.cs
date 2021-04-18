using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerSFX : MonoBehaviour {

    public AudioClip start;
    public AudioClip running;
    public AudioClip end;
    private AudioSource src;

    void Awake() {
        src = GetComponent<AudioSource>();
        playAudio();
    }

    public void playAudio() {
        src.clip = start;
        src.loop = true;
        src.Play();
        Invoke("setRunning", start.length);
    }

    private void setRunning() {
        src.clip = running;
        src.Play();
    }

    public void stopAudio() {
        CancelInvoke();
        src.clip = end;
        src.loop = false;
        src.Play();
    }
}
