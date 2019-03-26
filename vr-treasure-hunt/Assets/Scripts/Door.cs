using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool openStart;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (openStart) {
            animator.SetTrigger("Open");
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
    }

    public void CloseDoor()
    {
        animator.SetTrigger("Close");
    }
}
