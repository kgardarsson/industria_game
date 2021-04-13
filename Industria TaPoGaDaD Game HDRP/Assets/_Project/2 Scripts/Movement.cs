using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float mSpeed = 5f;
    public bool isOn = false;

    public bool failSafe = false;
    bool locked;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (!locked)
        {
            transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }

        //  if(rb.velocity.magnitude > 0){
        //     GetComponent<AudioSource>().Play();
        //         StartCoroutine(FailSafe(0.1f));
        //  }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            print("running");
            if (isOn == false && failSafe == false)
            {
                failSafe = true;
                mSpeed = 10;
                isOn = true;
                StartCoroutine(FailSafe(0.25f));

            }

            if (isOn == true && failSafe == false)
            {
                failSafe = true;
                mSpeed = 5;

                isOn = false;
                StartCoroutine(FailSafe(0.25f));

            }

        }


    }

    IEnumerator FailSafe(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        failSafe = false;
    }

    public void enableMovement()
    {
        locked = false;

    }

    public void disableMovement()
    {
        locked = true;
    }

}



