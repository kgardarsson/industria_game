using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
    }

    public void Open(bool open)
    {
        animator.SetBool("Open", open);
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.enabled = !open;
    }

    public void Lock(bool locked)
    {
        animator.SetBool("Locked", locked);
    }
}
