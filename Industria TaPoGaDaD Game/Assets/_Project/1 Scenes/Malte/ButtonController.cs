using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject controlledObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressPossible(){
        if (Input.GetKeyDown("space"))
        {

            if (this.tag == "DoorButton") {
                controlledObject.SetActive(!controlledObject.activeInHierarchy);
            }
            if (this.tag == "LightButton") {
                controlledObject.SetActive(!controlledObject.activeInHierarchy);
            }
        }
    }
}
