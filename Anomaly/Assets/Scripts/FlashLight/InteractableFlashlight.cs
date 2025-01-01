using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFlashlight : MonoBehaviour, IInteractable
{
    private GameObject flashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GameObject.FindWithTag("Torch");
        if (flashlight != null )
        {
            flashlight.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        collider.gameObject.SetActive(false);
        flashlight.SetActive(true);
    }
}
