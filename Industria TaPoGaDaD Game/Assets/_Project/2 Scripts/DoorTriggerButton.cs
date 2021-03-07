using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
   [SerializeField] public DoorAnimated door1;


   private void Update(){

       if (Input.GetKeyDown(KeyCode.F)){
           door1.OpenDoor();
           print("yesyesyesye");
       }

        if (Input.GetKeyDown(KeyCode.G)){
            door1.CloseDoor();
            print("nonono");

       }
   }


}
