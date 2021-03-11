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

    private AudioSource sfx;

    void Start() {
        sfx = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        
        SetColor();

        StartStates();
    }

    void Update() {

    }

    private void Awake()
    {
        //StartStates();
    }

    public void interact()
    {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        if (on)
        {
            em.energy += this.energyItTakes;
            on = false;
            if (!_locked)
            {
                Off.Invoke();
            }
        }
        else
        {
            if (em.energy >= this.energyItTakes)
            {
                em.energy -= this.energyItTakes;
                on = true;
                if (!_locked)
                {
                    On.Invoke();
                }
            }
        }
        SetColor();
        FindObjectOfType<EnergyMeter>().updateEnergyMeter();
        sfx.PlayOneShot(sfx.clip);
    }
        public void StartStates()
        {
            if (on)
            {
                On.Invoke();
            } else
            {
                Off.Invoke();
            }
        }


        private void SetColor(){
            if (on) {
                rend.material.SetColor("_BaseColor", Color.green);
            }
            else {
                rend.material.SetColor("_BaseColor", Color.red);
            }
        }
    
}
