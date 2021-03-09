using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorPicker : MonoBehaviour
{
    public UnityEvent Dot;
    public UnityEvent Button;
    private bool inRangeOfButton;


    // Update is called once per frame
    void Update()
    {
        inRangeOfButton = FindObjectOfType<Interactor>().inRangeOfButton;
        if (inRangeOfButton == true)
        {
            Button.Invoke();

        }
        else
        {
            Dot.Invoke();
        }
    }
}
