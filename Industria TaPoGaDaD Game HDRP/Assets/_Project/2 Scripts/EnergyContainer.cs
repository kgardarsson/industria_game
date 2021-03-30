using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class EnergyContainer : MonoBehaviour
{

    public uint energyItTakes;
    [SerializeField]
    private EnergyAnimationManager eam;
    public bool on;
    [SerializeField]
    private bool _locked;
    public bool Locked
    {
        get { return _locked; }
        set
        {
            _locked = value;
            if (on)
            {
                On.Invoke();
            }
            else
            {
                Off.Invoke();
            }
        }
    }
    Renderer rend;

    public UnityEvent On;
    public UnityEvent Off;

    private AudioClip sfx;
    private AudioClip sfxNegative;
    void Start()
    {
        rend = GetComponent<Renderer>();

        SetColor();

        StartStates();


        eam = GameObject.Find("EnergyAnimationManager").GetComponent<EnergyAnimationManager>();
    }
    void Update()
    {

    }

    private void Awake()
    {
        sfx = (AudioClip)Resources.Load("Audio/SFX/Button", typeof(AudioClip));
        sfxNegative = (AudioClip)Resources.Load("Audio/SFX/Button Negative", typeof(AudioClip));
        //StartStates();
    }

    public void interact()
    {
        EnergyManager em = FindObjectOfType<EnergyManager>();
        if (on)
        {
            // If button is on
            em.energy += this.energyItTakes;
            on = false;
            eam.MoveToTotal();
            if (!_locked)
            {
                Off.Invoke();
            }
            AudioSource.PlayClipAtPoint(sfx, transform.position);

        }
        else
        {
            if (em.energy >= this.energyItTakes)
            {
                // If button is off and player has enough energy
                em.energy -= this.energyItTakes;
                on = true;
                eam.MoveToCenter();
                if (!_locked)
                {
                    On.Invoke();
                }
                AudioSource.PlayClipAtPoint(sfx, transform.position);

            }
            else
            {
                // If button is off and player DOES NOT have enough energy
                AudioSource.PlayClipAtPoint(sfxNegative, transform.position, .3f);
            }
        }
        SetColor();
        FindObjectOfType<EnergyMeter>().updateEnergyMeter();
    }
    public void StartStates()
    {
        if (on)
        {
            On.Invoke();
        }
        else
        {
            Off.Invoke();
        }
    }



    public void SetColor()
    {
        try
        {

            if (transform.GetChild(0).TryGetComponent<Light>(out Light light))
            {
                if (on)
                {
                    if (!_locked)
                    {
                        light.color = Color.green;
                    }
                    else
                    {
                        light.color = Color.yellow;
                    }
                }
                else
                {
                    light.color = Color.red;
                }
            }
        }
        catch (UnityException)
        {

        }

    }

}
