using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClose : MonoBehaviour {
    public Collider Player;

    private void OnTriggerEnter(Collider Player) {
        if (transform.parent.TryGetComponent<DoorController>(out DoorController door)) {
            door.Open(false);
        } else {
            Debug.LogError("GameObject of AutoClose component needs to be a child of GameObject with DoorController");
        }
    }
}
