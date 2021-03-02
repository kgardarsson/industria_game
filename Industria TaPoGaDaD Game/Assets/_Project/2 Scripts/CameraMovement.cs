using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables
    float rotationOnX;
    float mouseSensitivity = 90f;
    public Transform Player;
    public float interactDistance = 5;
    public LayerMask interactLayer;


    // Start is called before the first frame update
    void Start()
    {
        //Hide Mouse Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Taking mouse input;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        //Rotate camera up and down
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        //Rotate left and right
        Player.Rotate(Vector3.up * m_X);

        print("mouseclick");
        // Raycasting
    RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            print("hit something");
            if (Input.GetMouseButtonDown(0)) {
                if (hit.collider.gameObject.tag == "Button") {
                    hit.collider.gameObject.GetComponent<EnergyContainer>().interact();
                } 
            }
        }
        else
        {
            // Debug.Log("Did not Hit");

    }


        
    }
}
