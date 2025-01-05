using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip fridgeSound;
    private AudioSource audioSource;
    private Animator fridgeAnim;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        fridgeAnim = GetComponent<Animator>();
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
            OpenFridge();
        } else
        {
            CloseFridge();
        }
        audioSource.PlayOneShot(fridgeSound);
    }

    void OpenFridge()
    {
        isOpen = true;
        fridgeAnim.SetBool("isOpen", true);
    }

    void CloseFridge()
    {
        isOpen = false;
        fridgeAnim.SetBool("isOpen", false);
    }
}
