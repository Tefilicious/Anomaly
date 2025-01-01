using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public GameObject bookUI;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        bookUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        bookUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitButton()
    {
        Debug.Log("Button is being pressed");
        bookUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
