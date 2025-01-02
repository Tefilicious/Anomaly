using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to the character
        animator = GetComponent<Animator>();
    }

    // Trigger animation when the mouse starts hovering over the GameObject
    private void OnMouseOver()
    {
        Debug.Log("Female Character");
        if (animator != null)
        {
            animator.SetBool("IsHovering", true);
        }
    }

    // Stop the animation when the mouse stops hovering over the GameObject
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit Female");
        if (animator != null)
        {
            animator.SetBool("IsHovering", false);
        }
    }
}



