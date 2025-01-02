using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    private GameObject door;
    private Animator doorAnim;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        doorAnim = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        
        if (!isOpen)
        {
            doorAnim.SetBool("OpenDoor", true);
            isOpen = true;
        } else
        {
            doorAnim.SetBool("OpenDoor", false);
            isOpen = false;
        }
    }
}
