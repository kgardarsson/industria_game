using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open(bool open)
    {
        animator.SetBool("Open", open);
    }

    public void Lock(bool locked)
    {
        animator.SetBool("Locked", locked);
    }
}
