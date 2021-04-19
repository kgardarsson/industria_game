using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Footsteps : MonoBehaviour
{

    private AudioSource src;
    public AudioClip[] steps_clips = new AudioClip[5];
    public AudioClip[] clothes_clips = new AudioClip[5];
    public AudioClip[] keys_clips = new AudioClip[3];
    private bool walking;
    private bool running;
    private bool locked;
    Movement movement;
    float repeatRate = .5f;

    private void Awake()
    {
        src = GetComponent<AudioSource>();

        movement = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        if (!movement.isLockedMovement())
        {
            if (running != movement.isRunning())
            {
                running = movement.isRunning();
                repeatRate = movement.isRunning() ? .3f : .5f;
                CancelInvoke();
                InvokeRepeating("playStep", repeatRate, repeatRate);
            }

            bool walkKeyPressed = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

            if (!walking && walkKeyPressed)
            {
                CancelInvoke();
                InvokeRepeating("playStep", repeatRate, repeatRate);
                walking = true;
            }
            else if (walking && !walkKeyPressed)
            {
                CancelInvoke();
                walking = false;
            }
        }
        else
        {
            CancelInvoke();
        }
    }

    private void playStep()
    {
        int rand = UnityEngine.Random.Range(0, steps_clips.Length);
        src.PlayOneShot(steps_clips[rand], .4f);

        rand = UnityEngine.Random.Range(0, clothes_clips.Length);
        src.PlayOneShot(clothes_clips[rand], .3f);

        rand = UnityEngine.Random.Range(0, keys_clips.Length);
        src.PlayOneShot(keys_clips[rand], .03f);
    }
}









// -----------
// Some old stuff below
// -----------


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Footsteps : MonoBehaviour
// {
//     [FMODUnity.EventRef]
//     public string inputsound;
//     bool playerismoving;
//     public float walking speed;


//     void Update () 
//     {
//         if (Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis ("Horizontal") >= 0.01f || Input.GetAxis ("Vertical") <= -0.01f || Input.GetAxis ("Horizontal") <= -0.01f) 
//         {
//             //Debug.Log ("Player is moving");
//             playerismoving = true;
//         } 
//         else if (Input.GetAxis ("Vertical") == 0 || Input.GetAxis ("Horizontal") == 0)
//         {
//             //Debug.Log ("Player is not moving");
//             playerismoving = false;
//         }
//     }


//     void CallFootsteps ()
//     {
//         if (playerismoving == true) 
//         {
//             //Debug.Log ("Player is moving");
//             FMODUnity.RuntimeManager.PlayOneShot (inputsound);
//         } 
//     }


//     void Start ()
//     {
//         InvokeRepeating ("CallFootsteps", 0, walkingspeed);
//     }


//     void OnDisable ()
//     {
//         playerismoving = false;
//     }
// }