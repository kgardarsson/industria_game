using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyContainer : MonoBehaviour {

    public uint energyItTakes;
    public bool on;

    void Start() {
        
    }

    void Update() {
        if (Input.anyKeyDown) {
            interact();
        }
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
    }
}
