using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CodeLock : MonoBehaviour
{

    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    public UnityEvent LockDoor;
    public TextMeshProUGUI text;

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            LockDoor.Invoke();
        }
        else
        {
            Debug.Log("Wrong Code");
        }
    }


    public void SetValue(string value)
    {
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
            text.SetText(attemptedCode.ToString());
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
