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
            int number;
            if (int.TryParse(Input.inputString, out number))
            {
                Debug.Log("Pressed key: " + number);
                CodeLock.SetValue(number.ToString());
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
