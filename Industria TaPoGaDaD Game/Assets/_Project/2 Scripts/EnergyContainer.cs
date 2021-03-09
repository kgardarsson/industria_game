using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyContainer : MonoBehaviour {

    public uint energyItTakes;
    public bool on;
    Renderer rend;

    public UnityEvent On;
    public UnityEvent Off;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.material.color = on ? Color.green : Color.red;
    }

    void Update() {

    }

    public void interact() {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        if (on) {
            em.energy += this.energyItTakes;
            on = false;
            Off.Invoke();
        } else {
            if(em.energy >= this.energyItTakes) {
                em.energy -= this.energyItTakes;
                on = true;
                On.Invoke();
            }
        }
        rend.material.color = on ? Color.green : Color.red;
        FindObjectOfType<EnergyMeter>().updateEnergyMeter();

        // if (on)
        // {
        //     On.Invoke();
        // } else
        // {
        //     Off.Invoke();
        // }
    }
}
