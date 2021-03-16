using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CursorPicker : MonoBehaviour
{
    public UnityEvent Dot;
    public UnityEvent Button;
    private bool inRangeOfButton;
    private Image energyUI;

    private void Start()
    {
        energyUI = GameObject.FindGameObjectWithTag("Energy").GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        inRangeOfButton = FindObjectOfType<Interactor>().inRangeOfButton;
        if (inRangeOfButton == true)
        {
            Button.Invoke();
            energyUI.enabled = true;
        }
        else
        {
            Dot.Invoke();
            energyUI.enabled = false;
        }
    }
}
