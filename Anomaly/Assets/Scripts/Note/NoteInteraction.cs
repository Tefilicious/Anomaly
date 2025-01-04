using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class NoteInteraction : MonoBehaviour, IInteractable
{
    public AudioClip noteSound;
    public GameObject noteUI;
    public GameObject player;
    public NavMeshAgent anomaly;
    private AudioSource noteSource;

    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        noteSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        noteSource.PlayOneShot(noteSound, 0.5f);
        anomaly.isStopped = true;
        noteUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitButton()
    {
        noteSource.PlayOneShot(noteSound, 0.5f);
        noteUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().enabled = true;
        anomaly.isStopped = false;
    }
}
