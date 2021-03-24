using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables
    float rotationOnX;
    [SerializeField] float mouseSensitivity = 90f;
    public Transform Player;



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

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            //Taking mouse input;
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

            //Rotate camera up and down
            rotationOnX -= mouseY;
            rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
            transform.localRotation = Quaternion.Euler(rotationOnX, 0f, 0f);

            //Rotate left and right
            Player.Rotate(Vector3.up * m_X);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }


}
