using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float mSpeed;


    // Start is called before the first frame update

    void Start()
    {

        mSpeed = 2f;

    }

    // Update is called once per frame

    void Update()
    {

        transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }

}
