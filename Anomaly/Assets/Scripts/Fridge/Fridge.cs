using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    private Animator fridgeAnim;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        fridgeAnim = GetComponent<Animator>();
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
