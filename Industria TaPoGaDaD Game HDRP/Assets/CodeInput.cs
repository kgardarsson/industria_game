using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeInput : MonoBehaviour
{
    private bool inputReady;
    private CodeLock CodeLock;
    private static int sfxSize = 10;
    private AudioClip[] sfx = new AudioClip[sfxSize];

    private void Awake() {
        // foreach (var item in sfx)
        // {
        //     sfx[i] = (AudioClip)Resources.Load("Audio/SFX/Button", typeof(AudioClip));
        // }
        for (int i = 0; i < sfxSize; i++) {
            sfx[i] = (AudioClip)Resources.Load("Audio/SFX/Computer/"+i, typeof(AudioClip));
        }
    }

    private void Start()
    {
        CodeLock = gameObject.GetComponent<CodeLock>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            CodeLock.resetCode();
        }
        if (inputReady && CodeLock.solved == false)
        {
            int number;
            if (int.TryParse(Input.inputString, out number))
            {
                Debug.Log("Pressed key: " + number);
                CodeLock.SetValue(number.ToString());
                AudioSource.PlayClipAtPoint(sfx[number], transform.position);
            }

            // foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            // {
            //     // Debug.Log((char)kcode);
            //     Char input = (char)kcode;
            //     bool isDigit = char.IsDigit((char)kcode);
            //     if (Input.GetKeyDown(kcode) && isDigit)
            //     {
            //         Debug.Log("KeyCode down: " + kcode.ToString());
            //         CodeLock.SetValue("" + input);
            //     }
            // }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inputReady = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inputReady = false;
    }



}
