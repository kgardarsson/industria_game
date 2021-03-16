using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAnimationManager : MonoBehaviour
{
    public GameObject animationObj, requiredEnergy, totalEnergy;
    [SerializeField] float animationSpeed = .2f;
    private GameObject energyObj;

    private void Awake()
    {
        animationObj = GameObject.FindGameObjectWithTag("Energy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToTotal()
    {
        LeanTween.move(animationObj, totalEnergy.transform.position, animationSpeed);
    }

    public void MoveToCenter()
    {
        LeanTween.move(animationObj, requiredEnergy.transform.position, animationSpeed);
    }
}
