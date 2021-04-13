using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public AudioSource playaudio;  
    public Animator m_Animator;
    public Light myLight;
    public bool playing = true;
    public bool failSafe = false;

    // Start is called before the first frame update
    void Start()
    {
            //m_Animator = gameObject.GetComponent<Animator>();
            playaudio = GetComponent<AudioSource>();
            playaudio.volume=0.5f;

    }


    void OnMouseDown() {
        if (playing == false)
        {
        myLight.enabled = true;
        playaudio.volume=0.5f;
        playaudio.Play();
        playing = true; 
        failSafe = true;
        print(playing);
        StartCoroutine(FailSafe(0.25f));
        }


        else if (playing == true)
        {
        myLight.enabled = false;
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