using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public AudioSource playaudio;  
 
    public bool playing = true;
    public bool failSafe = false;

    // Start is called before the first frame update
    void Start()
    {
            playaudio = GetComponent<AudioSource>();
            playaudio.volume=0.5f;

    }


    void OnMouseDown() {
        if (playing == false)
        {
        playaudio.volume=0.5f;
        playaudio.Play();
        playing = true; 
        failSafe = true;
        print(playing);
        StartCoroutine(FailSafe(0.25f));
        }


        else if (playing == true)
        {

        failSafe =true; 
        playaudio.Stop();
        playing = false;
        print(playing);

        StartCoroutine(FailSafe(0.25f));


        }
    }

    IEnumerator FailSafe(float waitTime){
        yield return new WaitForSeconds(waitTime);
        failSafe =false;
    }
    
}