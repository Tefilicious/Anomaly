using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour, IInteractable
{
    private Animator drawerAnim;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        drawerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        if (!isOpen)
        {
            drawerAnim.SetBool("OpenDrawer", true);
            isOpen = true;
        } else
        {
            drawerAnim.SetBool("OpenDrawer", false);
            isOpen = false;
        }
    }
}
