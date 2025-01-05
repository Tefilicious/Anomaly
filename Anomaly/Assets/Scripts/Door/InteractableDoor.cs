using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    public AudioClip doorSound;
    private AudioSource audioSource;
    private GameObject door;
    private Animator doorAnim;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door");
        doorAnim = door.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        
        if (!isOpen)
        {
            audioSource.PlayOneShot(doorSound);
            doorAnim.SetBool("OpenDoor", true);
            isOpen = true;
        } else
        {
            audioSource.PlayOneShot(doorSound);
            doorAnim.SetBool("OpenDoor", false);
            isOpen = false;
        }
    }
}
