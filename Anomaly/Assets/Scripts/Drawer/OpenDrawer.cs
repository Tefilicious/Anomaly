using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip drawerSound;
    private AudioSource audioSource;
    private Animator drawerAnim;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawerAnim = GetComponent<Animator>();
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
            audioSource.PlayOneShot(drawerSound);
            drawerAnim.SetBool("OpenDrawer", true);
            isOpen = true;
        } else
        {
            audioSource.PlayOneShot(drawerSound);
            drawerAnim.SetBool("OpenDrawer", false);
            isOpen = false;
        }
    }
}
