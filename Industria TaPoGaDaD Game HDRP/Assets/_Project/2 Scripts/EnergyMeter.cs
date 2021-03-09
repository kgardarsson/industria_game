using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    public uint energy;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateEnergyMeter()
    {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        GetComponent<Text>().text = em.energy.ToString();
    }
}
