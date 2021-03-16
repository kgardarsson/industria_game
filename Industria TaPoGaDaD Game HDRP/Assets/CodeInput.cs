using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeInput : MonoBehaviour
{
    private bool inputReady;
    private CodeLock CodeLock;

    private void Start()
    {
        CodeLock = gameObject.GetComponent<CodeLock>();
    }

    private void Update()
    {
        if (inputReady)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                Char input = (char)kcode;
                bool isDigit = char.IsDigit((char)kcode);
                if (Input.GetKeyDown(kcode) && isDigit)
                {
                    // Debug.Log("KeyCode down: " + (char)kcode);
                    CodeLock.SetValue("" + input);
                }
            }

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
