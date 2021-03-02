using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyContainer : MonoBehaviour {

    public uint energyItTakes;
    public bool on;

    public UnityEvent On;
    public UnityEvent Off;

    void Start() {
        
    }

    void Update() {

    }

    public void interact() {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        if (on) {
            em.energy += this.energyItTakes;
            on = !on;
        } else {
            if(em.energy >= this.energyItTakes) {
                em.energy -= this.energyItTakes;
                on = !on;
            }
        }
        FindObjectOfType<EnergyMeter>().updateEnergyMeter();

        if (on)
        {
            On.Invoke();
        } else
        {
            Off.Invoke();
        }
    }
}
