using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public AudioClip bookSound;
    public GameObject bookUI;
    public GameObject player;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        bookUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        audioSource.PlayOneShot(bookSound);
        bookUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitButton()
    {
        audioSource.PlayOneShot(bookSound);
        bookUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
