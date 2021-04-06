using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {
    private Material mat;

    private void Awake() {
        mat = GetComponent<Renderer>().sharedMaterial;
    }

    public void turnOff() {
        mat.SetColor("_EmissiveColor", new Color(0,0,0,255));
    }

    public void turnOn() {
        mat.SetColor("_EmissiveColor", new Color(255,255,255,255));
    }
}
