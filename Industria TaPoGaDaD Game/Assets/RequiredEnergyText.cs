using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequiredEnergyText : MonoBehaviour
{
    public uint energyItTakes;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateEnergyMeter()
    {
        energyItTakes = FindObjectOfType<CameraMovement>().energyItTakes;
        GetComponent<Text>().text = energyItTakes.ToString();
    }
}
