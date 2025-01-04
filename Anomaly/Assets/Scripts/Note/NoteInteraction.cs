using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NoteInteraction : MonoBehaviour, IInteractable
{
    public GameObject noteUI;
    public GameObject player;
    public NavMeshAgent anomaly;

    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        anomaly.isStopped = true;
        noteUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PlayerController>().enabled = true;
        anomaly.isStopped = false;
    }
}
