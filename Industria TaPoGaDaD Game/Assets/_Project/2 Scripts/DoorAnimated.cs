using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{

private Animator animator;

bool Open; 


private void Start(){
animator = gameObject.GetComponent<Animator>();
}

public void OpenDoor(){
print("pressedpressedpressed");
animator.SetBool("Open",true);

// bool foo = animator.GetBool("Open");
// Debug.Log(foo + " for bool Fire.");
}

public void CloseDoor(){

print("pressedpressedpressed");

animator.SetBool("Open",false);


}

}
