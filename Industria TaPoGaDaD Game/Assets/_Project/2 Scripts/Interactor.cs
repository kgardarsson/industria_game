using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactDistance = 5;
    public LayerMask interactLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Raycasting
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.tag == "Button")
                    hit.collider.gameObject.GetComponent<EnergyContainer>().interact();

                if (hit.collider.gameObject.tag == "Computer")
                {
                    hit.transform.gameObject.GetComponentInParent<CodeLock>().SetValue(hit.transform.name);
                }
            }
        }
        else
        {
            // Debug.Log("Did not Hit");

        }
    }
}
