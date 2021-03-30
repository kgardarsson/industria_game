using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float mSpeed = 5f;
    public bool isOn = false;
    public bool failSafe =false;


    // Start is called before the first frame update

    void Start()
    {


    }

    // Update is called once per frame

    void Update()
    {

        transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

       if (Input.GetButtonDown("Run"))
        {
            if(isOn == false && failSafe ==false){
                failSafe = true;
                mSpeed = 10;
                isOn=true;
                StartCoroutine(FailSafe());
            }

            if (isOn==true && failSafe ==false)
            {
                failSafe =true; 
                mSpeed = 5;

                isOn=false;  
                StartCoroutine(FailSafe());

            }

        }

    }

    IEnumerator FailSafe( ){
        yield return new WaitForSeconds(0.25f);
        failSafe =false;
    }

    }



