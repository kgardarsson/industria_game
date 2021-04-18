using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool initialOpenState = false;

    private Animator animator;
    // Start is called before the first frame update
    private AudioSource sfx;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();
    }

    void Start()
    {
        Open(initialOpenState);
    }

    public void Open(bool open)
    {
        if (open != animator.GetBool("Open"))
        {
            animator.SetBool("Open", open);
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.enabled = !open;
            print(Time.realtimeSinceStartup);
            sfx.PlayOneShot(sfx.clip);
        }
    }

    public void Lock(bool locked)
    {
        animator.SetBool("Locked", locked);
    }
}
