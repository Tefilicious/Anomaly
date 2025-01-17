using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == controller.gameObject)
            return;

        controller.setGrounded(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller.gameObject)
            return;

        controller.setGrounded(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == controller.gameObject)
            return;

        controller.setGrounded(true);

    }
}
