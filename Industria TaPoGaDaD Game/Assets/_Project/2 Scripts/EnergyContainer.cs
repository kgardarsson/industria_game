using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyContainer : MonoBehaviour {

    public uint energyItTakes;
    public bool on;
    [SerializeField]
    private bool _locked;
    public bool Locked {
        get { return _locked; }
        set {
            _locked = value;
            if (on) {
                On.Invoke();
            } else {
                Off.Invoke();
            }
        }
    }
    Renderer rend;

    public UnityEvent On;
    public UnityEvent Off;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.material.color = on ? Color.green : Color.red;
        // if(on) {
        //     On.Invoke();
        // } else {
        //     Off.Invoke();
        // }
    }

    void Update() {

    }

    public void interact() {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        if (on) {
            em.energy += this.energyItTakes;
            on = false;
            if(!_locked) {
                Off.Invoke();
            }
        } else {
            if(em.energy >= this.energyItTakes) {
                em.energy -= this.energyItTakes;
                on = true;
                if(!_locked) {
                    On.Invoke();
                }
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
