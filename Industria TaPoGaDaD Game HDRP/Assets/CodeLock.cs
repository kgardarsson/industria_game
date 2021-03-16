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

    [SerializeField]
    [Multiline]
    string defaultText;
    public string code = "";
    public string attemptedCode;

    public UnityEvent LockDoor;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        codeLength = code.Length;
        resetCode();
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            LockDoor.Invoke();
            text.faceColor = new Color(0, 0.7f, 0, 1);
            // AudioSource sfx = GetComponent<AudioSource>();
            // sfx.PlayOneShot(sfx.clip);
        }
        else
        {
            Debug.Log("Wrong Code");
            text.faceColor = Color.red;
        }
    }


    public void SetValue(string value)
    {
        placeInCode++;

        if (placeInCode == 0)
        {
            attemptedCode += value;
            text.SetText(attemptedCode.ToString());
        }
        else if (placeInCode <= codeLength)
        {
            text.faceColor = Color.black;
            attemptedCode += value;
            text.SetText(attemptedCode.ToString());
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
        // AudioSource sfx = transform.GetChild(int.Parse(value)).GetComponent<AudioSource>();
        // sfx.PlayOneShot(sfx.clip);
    }

    public void resetCode()
    {
        attemptedCode = "";
        text.SetText(defaultText);
        text.faceColor = Color.black;
    }
}
